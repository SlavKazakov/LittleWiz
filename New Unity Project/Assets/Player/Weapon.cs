using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A range weapon for the Player.
/// </summary>
public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;


    /// <summary>
    /// If you click the mouse the Player shoots.Every click of the mouse is a projectile.
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    /// <summary>
    /// Creates projectiles.The fire point can rotates and the Player has a fire position.
    /// </summary>
    void Shoot()
    {
        //shooting logic
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); 
    }
}
