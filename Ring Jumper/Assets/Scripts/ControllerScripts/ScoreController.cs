using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    public Text scoreText;
    private int score;

    void Awake()
    {
        MakeSingleton();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (!scoreText)
                scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

            scoreText.text = score.ToString();
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
