using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] protected int scoreValue = 10;
    [SerializeField] protected PowerUp[] drops;
    [SerializeField] private GameObject miniAsteroid;
    [Range(0,1)][SerializeField] protected float PUPDropChance = .5f;
    [SerializeField] protected ParticleSystem deathPaticles;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>() != null)
        {
            // Add to score
            Score.AddScore(scoreValue);

            /*if ((float)Random.Range(0, 10) /10 <= PUPDropChance){
                var PUP = drops[Random.Range(0, drops.Length)];
                if (PUP)
                    Instantiate(PUP, transform.position, Quaternion.identity);
            }*/

            FindObjectOfType<GameManager>().enemieskilled++;

            if (deathPaticles)
            {
                var temp = Instantiate(deathPaticles, transform.position, Quaternion.identity);
                Destroy(temp, 2);
            }

            Instantiate(miniAsteroid, transform.position, Quaternion.identity);
            Instantiate(miniAsteroid, transform.position, Quaternion.identity);
            Instantiate(miniAsteroid, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
