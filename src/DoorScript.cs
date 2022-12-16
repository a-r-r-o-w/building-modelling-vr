using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
 
    private bool opened = false;
    private int posit = 0;
    private Animator anim;
    private bool on = false;


    void Update()
    {
        //This will tell if the player press F on the Keyboard. P.S. You can change the key if you want.
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
            PressedWindow();
            PressedWhiteboard();

            //Delete if you dont want Text in the Console saying that You Press F.
            Debug.Log("You Press F");
        }
    }
 
    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "Door")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                opened = !opened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("Opened", !opened);
            }
            if (doorhit.transform.tag == "Fan")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();

                //This will set the bool the opposite of what it is.
                on = !on;

                //This line will set the bool true so it will play the animation.
                anim.SetBool("On", !on);
            }
        }
    }

    void PressedWindow()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit windowhit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out windowhit, MaxDistance))
        {
            if (windowhit.transform.tag == "Window")
            {
                anim = windowhit.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                opened = !opened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("Opened", !opened);
            }
        }
    }

    void PressedWhiteboard()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit whitehit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out whitehit, MaxDistance))
        {
            if (whitehit.transform.tag == "Whiteboard")
            {
                anim = whitehit.transform.GetComponentInParent<Animator>();

               while(posit>=0 && posit<=2)
               {
                    
                    int posit = UnityEngine.Random.Range(0,3);
               }
 
                //This line will set the bool true so it will play the animation.
                anim.SetInteger("posit", posit);
            }
        }
    }
}