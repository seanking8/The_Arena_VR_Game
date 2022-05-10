using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hole : MonoBehaviour
{
    public float maxHoleDropOffset;
    private float stayTimer;
    public float maxStayTime;
    private bool hasDropped = false;
    public int maxScore;
    public int score;
    private AudioSource successSound;

    void Start ()
    {
        successSound = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GolfBall" && other.enabled)
        {


            GolfBall gBall = other.gameObject.GetComponent<GolfBall>();
            stayTimer += Time.deltaTime;

            Vector3 ballXYpos = new Vector3(other.transform.position.x, 0f, other.transform.position.z);
            Vector3 holeXYpos = new Vector3(transform.position.x, 0f, transform.position.z);
            if (Mathf.Abs(ballXYpos.x - holeXYpos.x) < maxHoleDropOffset &&
            Mathf.Abs(ballXYpos.y - holeXYpos.y) < maxHoleDropOffset &&
            (other.attachedRigidbody.velocity.magnitude < 1 || stayTimer >= maxStayTime))
            {
                if (!hasDropped)
                {
                    // Calculate score
                    score = maxScore - gBall.strokes;
                    if (score < 0)
                    {
                        score = 0;
                    }
                    Goal.score += score;

                    successSound.Play();
                    other.transform.position = transform.position;
                    other.attachedRigidbody.velocity = Vector3.zero;
                    other.gameObject.layer = 7;

                    Destroy(other.gameObject, 2f);
                    hasDropped = true;
                }
            }
        }
    }
}
