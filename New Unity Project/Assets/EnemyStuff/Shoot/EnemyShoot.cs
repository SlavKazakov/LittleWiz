using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the enemy know as Plant Monster or EnemyShoot.
/// </summary>
public class EnemyShoot : MonoBehaviour
{

    public float num;

    private Transform target;
    public int health = 100;
    public GameObject projectile;

    private float timeBtwShots;
    public float startTimeBtwShots;

    /// <summary>
    /// Void Start is called before the first frame update. It finds where the player is and stores its location in a variable.
    /// </summary>
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    /// <summary>
    /// Every frame void Update is called once. It checks if the delay between the shots is 0 or less. 
    /// If it is the directive allows the enemy to shoot and it restarts the delay by setting it to the default. 
    /// If the delay is not 0 or less the method subtracts the delay by the passed time.
    /// </summary>
    void Update()
    {

        if (timeBtwShots <= 0)
        {
            Shoot();
            timeBtwShots = startTimeBtwShots;
            num = 20;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    /// <summary>
    /// Void TakeDamage subtracts the damage dealt by the player from the health that the enemy currently has.
    /// </summary>
    /// <param name="damage"></param>    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// Void Die is called when the health of the enemy reaches 0 or if it lower than that. It destroys the enemy and gives points to the player.
    /// </summary>

    void Die()
    {
        PlayerController.points = PlayerController.points + 10;
        Destroy(gameObject);
    }

    public Transform firePoint;
    /// <summary>
    /// Void Shoot sets the projectile that is going to be shot by the enemy its starting position and it stops the rotation of the shot projectile.
    /// </summary>
    void Shoot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
