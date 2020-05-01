using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCount : MonoBehaviour
{
    public float ScoreValue = 0;
    int roundedscore;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreValue += Time.deltaTime;
        roundedscore = (int)ScoreValue;
        score.text = "Time Survived: " + roundedscore;
        
    }
}
