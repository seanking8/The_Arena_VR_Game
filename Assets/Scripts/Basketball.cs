using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    public AudioSource bounce;
    
    // Use Start for initialisation
    void Start()
    {
        bounce = GetComponent<AudioSource>();
    }

// Detect collisions, check tags and if sound is not playing, play bounce
    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.name == "Arena" || col.gameObject.name == "Hoop") && !bounce.isPlaying)
        {
            bounce.Play();
        }
    }
}
