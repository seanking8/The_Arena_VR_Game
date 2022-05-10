using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed;
    private Vector3 a;
    private Vector3 b;
    private Vector3 c;
    private float timer = 0;
    public float timeLimit = 20f;
    public float halfway = 10f;

    // Start is called before the first frame update
    void Start()
    {
        c = startPos.position;

        b = endPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        a = transform.position;

        if (timer >= timeLimit)
        {
            reset();
        }
        else
        {
            timer += Time.deltaTime;
        }
        if (timer < halfway)
        {
            transform.position = Vector3.MoveTowards(a, b, speed * Time.deltaTime);
        }
        else if (timer > halfway)
        {
            transform.position = Vector3.MoveTowards(a, c, speed * Time.deltaTime);
        }
    }

    void reset()
    {
        timer = 0f;
    }
}
