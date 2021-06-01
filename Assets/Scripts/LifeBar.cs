using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeBar : MonoBehaviour
{
    private GameManager manager;
    [SerializeField] private TextMeshProUGUI text;
    

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager)
            text.text = "x" + manager.playerLives;
        else Debug.Log("no Manager");
    }
}