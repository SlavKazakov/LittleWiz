using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// sets the score of the database
/// </summary>
public class HighScoreScript : MonoBehaviour
{
    public GameObject score;
    public GameObject scoreName;

    public void SetScore(string name, string score)
    {
        this.scoreName.GetComponent<Text>().text = name;
        this.score.GetComponent<Text>().text = score;
    }
}
