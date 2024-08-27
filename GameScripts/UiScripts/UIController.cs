using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text objectDetailsText;

    void Start()
    {
        objectDetailsText.text = "";
    }

    public void UpdateDetails(string details)
    {
        // เพิ่ม \n เพื่อแบ่งข้อความเป็นสองบรรทัด
        objectDetailsText.text = details; 
    }
}
