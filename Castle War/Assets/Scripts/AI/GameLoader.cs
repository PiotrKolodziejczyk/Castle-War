using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
   [SerializeField] List<GameModule> gameModules= new List<GameModule>();
    void Awake()
    {
        foreach(var item in gameModules)
        {
            item.Initialize();
        }
    }

    
}
