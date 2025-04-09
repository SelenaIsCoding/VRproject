using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.0f;  // 鼠标灵敏度
    public float keyboardSensitivity = 50f;  // 键盘灵敏度

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        // 鼠标控制视角
        // rotationX += Input.GetAxis("Mouse X") * sensitivity;
        // rotationY -= Input.GetAxis("Mouse Y") * sensitivity;

        // 键盘控制视角 (方向键 & WASD)
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rotationX -= keyboardSensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rotationX += keyboardSensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rotationY -= keyboardSensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rotationY += keyboardSensitivity * Time.deltaTime;
        }

        // 限制视角上下旋转范围，防止翻转
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // 应用旋转
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
