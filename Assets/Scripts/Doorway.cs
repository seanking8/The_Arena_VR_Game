using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    public GameObject quiver;
    public GameObject quiverItem;

    // Check if player enters trigger and which door it is to perform necessary action
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "GolfDoor" && other.tag == "Player")
        {

        }
        else if (gameObject.tag == "ArcherDoor" && other.tag == "Player")
        {
        
        }
        else if (gameObject.tag == "BBallDoor" && other.tag == "Player")
        {

        }
        else if (gameObject.tag == "MenuDoor" && other.tag == "Player")
        {
            // Go back to Intro scene
            SceneManager.LoadScene(0);
        }
    }
}
