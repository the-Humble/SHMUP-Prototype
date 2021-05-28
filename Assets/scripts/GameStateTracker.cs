using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : MonoBehaviour
{
    private static GameStateTracker instance;
    
    public static GameStateTracker Instance{
        get{
            if (instance == null){
                instance = FindObjectOfType<GameStateTracker>();
            }
            return instance;
        }
        set{}
    }

    public int enemiesNeededToWin = 20;
    public int enemieskilled = 0;
}
