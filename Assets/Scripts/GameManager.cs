using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int currentScore = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    public void IncreaseScore(int scoreAdded)
    {
        currentScore += scoreAdded;
        scoreText.text = currentScore.ToString();
        Debug.Log(currentScore);
    }
}
