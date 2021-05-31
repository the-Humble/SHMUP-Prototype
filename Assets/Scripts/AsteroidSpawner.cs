using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject asteroid;
    [SerializeField] float spawnCooldown;
    [SerializeField] float offsetSpawner;

    private float spawnTimer;
    private float spawnHeight;
    private float lastSpawnHeight;

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            HeightRandomizer();

            GameObject.Instantiate(asteroid,
                new Vector3(spawnPoint.position.x, 
                spawnPoint.position.y + spawnHeight, 
                spawnPoint.position.z),
                Quaternion.identity);

            spawnTimer = spawnCooldown;
        }

        spawnTimer -= Time.deltaTime;
    }

    private void HeightRandomizer()
    {
        while (true)
        {
            spawnHeight = Random.Range(-4f, 4f);

            if (CheckNoSpawnLocationRepeat())
            {
                return;
            }
        }
    }

    private bool CheckNoSpawnLocationRepeat()
    {
        if (lastSpawnHeight <= (spawnHeight - offsetSpawner) 
            || lastSpawnHeight >= (spawnHeight + offsetSpawner))
        {
            lastSpawnHeight = spawnHeight;
            return true;
        }

        return false;
    }
}
