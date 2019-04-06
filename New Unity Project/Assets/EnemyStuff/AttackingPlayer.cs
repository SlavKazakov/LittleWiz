using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class checks if the projectile shot by Plant Monster/EnemyShoot collides with the player. 
/// If it does it subtracts the damage dealt by the enemy from the players health.
/// </summary>

public class AttackingPlayer : MonoBehaviour
{
    public int damageRanged;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeRangedDamage(damageRanged);
        }
    }
}
