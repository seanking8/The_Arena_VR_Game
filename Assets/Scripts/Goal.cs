using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static int score;
    public AudioSource soundSource;
    public AudioClip clip;
    
    // Use Start for initialisation
    void start()
    {
        soundSource = GetComponent<AudioSource>();

        score = 0;
    }
    // Check is ball goes through hoop. Add score, play sound
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            score += 4;
            Debug.Log("bucket");
            soundSource.PlayOneShot(clip);
        }

    }

}
