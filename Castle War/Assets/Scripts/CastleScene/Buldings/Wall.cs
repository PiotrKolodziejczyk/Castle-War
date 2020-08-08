﻿using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : Building
{
    private float timeToCheck = 5;

    public void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Wall.ToString(), this, castle.townHall);
    }
    private void Update()
    {
        ElapsedTimeAndBuild();
        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }
}

