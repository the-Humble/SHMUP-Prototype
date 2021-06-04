using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        gManager = FindObjectOfType<GameManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        text.text = gManager.Timer.ToString();
    }
}

