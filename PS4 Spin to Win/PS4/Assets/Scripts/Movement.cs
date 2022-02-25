using UnityEngine;
using UnityEngine.PS4;
using System;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody RigidB;

    public float force = 1000f;
    public float directionalf = 200f;
    private float Turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        

        if (PS4Input.PadIsConnected(0)) 
        {
            // Option Key...
            KeyCode Reset = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button7", true);

            if (Input.GetKey(Reset))
            {
                PS4Input.PadResetOrientation(0);
            }

            KeyCode Forward = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button0", true);
            if (Input.GetKey(Forward)) 
            {
                RigidB.AddForce(0, 0, force * Time.deltaTime); // adding force to the z axis 
            }
            KeyCode Reverse = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button1", true);
            if (Input.GetKey(Reverse))
            {
                RigidB.AddForce(0, 0, -force * Time.deltaTime); // adding force to the z axis 
            }
            Vector4 v = PS4Input.PadGetLastOrientation(0);
            Turn = v.z;
            if (v.z > 0.05f)
            {
                RigidB.AddForce(-directionalf * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }
            else if (v.z < -0.05f)
            {
                RigidB.AddForce(directionalf * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        //if (Input.GetKey("d"))
        //{
        //    RigidB.AddForce(directionalf * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        
        //if (Input.GetKey("a"))
        //{
        //    RigidB.AddForce(-directionalf * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}

        if(RigidB.position.y < -1f)
        {
            FindObjectOfType<ManageGame>().GameFinished();
        }

    }
}
