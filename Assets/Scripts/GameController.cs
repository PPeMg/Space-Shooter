using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int waveSize;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool endGame;

    void Start () {
        endGame = false;
        StartCoroutine(SpawnWaves());
	}
	
	IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(startWait);
        do
        {
            for (int i = 0; i < waveSize; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-1 * spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        } while (!endGame);
	}
}
