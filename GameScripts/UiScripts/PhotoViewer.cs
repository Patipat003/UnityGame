using UnityEngine;
using UnityEngine.UI;

public class PhotoViewer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseViewer();
        }
    }

    public void CloseViewer()
    {
        Destroy(gameObject);
    }
}
