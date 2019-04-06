using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonScript : HighscoreManager
{

    public Button DeleteButton;

    void Start()
    {
        OpenConnection();
        DeleteButton.onClick.AddListener(ClickedButton);
    }
    
    public void ClickedButton()
    {
        DeleteScore(DeletedName);
    }
}
