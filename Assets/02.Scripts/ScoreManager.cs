using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text currentScoreUI;
    private int _currentScore;
    
    public Text bestScoreUI;
    private int _bestScore;

    public int Score
    {
        get
        {
            return _currentScore;
        }
        set
        {
            _currentScore = value;
            currentScoreUI.text = "현재점수 : " + _currentScore;
            
            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
                bestScoreUI.text = "최고점수 : " + _bestScore;
                PlayerPrefs.SetInt("Best Score", _bestScore);
            }    
        }
    }
    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고점수 : " + _bestScore;
    }
}
