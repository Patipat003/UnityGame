using UnityEngine;

public class ObjectInspection : MonoBehaviour
{
    public Transform inspectionPoint;
    public Canvas uiCanvas;
    public string objectName;
    public string objectDetails; 
    public Transform player;
    public float maxDistance = 5f;
    public FirstPersonMovement playerController;  // อ้างอิงไปยังสคริปต์ที่ควบคุมการเคลื่อนไหวของผู้เล่น
    public GameObject gameUi; // อ้างอิงไปยัง GameUi ที่ต้องการปิดชั่วคราว

    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isInspecting = false;

    private float originalMouseSensitivity;  // เก็บค่าความไวของเมาส์เดิม

    public bool IsInspecting => isInspecting; // เพิ่มตัวแปร public property เพื่อตรวจสอบสถานะ

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInspecting)
            {
                if (IsObjectInView() && IsObjectInRange())
                {
                    StartInspection();
                }
            }
            else
            {
                EndInspection();
            }
        }

        if (isInspecting)
        {
            if (!IsObjectInRange())
            {
                EndInspection();
            }
            else
            {
                RotateObject();
            }
        }
    }

    void StartInspection()
    {
        originalParent = transform.parent;
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        transform.position = inspectionPoint.position;
        transform.rotation = inspectionPoint.rotation;
        transform.parent = inspectionPoint;

        uiCanvas.enabled = true;
        uiCanvas.GetComponentInChildren<UnityEngine.UI.Text>().text = objectName;

        string detailsText = objectName  + "\n" + "\n"  + objectDetails ;
        uiCanvas.GetComponentInChildren<UIController>().UpdateDetails(detailsText);

        isInspecting = true;

        // ปิดการใช้งานการควบคุมผู้เล่นและกล้อง
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // ปิด GameUi
        if (gameUi != null)
        {
            gameUi.SetActive(false);
        }
    }

    void EndInspection()
    {
        transform.parent = originalParent;
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        uiCanvas.enabled = false;
        isInspecting = false;

        // เปิดใช้งานการควบคุมผู้เล่นและกล้อง
        if (playerController != null)
        {
            playerController.enabled = true;
        }

        // เปิด GameUi
        if (gameUi != null)
        {
            gameUi.SetActive(true);
        }
    }

    void RotateObject()
    {
        float rotationSpeed = 300f;
        float rotationAmount = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, rotationAmount, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -rotationAmount, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right, -rotationAmount, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right, rotationAmount, Space.World);
        }
    }

    bool IsObjectInView()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // ยิงเรย์จากกลางจอ
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            return hit.transform == transform;
        }
        return false;
    }

    bool IsObjectInRange()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        return distance <= maxDistance;
    }
}
