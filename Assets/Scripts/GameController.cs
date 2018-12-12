using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Waves")]
    public GameObject hazard;
    public Vector3 spawnValues;
    public int waveSize;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    [Header("User Interface")]
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restartMode;
    private int score;

    void Start()
    {
        score = 0;
        gameOver = false;
        restartMode = false;

        restartText.gameObject.SetActive(restartMode);
        gameOverText.gameObject.SetActive(gameOver);
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restartMode && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        do
        {
            for (int i = 0; i < waveSize; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-1 * spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        } while (!gameOver);

        restartMode = true;
        restartText.gameObject.SetActive(restartMode);
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int pointsScored = 1)
    {
        this.score += pointsScored;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(gameOver);
    }
}
