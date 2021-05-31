using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(/*TODO: Place projectile differentiator here*/ true)
        {
            // TODO: Check game state for enemy destroyed by projectile
            Destroy(this.gameObject);
        }
    }
}
