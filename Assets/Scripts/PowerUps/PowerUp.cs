using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpEnum
{
    SPEEDUP,
    RAPID_SHOOTING,
    INVINCIBILITY,

}

public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpEnum powerUpType;
    [SerializeField] float timeDuration;
    [SerializeField] float lifeTime;
    [SerializeField] float blinkLifeTime;
    [SerializeField] float blinkTime;

    private GameManager gManager;

    private void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            switch(powerUpType)
            {
                case PowerUpEnum.SPEEDUP:
                    gManager.ApplyPowerUp(timeDuration, 0);
                    break;
                case PowerUpEnum.RAPID_SHOOTING:
                    gManager.ApplyPowerUp(timeDuration, 1);
                    break;
                case PowerUpEnum.INVINCIBILITY:
                    gManager.ApplyPowerUp(timeDuration, 2);
                    break;
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        float counter = 0;

        while (counter <= blinkLifeTime)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(blinkTime);
            counter += blinkTime;
            gameObject.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(blinkTime);
            counter += blinkTime;
        }

        Destroy(gameObject);
        yield break;
    }


}
