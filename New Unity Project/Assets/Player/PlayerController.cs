using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controls the game object aka.  Player.
/// </summary>
public class PlayerController : HighscoreManager
{
    public float speed;
    public float jumpForce;
    private float moveInput; //detect keys

    private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    
    public GameObject gameOverText, restartButton;

    public float damage;

    public int health;

    //points
    public static int points=0;

    /// <summary>
    /// Gives the player a double jump in the start of game.
    /// </summary>
    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }


    /// <summary>
    /// Checks if the player is on the ground, gives left and right rotation of the player plus gives movement to the player=
    /// </summary>
    private void FixedUpdate()
    {

        //Checks to see if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        //player movement
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);

        //flipping character left and right
        if(facingRight==false && moveInput > 0)
        {
            Flip();
        }else if(facingRight==true && moveInput < 0)
        {
            Flip();
        }
        if (rb.position.y <= -6f)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }


    
    public Animator animator;


    /// <summary>
    /// Test the ground and if the ground exist give a double jump and a precise button for jump if the player jumps nulls one the jumps so the player can't always jump.
    /// </summary>
    //jumping and extra jumps
    void Update()
    {

        if (isGrounded == true)
        {
            OnLanding();
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            animator.SetBool("IsJumping", true);

            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded==true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    /// <summary>
    /// Gives the player a exact face rotation to left.
    /// </summary>
    void Flip()
    {
        facingRight =! facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// Destroys the enemies when their health drops to zero or below. The method detects the enemeis and if Player collides with the enemies he is being destroyed.
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {

        

        EnemyAttack enemyAttack = collision.collider.GetComponent<EnemyAttack>();
        EnemyFollow enemyFollow = collision.collider.GetComponent<EnemyFollow>();
        EnemyPatrol enemyPatrol = collision.collider.GetComponent<EnemyPatrol>();
        EnemyShoot enemyShoot = collision.collider.GetComponent<EnemyShoot>();
        
        if (health <= 0 || enemyPatrol != null || enemyAttack != null || enemyFollow != null || enemyShoot != null) 
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    /// <summary>
    /// The only damege the Player can take is range damage and if the player's health drops to zero the player dies.
    /// </summary>
    /// <param name="damageRanged"></param>
    public void TakeRangedDamage(int damageRanged)
    {
        health -= damageRanged;
        if (health <= 0 )
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }   
    
}
