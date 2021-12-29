using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelState 
{
    private static LevelState instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints { get{ return checkpoints; } }

    //This is actually a singleton
    public static LevelState Instance {
        get{
            if(instance == null){
                instance = new LevelState();
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("checkpoint"));
                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList();
            }
            return instance;
        }
    }
}
