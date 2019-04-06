using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : HighscoreManager
{

    public InputField inputField;
    /// <summary>
    /// sets the username string to the text inside the input field
    /// </summary>
    public void InputUsername()
    {
        if (inputField.text != "".ToString())
        {
            HighscoreManager.Username = inputField.text;
        }
    }
}
