using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState{
    private static GameState instance;

    //this is actually a singleton
    public static GameState Instance {
        get{
            if(instance == null){
                instance = new GameState();
            }
            Debug.Log("Game Started!");
            return instance;
        }
    }
}
