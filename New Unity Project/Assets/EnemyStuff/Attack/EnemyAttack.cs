using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the enemy know as Blood Skeleton or EnemyAttack.
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    public float speed;

    private Transform target;

    public int health = 100;

    public Rigidbody2D rb;

    /// <summary>
    /// Void Start is called before the first frame update. It finds where the player is and stores its location in a variable.
    /// </summary>
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /// <summary>
    /// Every frame void Update is called once. It moves the enemy in correlation to the players position. 
    /// The enemy takes into account if there is an object and it either bumps into it or walks over it trying to get to the players position.
    /// </summary>
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (target.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-2, 2, 1);
        }

        if (transform.position.x > target.transform.position.x)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (target.transform.position.x > transform.position.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
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
}


