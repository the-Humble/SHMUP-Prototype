using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Mini : Asteroid
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // Add to score
        Score.AddScore(scoreValue);

        if ((float)Random.Range(0, 10) / 10 <= PUPDropChance)
        {
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
