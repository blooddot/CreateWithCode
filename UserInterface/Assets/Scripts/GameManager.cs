using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public float spawnRate = 1.0f;
    public bool gameStarted;
    private int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject mainMenu;
    public GameObject gameOverUI;

    IEnumerator SpawnTarget()
    {
        while (gameStarted)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameIsOver()
    {
        gameStarted = false;
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        gameStarted = true;
        mainMenu.SetActive(false);
        spawnRate /= difficulty;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());

    }
}
