/*
 * Author: Muhammad Farhan
 * Date: 20/6/2024
 * Description: Script related the game manager (score for now)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// references the game manager
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// player's score
    /// </summary>
    private int currentScore = 0;

    public bool hasCrystal = false;

    public bool hasPick = false;

    /// <summary>
    /// score text
    /// </summary>
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

    /// <summary>
    /// function for the biofuel collectible
    /// </summary>
    /// <param name="scoreAdded"></param>
    public void IncreaseScore(int scoreAdded)
    {
        currentScore += scoreAdded;
        scoreText.text = currentScore.ToString();
        Debug.Log(currentScore);
        if (currentScore == 2) // checks if player has collected all biofuel
        {
            Debug.Log("You have collected all the biofuel needed!");    
        }
    }

    /// <summary>
    /// function to determine if player has pickaxe
    /// </summary>
    /// <param name="pickValue"></param>
    public void SetHasPick(bool pickValue) 
    {
        hasPick = pickValue;
        Debug.Log("You have collected the pickaxe");
    }

    /// <summary>
    /// function to determine if has crystal
    /// </summary>
    /// <param name="value"></param>
    public void SetHasCrystal(bool value)
    {
        hasCrystal = value;
        Debug.Log("You have collected the crystal");
    }

    /// <summary>
    /// function to return bool value of crystal
    /// </summary>
    /// <returns></returns>
    public bool HasCrystal()
    {
        return hasCrystal;
    }

    /// <summary>
    /// function to return bool value of pickaxe
    /// </summary>
    /// <returns></returns>
    public bool HasPick()
    {
        return hasPick;
    }

    /// <summary>
    /// function to return bool value of crystal
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return currentScore;
    }
}
