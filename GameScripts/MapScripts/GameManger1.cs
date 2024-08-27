using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public Text finalScoreText1; // UI Text ที่ใช้แสดงคะแนนรวม
    public Text questionScoreText1; // UI Text ที่ใช้แสดงคะแนนของแต่ละคำถาม
    public Text photographicScoreText1; // UI Text ที่ใช้แสดงคะแนนของภาพถ่าย

    public GameObject gradeAPlusUI; // UI สำหรับเกรด A+
    public GameObject gradeAUI; // UI สำหรับเกรด A
    public GameObject gradeBUI; // UI สำหรับเกรด B
    public GameObject gradeCUI; // UI สำหรับเกรด C
    public GameObject gradeDUI; // UI สำหรับเกรด D

    private int quizScore;
    private int cameraScore;
    private const int maxQuizQuestions = 5;
    private const int maxPhotographicPoints = 10;

    public void SetScores(int quizScore, int cameraScore, bool[] questionResults)
    {
        this.quizScore = quizScore;
        this.cameraScore = cameraScore;
        DisplayFinalScore(questionResults);
        DisplayGrade();
    }

    void DisplayFinalScore(bool[] questionResults)
    {
        int totalScore = quizScore + cameraScore;

        // แสดงคะแนนรวม
        finalScoreText1.text = "SCORE " + totalScore.ToString() + "/" + (maxQuizQuestions + maxPhotographicPoints).ToString();

        // แสดงผลลัพธ์ของแต่ละคำถาม
        string questionScores1 = "";
        for (int i = 0; i < questionResults.Length; i++)
        {
            questionScores1 += questionResults[i] ? "PASS\n" : "FAIL\n";
        }
        questionScoreText1.text = questionScores1;

        // แสดงคะแนนของภาพถ่าย
        photographicScoreText1.text = $"{cameraScore} POINTS";
    }

    void DisplayGrade()
    {
        int totalScore = quizScore + cameraScore;

        // ซ่อน UI ทุกตัวก่อน
        gradeAPlusUI.SetActive(false);
        gradeAUI.SetActive(false);
        gradeBUI.SetActive(false);
        gradeCUI.SetActive(false);
        gradeDUI.SetActive(false);

        // แสดง UI ตามคะแนนที่ได้รับ
        if (totalScore == 15)
        {
            gradeAPlusUI.SetActive(true);
        }
        else if (totalScore >= 13)
        {
            gradeAUI.SetActive(true);
        }
        else if (totalScore >= 11)
        {
            gradeBUI.SetActive(true);
        }
        else if (totalScore >= 9)
        {
            gradeCUI.SetActive(true);
        }
        else if (totalScore <= 8)
        {
            gradeDUI.SetActive(true);
        }
    }
}
