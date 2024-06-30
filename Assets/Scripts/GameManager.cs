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
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// references the game manager
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// references the player
    /// </summary>
    private GameObject player;

    /// <summary>
    /// to get checkpoint positions
    /// </summary>
    public Vector3 lastCheckpoint;
    public Vector3 initialSpawn;

    /// <summary>
    /// indicates player's score and whether they have obtained the crystal and pickaxe
    /// </summary>
    private int currentScore = 0;
    private int scrapCount = 0;
    public bool hasCrystal = false;
    public bool hasPick = false;
    public bool hasEngine = false;

    /// <summary>
    /// player's health attributes
    /// </summary>
    public float maxHealth = 100f;
    private float currentHealth;

    /// <summary>
    /// ui stuff
    /// </summary>
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scrapText;
    public TextMeshProUGUI inventoryText;
    public Slider healthSlider;
    public GameObject deathScreenUI;
    public GameObject pauseMenuUI;
    public GameObject playerUI;

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
        currentHealth = maxHealth; // Initialize health here
    }

    /// <summary>
    /// to initialize player and load scene
    /// </summary>
    private void Start()
    {
        InitializePlayer();
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from scene loaded event
    }

    /// <summary>
    /// initialize player and ui after changing scenes
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializePlayer();
        UpdateHealthUI();
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    /// <summary>
    /// logic for initializing player
    /// </summary>
    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            return;
        }

        // Reapply the current health to the player
        UpdateHealthUI();
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    /// <summary>
    /// logic to update healthbar
    /// </summary>
    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }

    /// <summary>
    /// logic for taking damage
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    /// <summary>
    /// logic for setting checkpoints
    /// </summary>
    /// <param name="checkpointPosition"></param>
    public static void SetCheckpoint(Vector3 checkpointPosition)
    {
        if (instance != null)
        {
            instance.lastCheckpoint = checkpointPosition;
            instance.currentHealth = instance.maxHealth;
            instance.UpdateHealthUI();
        }
    }

    /// <summary>
    /// logic for respawning player
    /// </summary>
    public void Respawn()
    {
        if (player != null)
        {
            if (lastCheckpoint != null)
            {
                player.transform.position = initialSpawn;
            }
            else
            {
                player.transform.position = lastCheckpoint;
            }

            currentHealth = maxHealth;
            UpdateHealthUI();
            deathScreenUI.SetActive(false);
            playerUI.SetActive(true);
            Time.timeScale = 1f; // Resume the game
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Cursor.visible = false; // Hide the cursor
            player.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    /// <summary>
    /// logic for when player dies
    /// </summary>
    void Die()
    {
        if (deathScreenUI != null)
        {
            pauseMenuUI.SetActive(false);
            playerUI.SetActive(false);
            deathScreenUI.SetActive(true);
        }
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(player != null)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }

    /// <summary>
    /// Logic to load main menu
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    /// <summary>
    /// function to reset game on restart
    /// </summary>
    public void ResetGameState()
    {
        currentHealth = maxHealth;
        currentScore = 0;
        scoreText.text = "Biofuel Components: " + currentScore.ToString() + "/5";
        scrapCount = 0;
        scrapText.text = "Scrap Pieces: " + scrapCount.ToString() + "/5";
        hasPick = false;
        hasCrystal = false;
        hasEngine = false;
        inventoryText.text = "Inventory: ";

        lastCheckpoint = initialSpawn;
        player.transform.position = initialSpawn;
        UpdateHealthUI();
    }


    /// <summary>
    /// function for the biofuel collectible
    /// </summary>
    /// <param name="scoreAdded"></param>
    public void IncreaseScore(int scoreAdded)
    {
        currentScore += scoreAdded;
        scoreText.text = "Biofuel Components: " + currentScore.ToString() + "/5";
    }

    /// <summary>
    /// function for scrap count
    /// </summary>
    /// <param name="scrapAdded"></param>
    public void IncreaseScrap(int scrapAdded)
    {
        scrapCount += scrapAdded;
        scrapText.text = "Scrap Pieces: " + scrapCount.ToString() + "/5";
    }

    /// <summary>
    /// function to determine if player has pickaxe
    /// </summary>
    /// <param name="pickValue"></param>
    public void SetHasPick(bool pickValue) 
    {
        hasPick = pickValue;
        inventoryText.text += " Pickaxe"; 
    }

    /// <summary>
    /// function to determine if has crystal
    /// </summary>
    /// <param name="value"></param>
    public void SetHasCrystal(bool value)
    {
        hasCrystal = value;
        inventoryText.text += ", Crystal";
    }

    /// <summary>
    /// function to determine if has crystal
    /// </summary>
    /// <param name="value"></param>
    public void SetHasEngine(bool engineValue)
    {
        hasEngine = engineValue;
        scoreText.text = "Time to escape";
        scrapText.text = null;
        inventoryText.text = "Inventory: Pickaxe, Engine";
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
    /// function to return number of biofuel pieces
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return currentScore;
    }

    /// <summary>
    /// function to return number of scrap collected
    /// </summary>
    /// <returns></returns>
    public int GetScrap()
    {
        return scrapCount;
    }

    /// <summary>
    /// function to return bool value of pickaxe
    /// </summary>
    /// <returns></returns>
    public bool HasEngine()
    {
        return hasEngine;
    }
}
