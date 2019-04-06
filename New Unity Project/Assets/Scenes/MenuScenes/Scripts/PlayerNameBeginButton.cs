using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNameBeginButton : MonoBehaviour
{
    /// <summary>
    /// on clicking the button will execute the ClickedButton method
    /// </summary>
    public Button Begin;
    void Start()
    {
        Begin.onClick.AddListener(ClickedButton);
    }

    /// <summary>
    ///on button click goes to the Arena only if the Username is different than nothing
    /// </summary>
    void ClickedButton()
    {
        if (HighscoreManager.Username != "")
        {
            SceneManager.LoadScene("Arena");
        }
        
    }
}
