/*
 * Author: Muhammad Farhan
 * Date: 16/6/2024
 * Description: Script related the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    /// references interactable from interactable class
    /// </summary>
    Interactable currentInteractable;

    /// <summary>
    /// to access player camera's transform position
    /// </summary>
    [SerializeField] Transform playerCamera;

    /// <summary>
    /// to set intearaction distance
    /// </summary>
    [SerializeField] float interactionDistance;

    /// <summary>
    /// to update interactable
    /// </summary>
    /// <param name="newInteractable"></param>
    public void UpdateInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }

    /// <summary>
    /// for hitting 'e' to interact
    /// </summary>
    void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this);
        }
    }

    /// <summary>
    /// to draw raycast line
    /// </summary>
    void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
    }

    /// <summary>
    /// players max health
    /// </summary>
    public float maxHealth = 100f;

    /// <summary>
    /// players current health
    /// </summary>
    private float currentHealth;

    /// <summary>
    /// to reference health bar ui
    /// </summary>
    public Slider healthSlider;

    /// <summary>
    /// to reference death screen ui
    /// </summary>
    public GameObject deathScreenUI;

    /// <summary>
    /// to access last checkpoint position
    /// </summary>
    public Vector3 lastCheckpoint;

    /// <summary>
    /// to set health and checkpoint position when character first spawns
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        // Initialize the checkpoint at the starting position or wherever it was last set
        if (lastCheckpoint == Vector3.zero)
        {
            lastCheckpoint = transform.position;
        }
        deathScreenUI.SetActive(false); // Ensure the death screen is hidden at the start
    }

    /// <summary>
    /// to update health bar ui when damage taken
    /// </summary>
    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    /// <summary>
    /// to update health when damage taken and what happens when the character reaches 0 health
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
    /// to set checkpoint from checkpoint script
    /// </summary>
    /// <param name="checkpointPosition"></param>
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
        Debug.Log("Checkpoint set at: " + lastCheckpoint);
    }

    /// <summary>
    /// what happens when character dies
    /// </summary>
    void Die()
    {
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Player has died.");
    }

    /// <summary>
    /// respawn logic THAT DOES NOT WORK
    /// </summary>
    public void Respawn()
    {
        // Log respawn attempt
        Debug.Log("Respawn called. Moving player to last checkpoint: " + lastCheckpoint);

        // Reset player position and Rigidbody physics
        transform.position = lastCheckpoint;
        Debug.Log("Transform position set to: " + transform.position);

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Temporarily remove constraints to allow movement
            rb.constraints = RigidbodyConstraints.None;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Set Rigidbody position and sync transform
            rb.position = lastCheckpoint;
            Debug.Log("Rigidbody position set to: " + rb.position);

            rb.MovePosition(lastCheckpoint);
            Debug.Log("Sync transform position with Rigidbody: " + transform.position);

            // Restore constraints
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        // Ensure the player camera moves with the player
        if (playerCamera != null)
        {
            playerCamera.position = transform.position + new Vector3(0, 1.6f, 0); // Adjust the offset as needed
            Debug.Log("Camera moved to: " + playerCamera.position);
        }

        currentHealth = maxHealth;
        UpdateHealthUI();
        deathScreenUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        Debug.Log("Respawned at: " + lastCheckpoint);
    }

    /// <summary>
    /// to load main menu from death screen ui
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
