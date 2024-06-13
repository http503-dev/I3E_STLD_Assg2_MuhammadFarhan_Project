/*
 * Author: Muhammad Farhan
 * Date: 13/6/2024
 * Description: Script related to the pause menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Bool to check if game is paused
    /// </summary>
    public static bool GameIsPaused = false;

    /// <summary>
    /// Reference to the Pause Menu UI
    /// </summary>
    public GameObject pauseMenuUI; 

    void Update()
    {
        // Check for the Escape key press to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Resumes the game from paused state
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the Pause Menu UI
        Time.timeScale = 1f; // Resume game time
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        GameIsPaused = false; // Update pause state
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the Pause Menu UI
        Time.timeScale = 0f; // Pause game time
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        GameIsPaused = true; // Update pause state
    }

    /// <summary>
    /// Restarts the current level
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f; // Resume game time
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    /// <summary>
    /// Loads the main menu
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume game time
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        SceneManager.LoadScene(0); // Load the main menu scene (ensure you have a scene named "MainMenu")
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
