﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;

	void Start () {
        SpawnWaves();
	}
	
	void SpawnWaves () {
        Vector3 spawnPosition = new Vector3(Random.Range(-1 * spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawnPosition, Quaternion.identity);
	}
}
