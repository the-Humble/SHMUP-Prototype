using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private GameObject bar;
    private GameManager manager;

    private void Start() 
    {
        bar = GameObject.FindGameObjectWithTag("ProgressBar");
        manager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate() 
    {
        float scale = (float)manager.enemieskilled / (float)manager.enemiesNeededToWin;
        bar.transform.localScale = new Vector3(scale, 1, 1);
    }
}
