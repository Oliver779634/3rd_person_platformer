using UnityEngine; 
 
public class CameraLook : MonoBehaviour 
{ 
    public float mouseSensitivity = 1000f; 
    public Transform playerCamera; 
    private float xRotation = 0f; 
    public bool invertMouseMode;


    void Update() 
    { 
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y"); 
 
        if (invertMouseMode) {

            mouseX = mouseX * -1;
        }
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime); 
 
        //xRotation -= mouseY * mouseSensitivity * Time.deltaTime; 
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
        //playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
    } 
} 