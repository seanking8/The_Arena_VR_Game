using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text Number;

    // Update is called once per frame
    void Update()
    {
        Number.text = Goal.score.ToString();
    }
}
