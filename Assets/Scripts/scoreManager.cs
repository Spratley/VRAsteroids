using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreManager : MonoBehaviour
{
    int score = 0;
    public TextMesh ScoreText;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }

    public void AddScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
    }
}

