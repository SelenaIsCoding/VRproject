using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Start()
    {
        Camera[] allCameras = FindObjectsOfType<Camera>(); // 获取所有摄像机
        foreach (Camera cam in allCameras)
        {
            if (cam.gameObject.name != "Main Camera") // 只保留 Main Camera
            {
                cam.gameObject.SetActive(false);
            }
        }
    }
}
