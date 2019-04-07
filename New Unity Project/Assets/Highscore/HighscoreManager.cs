using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HighscoreManager : MonoBehaviour
{
    public static string Username;
    public static string DeletedName;
    public GameObject scorePrefab;

    private List<Highscore> highscores = new List<Highscore>();

    public string connectionString;

    public Transform scoreParent;
    
    public void Start()
    {
        OpenConnection();
        //connectionString = "URI=file:" + Application.dataPath + "/MyDatabaseScore.db";
        ShowScores();
    }

    /// <summary>
    /// Begins connection to the database
    /// </summary>
    public void OpenConnection()
    {
        connectionString = "URI=file:" + Application.dataPath + "/MyDatabaseScore.db";
    }

    /// <summary>
    /// Tries to update the database where the username is identical to the input if it doesnt succeed it
    /// inserts a row containing the player name and points
    /// </summary>
    public void MakeScore()
    {
        try
        {
            UpdateScores(Username,PlayerController.points);
        }
        catch
        {
            InsertScore(Username,PlayerController.points);
        }
    }
    /// <summary>
    /// Gets information from the database in the form of a list
    /// </summary>
    public void GetScores()
    {
        highscores.Clear();

        using (IDbConnection dbconnection = new SqliteConnection(connectionString))
        {
            dbconnection.Open();

            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string SqlQuery = "SELECT * FROM Highscore";

                dbCmd.CommandText = SqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highscores.Add(new Highscore(reader.GetInt32(2), reader.GetString(1)));
                    }
                    dbconnection.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Create function//Inserts Username and score into database
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    public void InsertScore(string name,int score)
    {
        using (IDbConnection dbconnection = new SqliteConnection(connectionString))
        {
            dbconnection.Open();
            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string SqlQuery = String.Format($"INSERT INTO Highscore(Username,score) Values('{name}','{score}');");

                dbCmd.CommandText = SqlQuery;

                dbCmd.ExecuteScalar();
                dbconnection.Close();
            }
        }
        
    }

    /// <summary>
    /// update function //updates scores where usernames match
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    public void UpdateScores(string name, int score)
    {
        using (IDbConnection dbconnection = new SqliteConnection(connectionString))
        {
            dbconnection.Open();

            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string SqlQuery = String.Format($"UPDATE Highscore SET score='{score}' WHERE Username='{name}'");

                dbCmd.CommandText = SqlQuery;

                dbCmd.ExecuteScalar();
                dbconnection.Close();
            }
        }

    }


    /// <summary>
    /// Delete function//Removes Users from the database based on their name
    /// </summary>
    /// <param name="name"></param>
    public void DeleteScore(string name)
    {
        using (IDbConnection dbconnection = new SqliteConnection(connectionString))
        {
            dbconnection.Open();

            using (IDbCommand dbCmd = dbconnection.CreateCommand())
            {
                string SqlQuery = String.Format($"DELETE FROM Highscore WHERE Username = '{name}'");

                dbCmd.CommandText = SqlQuery;

                dbCmd.ExecuteScalar();
                dbconnection.Close();
            }
        }
    }
    /// <summary>
    /// read function//for loop that writes out player scores on the board
    /// </summary>
    public void ShowScores()
    {
        GetScores();
        for (int i = 0; i < highscores.Count; i++)
        {
            GameObject tmpObjec = Instantiate(scorePrefab);

            Highscore tmpScore = highscores[i];

            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Scores.ToString());

            tmpObjec.transform.SetParent(scoreParent);

            tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
