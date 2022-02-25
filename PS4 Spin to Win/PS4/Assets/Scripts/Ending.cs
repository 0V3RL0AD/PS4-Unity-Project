using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public ManageGame gamemanage;
    void OnTriggerEnter()
    {
        gamemanage.Completed();
    }
    
}
