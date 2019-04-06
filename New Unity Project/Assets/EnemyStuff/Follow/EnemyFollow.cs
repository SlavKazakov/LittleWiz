using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the enemy know as Ghost or EnemyFollow.
/// </summary>
public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;

    /// <summary>
    /// Void Start is called before the first frame update. It finds where the player is and stores its location in a variable.
    /// </summary>
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /// <summary>
    /// Every frame void Update is called once. It moves the enemy in correlation to the players position. 
    /// This code disregards any objects like platforms or the ground and just moves to the players position.
    /// </summary>
    void Update()
    {

        if (transform.position.x > target.transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (target.transform.position.x > transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

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
