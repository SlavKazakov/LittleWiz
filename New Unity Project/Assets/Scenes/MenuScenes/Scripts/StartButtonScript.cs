using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonScript : HighscoreManager
{

    public Button StartButton;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        StartButton.onClick.AddListener(ClickedButton);
    }

    /// <summary>
    ///when the button is clicked it goest to the PlayerNameInput screen
    /// </summary>
    void ClickedButton()
    {
        SceneManager.LoadScene("PlayerNameInput");
    }
}
