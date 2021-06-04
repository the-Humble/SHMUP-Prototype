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
    private int timer;

    private PlayerController player;

    public bool GameOver { get { return gameOver; } }

    public bool Victory { get { return victory; } }

    public int Timer { get { return timer; } set { timer = value; } }

    public int enemiesNeededToWin = 20;
    public int enemieskilled = 0;

    private bool invincibilityPUPflag = false;
    private bool speedPUPflag = false;
    private bool quickShotPUPflag = false;

    private Coroutine invincibiltyCoroutine;
    private Coroutine speedCoroutine;
    private Coroutine quickshotCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        lifeCount = playerLives;

        // Get player controller's component
        player = FindObjectOfType<PlayerController>();

        timer = timeCount;

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

        if(!gameOver && (playerLives <= 0 && livePlayer == null))
        {
            gameOver = true;
            Time.timeScale = 0;
            Score.ResetScore();
        }

        if(timer <= 0 && playerLives >= 0)
        {
            playerLives = -1;
            Destroy(livePlayer);
        }

        if (enemieskilled >= enemiesNeededToWin && !victory)
        {
            Score.AddScore(timer);
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
                    if (speedPUPflag) StopCoroutine(speedCoroutine);
                    else {
                        player.playerSpeed *=2;                    
                        player.speedUpFlag = true;
                    }
                    speedCoroutine = StartCoroutine(SpeedCoroutine(duration));
                }
                break;
            case 1:
                if (player != null)
                {
                    if (quickShotPUPflag) StopCoroutine(quickshotCoroutine);
                    else {
                        player.currentWeapon.fireCooldown -= 0.2f;
                        player.quickFireFlag  = true;
                    }
                    quickshotCoroutine =  StartCoroutine(QuickShotCoroutine(duration));
                }
                break;
            case 2:
                if(player != null)
                {
                    if (invincibilityPUPflag) StopCoroutine(invincibiltyCoroutine);
                    else player.invincibilityFlag = true;
                    invincibiltyCoroutine = StartCoroutine(InvincibilityCoroutine(duration));
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator InvincibilityCoroutine(float duration)
    {
        invincibilityPUPflag = true;


        while(duration > 0 && !respawning)
        {
            duration -= Time.deltaTime;
            
            yield return null;
        }

        if(player != null)
        {
            player.invincibilityFlag = false;
        }

        invincibilityPUPflag = false;
    }

    public IEnumerator SpeedCoroutine(float duration)
    {
        speedPUPflag = true;

        while (duration > 0 && !respawning)
        {
            duration -= Time.deltaTime;

            yield return null;
        }

        if (player != null)
        {
            player.playerSpeed /= 2;
        }

        speedPUPflag = false;
        player.speedUpFlag = false;
    }

    public IEnumerator QuickShotCoroutine(float duration)
    {
        quickShotPUPflag = true;

        while (duration > 0 && !respawning)
        {
            duration -= Time.deltaTime;

            yield return null;
        }

        if (player != null)
        {
            player.currentWeapon.fireCooldown += 0.2f;
        }

        quickShotPUPflag = false;
        player.quickFireFlag = false;
    }

    private IEnumerator timeCoroutine()
    {
        while(timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
    }
}
