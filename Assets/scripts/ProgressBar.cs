using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private GameObject bar;

    private void Start() 
    {
        bar = GameObject.FindGameObjectWithTag("ProgressBar");
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("space");
            GameStateTracker.Instance.enemieskilled++;
        }

        float scale = (float)GameStateTracker.Instance.enemieskilled / (float)GameStateTracker.Instance.enemiesNeededToWin;
        bar.transform.localScale = new Vector3(scale, 1, 1);
    }
}
