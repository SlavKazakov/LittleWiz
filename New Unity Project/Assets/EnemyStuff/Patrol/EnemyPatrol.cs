using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the enemy know as Normal Skeleton or EnemyPatrol.
/// </summary>
public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;

    public bool movingRight = true;

    public Transform AILocation;

    /// <summary>
    /// Void Flip checks if the bool movingRight is true or false and flips the enemy in regards to the bool.
    /// </summary>
    void Flip()
    {
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }

    /// <summary>
    /// Every frame void Update is called once.It moves the enemy to the right by default. 
    /// Also it checks if there is any ground in front of the enemy and if there isnt the method calls Flip.
    /// </summary>
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(AILocation.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            Flip();
        }
    }


    //enemy health and taking damage

    public int health = 100;
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
}

