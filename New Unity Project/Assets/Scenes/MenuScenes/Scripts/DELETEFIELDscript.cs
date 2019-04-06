using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DELETEFIELDscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public InputField inputField;

    public void InputedUsername()
    {
        if (inputField.text != "")
        {
            HighscoreManager.DeletedName=inputField.text;
        }
    }
}
