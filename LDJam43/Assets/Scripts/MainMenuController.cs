﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject lightning;

    public GameObject lightningSpawnPositionsHolder;
    private Vector2[] lightningSpawnPositions;

    public float timeBTWLightning;
    private float currentTimeBTWLightning;

    private void Awake()
    {
        currentTimeBTWLightning = 0;
        lightningSpawnPositions = new Vector2[lightningSpawnPositionsHolder.transform.childCount];

        for (int i = 0; i < lightningSpawnPositions.Length; i++)
        {
            lightningSpawnPositions[i] = lightningSpawnPositionsHolder.transform.GetChild(i).position;
        }

    }

    private void Update()
    {
        currentTimeBTWLightning -= Time.deltaTime;
        if(currentTimeBTWLightning < 0)
        {
            Vector2 randPos = lightningSpawnPositions[Random.Range(0, lightningSpawnPositions.Length)];
            Instantiate(lightning, randPos, Quaternion.identity);

            currentTimeBTWLightning = timeBTWLightning * Random.Range(0.6f, 1.2f);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //TODO : Play fade out animation
    }
}
