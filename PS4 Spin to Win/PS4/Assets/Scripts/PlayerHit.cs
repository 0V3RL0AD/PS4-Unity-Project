using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;


public class PlayerHit : MonoBehaviour
{
    Color m_LightbarColour;
    public Movement move; 
    void OnCollisionEnter (Collision collided)
    {
        if (collided.collider.tag == "Obstacle")
        {
            move.enabled = false;
            FindObjectOfType<ManageGame>().GameFinished();
            PS4Input.PadSetVibration(0, 100, 100);
        }
    }
public void ChangeColour(Color controllerColour) 
    {
        //Sets the Colour
        m_LightbarColour = controllerColour;

        //Changes the Colour On Controller
        PS4Input.PadSetLightBar(0,
        Mathf.RoundToInt(m_LightbarColour.r * 255),
        Mathf.RoundToInt(m_LightbarColour.g * 0),
        Mathf.RoundToInt(m_LightbarColour.b * 0));
    }

}
