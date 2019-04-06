using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the projectile that the enemy shoots.
/// </summary>
public class ProjectileEnemy : MonoBehaviour
{
    public float speed = 5f;

    private Transform player;
    private Vector2 target;
    public float timer;
    public int damage = 40;
    public Rigidbody2D rb;
    public Transform EnemyAt;

    /// <summary>
    /// Void Start is called before the first frame update. 
    /// The method finds where the player is and where the EnemyShoot/Plant Monster is and stores their location in veriables.
    /// Also it finds where the starting position of the player is and stores it in a veriable.
    /// </summary>
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyAt = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Transform>();
        target = new Vector2(player.position.x, player.position.y);
    }

    /// <summary>
    /// Moves the projectile to the players position. When it reaches the set position the projectile gets destroyed.
    /// </summary>
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Checks if the projectile hits the player. 
    /// If there is collision between the two the projectile gets destroyed and the player takes damage.
    /// </summary>
    /// <param name="hitInfo"></param>
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeRangedDamage(damage);
            Destroy(gameObject);
        }
    }


}
