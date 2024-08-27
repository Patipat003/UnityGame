using UnityEngine;

public class TabletMenuController : MonoBehaviour
{
    public GameObject tabletMenu; // ระบุ GameObject ของ UI Tablet Menu ที่ต้องการเปิด/ปิด
    public MonoBehaviour cameraController; // อ้างอิงถึงสคริปต์ที่ควบคุมกล้อง
    public MonoBehaviour playerController; // อ้างอิงถึงสคริปต์ที่ควบคุมผู้เล่น

    void Update()
    {
        // ตรวจสอบการกดปุ่ม tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTabletMenu();
        }
    }

    void ToggleTabletMenu()
    {
        // สลับสถานะการแสดง UI Tablet Menu
        bool isActive = !tabletMenu.activeSelf;
        tabletMenu.SetActive(isActive);

        // ปรับ Cursor.lockState เมื่อปิด Tablet Menu
        if (!isActive)
        {
            Cursor.lockState = CursorLockMode.Locked; // ล็อก cursor
            Cursor.visible = false; // ซ่อน cursor
            cameraController.enabled = true; // เปิดการทำงานของกล้อง
            playerController.enabled = true; // เปิดการทำงานของผู้เล่น
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // ปลดล็อก cursor
            Cursor.visible = true; // แสดง cursor
            cameraController.enabled = false; // ปิดการทำงานของกล้อง
            playerController.enabled = false; // ปิดการทำงานของผู้เล่น
        }
    }
}
