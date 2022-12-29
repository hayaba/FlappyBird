using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    private Vector3 lastAcceleration;

    // Start is called before the first frame update
    private void Start()
    {
        lastAcceleration = Input.acceleration;
        Time.timeScale = 1;
    }

    private void Update()
    {
        Vector3 currentAcceleration = Input.acceleration;
        Vector3 deltaAcceleration = lastAcceleration - currentAcceleration;
        lastAcceleration = currentAcceleration;

        float force = deltaAcceleration.magnitude;

        if (force > 1.0f && gameOverCanvas.activeSelf){
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
