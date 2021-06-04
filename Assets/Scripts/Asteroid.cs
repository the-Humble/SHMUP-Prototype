﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private PowerUp[] drops;
    [Range(0,1)][SerializeField] private float PUPDropChance = .5f;
    [SerializeField] private ParticleSystem deathPaticles;

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


            if ((float)Random.Range(0, 10) /10 <= PUPDropChance){
                var PUP = drops[Random.Range(0, drops.Length)];
                if (PUP)
                    Instantiate(PUP, transform.position, Quaternion.identity);
            }

            FindObjectOfType<GameManager>().enemieskilled++;

            if (deathPaticles)
            {
                var temp = Instantiate(deathPaticles, transform.position, Quaternion.identity);
                Destroy(temp, 2);
            }

            Destroy(this.gameObject);
        }
    }
}
