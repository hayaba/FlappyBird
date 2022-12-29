using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI highestScoreText;

    void Start()
    {
        UpdateHighScoreText();
    }

    public void LoadNewScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    void UpdateHighScoreText()
    {
        int highScore = PlayerPrefs.GetInt("HighestScore", 0);
        highestScoreText.text = "Highest Score: " + highScore.ToString();
    }
}
