using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*TODO: Check game manager for game over state maybe?*/
        if (manager.playerLives <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
