using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private int score; // 현재 점수
    [SerializeField] private float moveSpeed; // 현재 속도
    private bool isGameOver;

    void Awake() {
        score = 0;
        moveSpeed = 5f;
        isGameOver = false;

        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void AddScore() {
        score++;

        if (score % 5 == 0) { // 5개 마다
            SpeedUp();

            ObstacleSpawner obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
            if(obstacleSpawner != null) {
                obstacleSpawner.DereaseInterval();
            }
        }
    }

    public int GetScore() {
        return score;
    }

    private void SpeedUp() {
        moveSpeed += 2f;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public void GameOver() {
        isGameOver = true;

        ObstacleSpawner obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        if(obstacleSpawner != null) {
            obstacleSpawner.StopSpawn();
        }

        StartCoroutine(ShowGameOverPanel());
    }

    public bool GetGameOver() {
        return isGameOver;
    }

    IEnumerator ShowGameOverPanel() {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene("Scenes/MenuScene");
    }
}
