using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public int strokes = 0;
    public AudioSource puttSound;
    public AudioSource bounceSound;

    // Check for collisions
    void OnCollisionEnter(Collision col)
    {
        // If putter hit ball, play sound and add a stroke to the player (for this ball)
        if (col.gameObject.name == "Putter")
        {
            if (!puttSound.isPlaying)
            {
                puttSound.Play();
            }

            strokes += 1;
            Debug.Log("stroke");
        }
        // If ball hit wall, play bounce sound
        else if (col.gameObject.name == "Arena" || col.gameObject.name == "GolfCourse")
        {
            if (!bounceSound.isPlaying)
            {
                bounceSound.Play();
            }
        }

    }
}
