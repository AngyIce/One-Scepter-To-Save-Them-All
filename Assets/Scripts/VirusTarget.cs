using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTarget : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            ScorePoints.scoreValue += 20;
        }

        void Die ()
        {
            Destroy(gameObject);           
        }

    }
 
}
