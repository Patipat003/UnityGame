using UnityEngine;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
    Camera camera;
    public float defaultFOV = 60;
    public float maxZoomFOV = 15;
    public float zoomSpeed = 1.0f; // ความเร็วในการซูม
    public float targetZoom = 0.4f; // ค่าซูมที่เราต้องการ
    private bool isZooming = false;
    private bool isZoomingIn = false;
    private bool isZoomingOut = false;

    void Awake()
    {
        // เรียกใช้กล้องใน gameObject นี้ และค่า FOV ที่เริ่มต้น
        camera = GetComponent<Camera>();
        if (camera)
        {
            defaultFOV = camera.fieldOfView;
        }
    }

    void Update()
    {
        // ตรวจสอบการคลิกขวา
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZooming)
            {
                isZoomingIn = true;
            }
            else
            {
                isZoomingOut = true;
            }
        }

        // ซูมเข้าหรือซูมออก
        if (isZoomingIn)
        {
            float zoomDelta = Mathf.Abs(defaultFOV - maxZoomFOV) * Time.deltaTime * zoomSpeed;
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - zoomDelta, maxZoomFOV, defaultFOV);
            if (camera.fieldOfView <= maxZoomFOV)
            {
                isZoomingIn = false;
                isZooming = true;
            }
        }
        else if (isZoomingOut)
        {
            float zoomDelta = Mathf.Abs(defaultFOV - maxZoomFOV) * Time.deltaTime * zoomSpeed;
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + zoomDelta, maxZoomFOV, defaultFOV);
            if (camera.fieldOfView >= defaultFOV)
            {
                isZoomingOut = false;
                isZooming = false;
            }
        }
    }
}
