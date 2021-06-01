﻿using System.Collections;
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
        if (manager.GameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
