using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // reloading the scene again

public class ManageGame : MonoBehaviour
{
    bool Ended = false;
    public float Delay = 1f;
    public GameObject FinishedLevel;
    
    public void GameFinished()
    {
        if (Ended == false)
        {
            Ended = true;
            Debug.Log("Game Over");
            Invoke("Restart", Delay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Completed()
    {
        FinishedLevel.SetActive(true);
    }
}
