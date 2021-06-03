using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int playerLives = 3;
    private int lifeCount;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject livePlayer;
    [SerializeField] private Vector2 spawnLocation;

    private bool respawning = false;
    private bool gameOver = false;

    private PlayerController player;

    public bool GameOver { get { return gameOver; } }

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

        // Get player
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(livePlayer == null && !respawning && playerLives > 0)
        {
            respawning = true;
            Invoke("RespawnPlayer", 2);
        }

        if(playerLives <= 0 && livePlayer == null)
        {
            gameOver = true;
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
                    else player.playerSpeed *=2;                    
                    speedCoroutine = StartCoroutine(SpeedCoroutine(duration));
                }
                break;
            case 1:
                if (player != null)
                {
                    if (quickShotPUPflag) StopCoroutine(quickshotCoroutine);
                    else player.currentWeapon.fireCooldown -= 0.2f;
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
    }
}
