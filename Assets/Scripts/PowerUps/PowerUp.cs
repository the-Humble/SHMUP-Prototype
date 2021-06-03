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

    private GameManager gManager;

    private void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
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


}
