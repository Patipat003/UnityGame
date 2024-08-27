using UnityEngine;
using UnityEngine.UI;

public class QuizManager_1 : MonoBehaviour
{
    public Text[] questionTexts; // ข้อความคำถามทั้งหมด 5 ข้อ
    public ToggleGroup[] toggleGroups; // กลุ่มตัวเลือกสำหรับแต่ละคำถาม
    public Toggle[] correctAnswerToggles; // Toggle ที่ถูกต้องสำหรับแต่ละคำถาม
    public Button submitButton; // ปุ่มส่งคำตอบ

    public CameraController cameraController; // อ้างอิงไปยัง CameraController
    public GameManager1 gameManager1; // อ้างอิงไปยัง GameManager

    private int quizScore = 0;
    private bool[] questionResults; // เก็บผลลัพธ์ของแต่ละคำถาม

    void Start()
    {
        if (submitButton != null)
        {
            // กำหนด Listener สำหรับปุ่มส่งคำตอบ
            submitButton.onClick.AddListener(CheckAnswers);
        }
        else
        {
            Debug.LogError("Submit Button is not assigned.");
        }

        // ตรวจสอบการกำหนดค่าของตัวแปรอื่น ๆ
        if (questionTexts.Length != toggleGroups.Length || toggleGroups.Length != correctAnswerToggles.Length)
        {
            Debug.LogError("Array lengths do not match. Please check the setup in the Unity Editor.");
        }

        questionResults = new bool[toggleGroups.Length];
    }

    void CheckAnswers()
    {
        quizScore = 0; // รีเซ็ตคะแนน

        // ตรวจสอบคำตอบสำหรับแต่ละคำถาม
        for (int i = 0; i < toggleGroups.Length; i++)
        {
            // ตรวจสอบตัวเลือกที่ถูกเลือกใน ToggleGroup
            Toggle selectedToggle = toggleGroups[i].GetFirstActiveToggle();
            if (selectedToggle != null)
            {
                // ตรวจสอบว่าตัวเลือกที่เลือกเป็นคำตอบที่ถูกต้องหรือไม่
                bool isCorrect = selectedToggle == correctAnswerToggles[i];
                questionResults[i] = isCorrect;

                if (isCorrect)
                {
                    quizScore += 1; // เพิ่มคะแนน
                }
            }
        }

        // ตรวจสอบการกำหนดค่าของ cameraController และ gameManager
        if (cameraController == null)
        {
            Debug.LogError("CameraController is not assigned.");
            return;
        }

        if (gameManager1 == null)
        {
            Debug.LogError("GameManager1 is not assigned.");
            return;
        }

        // รวมคะแนนจาก Quiz กับคะแนนจาก CameraController
        int cameraScore = cameraController.GetScore();
        
        // ส่งคะแนนและผลลัพธ์ของคำถามไปยัง GameManager
        gameManager1.SetScores(quizScore, cameraScore, questionResults);

        // เปลี่ยนไปยัง scene สรุปผล
        UnityEngine.SceneManagement.SceneManager.LoadScene("SummaryScene 1");
    }
}
