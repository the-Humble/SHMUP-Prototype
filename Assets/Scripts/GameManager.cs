using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    private int lifeCount;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject livePlayer;
    [SerializeField] private Vector2 spawnLocation;

    private bool respawning = false;


    // Start is called before the first frame update
    void Start()
    {
        lifeCount = playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        if(livePlayer == null && !respawning && playerLives > 0)
        {
            respawning = true;
            Invoke("RespawnPlayer", 2);
        }

        if(playerLives < 0)
        {
            Debug.Log("Game Over");
            //Game Over
        }
    }

    private void RespawnPlayer()
    {
        playerLives--;
        livePlayer = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
        respawning = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spawnLocation, 1);
    }
}
