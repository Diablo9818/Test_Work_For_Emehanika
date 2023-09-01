using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _restartButton;

    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private GameObject _finishPanel;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _loseText;
    [SerializeField] private Button _rebootButton;

    [SerializeField] private float _gameOverScreenShowTime;
    [SerializeField] private float _finishScreenShowTime;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    [SerializeField] private GameObject _gameBeginPanel;
    [SerializeField] private Button _startButton;

    private int _score;
    public bool isGameActive;

    private void Awake()
    {
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;

        if(_score < 0)
        {
            _score = 0;
        }

        _scoreText.text = "Score: " + _score;  
    }

     public void GameOver()
     {
        isGameActive = false;
        _losePanel.SetActive(true);
        _gameOverText.text = "    Game Over. \r\n  You Score is " + _score;
        _gameOverText.gameObject.SetActive(true);
        _scoreText.gameObject.SetActive(false);
     }

    public void StartGame()
    {
        isGameActive = true;
        _startButton.gameObject.SetActive(false);
        _gameBeginPanel.SetActive(false);
    }


}
