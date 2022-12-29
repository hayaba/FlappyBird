using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyingBird : MonoBehaviour
{
    public GameManager gameManager;

    public float velocity = 1f;
    private Rigidbody2D rb;

    public int score = 0;
    public int highestScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;

    public AudioClip crunchAudio;
    private AudioSource myAudioSource;
    public AudioClip deathAudio;

    private Vector3 lastAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        lastAcceleration = Input.acceleration;
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        scoreText = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextMeshProUGUI>();
        myAudioSource = GetComponent<AudioSource>();


        // Get the highest score from PlayerPrefs
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);

        // Set the current score to the highest score if it is higher
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighestScore", highestScore);
        }

        // Set the highest score text
        highestScoreText.text = "Highest Score: " +  highestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentAcceleration = Input.acceleration;
        Vector3 deltaAcceleration = lastAcceleration - currentAcceleration;
        lastAcceleration = currentAcceleration;

        float force = deltaAcceleration.magnitude;

        if (Input.GetMouseButtonDown(0) || force > 1.5f)
        {
            //Jump
            rb.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
        myAudioSource.PlayOneShot(deathAudio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;

        scoreText.SetText(score.ToString());
        myAudioSource.PlayOneShot(crunchAudio);

        // Update the highest score if the current score is higher
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighestScore", highestScore);
            highestScoreText.text = "Highest Score: " + highestScore.ToString();
        }
    }
}
