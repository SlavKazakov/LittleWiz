using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The camera follows the Player.
/// </summary>
public class PlayerFollow : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    /// <summary>
    /// Calculates and stores the offset value by getting the distance between the player's position and camera's position.
    /// </summary>
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    /// <summary>
    /// LateUpdate is called after Update each frame and sets the position of the camera's transformation to be the same as the player's, but is offset by the calculated offset distance.
    /// </summary>
void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
