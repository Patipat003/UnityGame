using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public GameObject galleryPanel;
    public GameObject photoPrefab;
    public GameObject PhotoMode;
    public GameObject Sample_canvases;
    public GameObject gameUi; // อ้างอิงไปยัง GameUi ที่ต้องการปิดชั่วคราว

    public Text scoreText;

    public Camera mainCamera; // อ้างอิงถึงกล้องหลัก
    public RenderTexture renderTexture; // RenderTexture ที่ใช้จับภาพ

    private bool isTakingPhoto = false;
    private int score = 0;
    private HashSet<GameObject> foundObjects = new HashSet<GameObject>(); // เพิ่ม HashSet เพื่อเก็บวัตถุที่เจอแล้ว

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        
        // สร้าง RenderTexture หากยังไม่มี
        if (renderTexture == null)
        {
            renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            mainCamera.targetTexture = renderTexture;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !Sample_canvases.activeInHierarchy)
        {
            TogglePhotoMode();
        }

        if (isTakingPhoto && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TakeScreenshot());
        }

        if (isTakingPhoto && Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePhotoMode();
        }

        if (isTakingPhoto && Input.GetMouseButtonDown(0))
        {
            CheckForEvidence();
        }
    }

    void TogglePhotoMode()
    {
        isTakingPhoto = !isTakingPhoto;
        PhotoMode.SetActive(isTakingPhoto);

        if (gameUi != null)
        {
            gameUi.SetActive(!isTakingPhoto); // เปิด gameUi เมื่อปิด PhotoMode
        }

        if (isTakingPhoto)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // สร้าง Texture2D และใช้ RenderTexture เพื่อจับภาพ
        Texture2D screenshot = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();
        RenderTexture.active = null;

        DisplayPhotoInGallery(screenshot);
        SaveScreenshot(screenshot);
    }

    void DisplayPhotoInGallery(Texture2D photoTexture)
    {
        GameObject photoObject = Instantiate(photoPrefab, galleryPanel.transform);
        photoObject.GetComponent<Image>().sprite = Sprite.Create(photoTexture, new Rect(0, 0, photoTexture.width, photoTexture.height), Vector2.zero);

        RectTransform rt = photoObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(photoTexture.width, photoTexture.height);
    }

    void SaveScreenshot(Texture2D photoTexture)
    {
        string filePath = Application.persistentDataPath + "/Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
        byte[] bytes = photoTexture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
    }

    void CheckForEvidence()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.CompareTag("Evidence") && !foundObjects.Contains(obj))
            {
                foundObjects.Add(obj); // เพิ่ม obj ลงใน HashSet
                score++;
                scoreText.text = "Score: " + score.ToString();
                Debug.Log("Found evidence! Score: " + score);
            }
            else
            {
                score--;
                scoreText.text = "Score: " + score.ToString(); 
                Debug.Log("Not Found evidence! Score: " + score);
            }
        }
    }

    public int GetScore()
    {
        return score;
    }
}
