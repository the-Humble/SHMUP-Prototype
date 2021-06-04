using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        victoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.Victory)
        {
            victoryScreen.SetActive(true);
        }
    }
}
