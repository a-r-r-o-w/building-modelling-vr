using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   [SerializeField] private float mouseSensitivity = 3f;
   private PlayerMotor motor;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        motor = GetComponent<PlayerMotor>();
   }
   void Update() {
    // Calculate movement velocity as 3d vector 
    float xMov = Input.GetAxisRaw("Horizontal");
    float zMov = Input.GetAxisRaw("Vertical");

    Vector3 movHorizontal = transform.right * xMov; //(1,0,0) to (-1,0,0) is the range of the calculation for movement
    Vector3 movVertical = transform.forward * zMov; //(0,0,1)
    //final movement vector 
    Vector3 _velocity = (movHorizontal + movVertical).normalized * speed;

    //applying movement 
    motor.Move(_velocity);


    // Calculating rotation as a 3d Vector (turing around) : 
    float yRot = Input.GetAxisRaw("Mouse X");
    Vector3 _rotation = new Vector3(0,yRot,0) * mouseSensitivity;
    

    // Apply rotation for the player
    motor.Rotate(_rotation);

    float xRot = Input.GetAxis("Mouse Y");
    xRot = Mathf.Clamp(xRot, -90.0f, 90.0f);
    Vector3 _cameraRotation =  new Vector3(xRot,0,0) * mouseSensitivity;

    motor.RotateCamera(_cameraRotation);
   }


}




