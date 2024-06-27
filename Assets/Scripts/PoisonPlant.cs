/*
 * Author: Muhammad Farhan
 * Date: 16/6/2024
 * Description: Script related the poison plants
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : MonoBehaviour
{
    /// <summary>
    /// How much damage it does
    /// </summary>
    public float poisonDamage = 10f;

    /// <summary>
    /// damage dealt per second
    /// </summary>
    public float poisonRate = 1f;
    private bool playerInPoisonZone = false;

    /// <summary>
    /// the player's health from the player script
    /// </summary>
    public GameManager gameManager;

    /// <summary>
    /// to access GameManager instance
    /// </summary>
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    /// <summary>
    /// plant damages player when in trigger
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInPoisonZone = true;
            if (gameManager != null)
            {
                InvokeRepeating("ApplyPoisonDamage", 0f, 1f / poisonRate);
                Debug.Log("You are taking damage!");
            }
        }
    }

    /// <summary>
    /// plant does not damage player when outside trigger
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInPoisonZone = false;
            if (gameManager != null)
            {
                CancelInvoke("ApplyPoisonDamage");
            }
        }
    }

    /// <summary>
    /// damage is applied to player
    /// </summary>
    void ApplyPoisonDamage()
    {
        if (playerInPoisonZone && gameManager != null)
        {
            gameManager.TakeDamage(poisonDamage * poisonRate);
        }
    }
}
