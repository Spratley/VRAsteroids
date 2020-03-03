using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    int score = 0;
    public Text ScoreText;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ScoreText.text);
        ScoreText.text = score.ToString();
    }

    public void AddScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
    }
}
