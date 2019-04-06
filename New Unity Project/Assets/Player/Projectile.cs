using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the projectile that the player shoots.
/// </summary>
public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float timer;
    public int damage = 40;

    /// <summary>
    /// Moves the projectile the way that the player shoots it.
    /// </summary>
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    /// Checks if the projectile has been in the air for 1.2 sec andif it has it disappears.
    /// </summary>
    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= 1.2)
        {
            GameObject.Destroy(gameObject);
        }
    }

    /// <summary>
    /// Checks if the projectile hits one of the enemies. 
    /// If there is collision between the two the projectile gets destroyed and the enemy takes damage.
    /// </summary>
    /// <param name="hitInfo"></param>
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyPatrol enemy = hitInfo.GetComponent<EnemyPatrol>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);

        EnemyFollow enemy1 = hitInfo.GetComponent<EnemyFollow>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
        }

        Destroy(gameObject);

        EnemyAttack enemy2 = hitInfo.GetComponent<EnemyAttack>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }

        Destroy(gameObject);

        EnemyShoot enemy3 = hitInfo.GetComponent<EnemyShoot>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
