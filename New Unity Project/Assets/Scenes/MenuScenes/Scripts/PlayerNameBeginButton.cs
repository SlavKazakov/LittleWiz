using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNameBeginButton : HighscoreManager
{
    /// <summary>
    /// on clicking the button will execute the ClickedButton method
    /// </summary>
    public Button Begin;
    void Start()
    {
        OpenConnection();
        Begin.onClick.AddListener(ClickedButton);
    }

    /// <summary>
    ///on button click goes to the Arena only if the Username is different than nothing
    /// </summary>
    void ClickedButton()
    {
        InsertScore(Username, 0);
        if (HighscoreManager.Username != "")
        {
            SceneManager.LoadScene("Arena");
        }
        
    }
}
