﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int playerLives = 3;
    private int lifeCount;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject livePlayer;
    [SerializeField] private Vector2 spawnLocation;
    [SerializeField] public int timeCount = 300;

    private bool respawning = false;
    private bool gameOver = false;
    private bool victory = false;

    private PlayerController player;

    public bool GameOver { get { return gameOver; } }

    public bool Victory { get { return victory; } }

    public int enemiesNeededToWin = 20;
    public int enemieskilled = 0;


    // Start is called before the first frame update
    void Start()
    {
        lifeCount = playerLives;

        // Get player controller's component
        player = FindObjectOfType<PlayerController>();

        // Start Timer
        StartCoroutine(timeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(livePlayer == null && !respawning && playerLives > 0)
        {
            respawning = true;
            Invoke("RespawnPlayer", 2);
        }

        if(playerLives <= 0 && livePlayer == null && !gameOver)
        {
            Time.timeScale = 0;
            gameOver = true;
            Score.ResetScore();
        }

        if (enemieskilled >= enemiesNeededToWin && !victory)
        {
            Time.timeScale = 0;
            victory = true;
            Score.ResetScore();
        }
    }

    private void RespawnPlayer()
    {
        playerLives--;
        livePlayer = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
        player = livePlayer.GetComponent<PlayerController>();
        respawning = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spawnLocation, 1);
    }

    public void ApplyPowerUp(float duration, int option)
    {
        switch(option)
        {
            case 0:
                if (player != null)
                {
                    player.playerSpeed *=2;
                    StartCoroutine(SpeedCoroutine(duration));
                }
                break;
            case 1:
                if (player != null)
                {
                    player.currentWeapon.fireCooldown -= 0.2f;
                    StartCoroutine(QuickShotCoroutine(duration));
                }
                break;
            case 2:
                if(player != null)
                {
                    player.invincibilityFlag = true;
                    StartCoroutine(InvincibilityCoroutine(duration));
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator InvincibilityCoroutine(float duration)
    {
        while(duration > 0)
        {
            duration -= Time.deltaTime;
            
            yield return null;
        }

        if(player != null)
        {
            player.invincibilityFlag = false;
        }
    }

    public IEnumerator SpeedCoroutine(float duration)
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;

            yield return null;
        }

        if (player != null)
        {
            player.playerSpeed /= 2;
        }
    }

    public IEnumerator QuickShotCoroutine(float duration)
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;

            yield return null;
        }

        if (player != null)
        {
            player.currentWeapon.fireCooldown += 0.2f;
        }
    }

    private IEnumerator timeCoroutine()
    {
        while(timeCount > 0)
        {
            timeCount--;
            yield return new WaitForSeconds(1);
        }
    }
}
