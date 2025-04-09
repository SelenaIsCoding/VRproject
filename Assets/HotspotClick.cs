using UnityEngine;

public class HotspotClick : MonoBehaviour
{
    public Camera targetCamera; // 目标相机

    void Start()
    {
        if (targetCamera == null) // 自动查找相机，防止 NullReferenceException
        {
            Camera[] allCameras = FindObjectsOfType<Camera>();
            foreach (Camera cam in allCameras)
            {
                if (cam.gameObject.name == "Main Camera") // 这里可以改成你默认的 Camera 名称
                {
                    targetCamera = cam;
                    break;
                }
            }
        }
    }

    void OnMouseDown() // 当点击 Hotspot 时
    {
        Debug.Log("Hotspot clicked! Switching Camera...");

        if (targetCamera == null) // 确保 targetCamera 不是 null
        {
            Debug.LogError("❌ Error: targetCamera is NULL! Make sure to assign it in the Inspector.");
            return;
        }

        Camera[] allCameras = FindObjectsOfType<Camera>(); // 获取所有相机
        foreach (Camera cam in allCameras)
        {
            cam.gameObject.SetActive(false); // 先禁用所有相机
        }

        targetCamera.gameObject.SetActive(true); // 启用目标相机
    }
}
