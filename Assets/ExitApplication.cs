using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    void Update()
    {
        // 按 ESC 退出
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
