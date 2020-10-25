using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private List<GameModule> gameModules = new List<GameModule>();

    private void Awake()
    {
        if (!Development.NewGame)
        {
            Initializing.Load("test");
        }

        foreach (var item in gameModules)
        {
            item.Initialize();
        }
    }
}
