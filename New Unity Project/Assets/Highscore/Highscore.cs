using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// sets the highscore parameters
/// </summary>
public class Highscore : MonoBehaviour
{

     
    public int Scores { get; set;}
    public string Name { get; set; }
    public int Id { get; set; }

    public Highscore(int id,int score,string name)
    {
        this.Scores = score;
        this.Name = name;
        this.Id = id;
    }
}
