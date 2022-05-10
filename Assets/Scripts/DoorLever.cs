using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLever : MonoBehaviour
{
    private HingeJoint lever;
    private bool doorOpen;
    public float speed;
    private Vector3 closedPos;
    private Vector3 openPos;
    private Vector3 currentPos;
    public Transform target;
    public GameObject gate;
    private float curAngle;
    private float prevAngle;

    private AudioSource leverSound;
    private AudioSource gateSound;

    // Use Start for initialisation
    void Start()
    {
        lever = GetComponent<HingeJoint>();
        leverSound = GetComponent<AudioSource>();
        gateSound = gate.GetComponent<AudioSource>();
        doorOpen = false;

        openPos = target.position;
        closedPos = gate.transform.position;
        curAngle = lever.angle;
        prevAngle = lever.angle;
    }

    void FixedUpdate()
    {
        // Seek the gates position and levers position
        curAngle = lever.angle;
        currentPos = gate.transform.position;

        // Check if lever angle is increasing, play lever sound, move gate
        if ((curAngle > prevAngle) && curAngle < 50)
        {
            if (!leverSound.isPlaying)
            {
                leverSound.Play();
            }
            OpenSesame();
            prevAngle = curAngle;
        }
        // Check if lever angle is decreasing, play lever sound, move gate
        if ((curAngle < prevAngle) && curAngle > -50)
        {
            if (!leverSound.isPlaying)
            {
                leverSound.Play();
            }
            CloseDoor();
            prevAngle = curAngle;
        }
    }

    // Check if gate is fully opened. If not, keep moving it up and play sound
    void OpenSesame()
    {

        if (Vector3.Distance(currentPos, openPos) > 0.001f)
        {
            gate.transform.position = Vector3.MoveTowards(currentPos, openPos, speed);
            if (!gateSound.isPlaying)
            {
                gateSound.Play();
            }

        }
        else
        {
            //Gate is open
            doorOpen = true;
            Debug.Log("Open Sesame");

        }


    }

    // Check if gate is fully closed. If not, keep moving it down and play sound
    void CloseDoor()
    {

        if (Vector3.Distance(currentPos, closedPos) > 0.001f)
        {
            gate.transform.position = Vector3.MoveTowards(currentPos, closedPos, speed);
            if (!gateSound.isPlaying)
            {
                gateSound.Play();
            }
        }
        else
        {
            //Gate is closed
            doorOpen = false;
            Debug.Log("Close Sesame");

        }
    }
}
