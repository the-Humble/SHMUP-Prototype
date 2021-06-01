using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>() != null)
        {
            // TODO: Check game state for enemy destroyed by projectile
            // Add to score
            Score.AddScore(scoreValue);

            FindObjectOfType<GameManager>().enemieskilled++;

            Destroy(this.gameObject);
        }
    }
}
