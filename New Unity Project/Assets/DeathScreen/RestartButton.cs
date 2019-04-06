using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        PlayerController.points = 0;
        SceneManager.LoadScene("Arena");
    }
}
