using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public bool IsGameActive;
    public Button RestartButton;
    public GameObject TitleScreen;

    private float spawnRate = 1f;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        IsGameActive = false;
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        IsGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        TitleScreen.SetActive(false);
        spawnRate /= difficulty;
    }
}
