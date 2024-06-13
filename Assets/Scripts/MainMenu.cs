/*
 * Author: Muhammad Farhan
 * Date: 13/6/2024
 * Description: Script related to the main menu
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Function to start game/go to main scene
    /// </summary>
    public void PlayButton ()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor

    }

    /// <summary>
    /// Function to quit the application
    /// </summary>
    public void QuitButton () 
    {
        Application.Quit();
    }
}
