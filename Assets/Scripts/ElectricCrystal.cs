/*
 * Author: Muhammad Farhan
 * Date: 29/6/2024
 * Description: Script related the electric crystals
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCrystal : MonoBehaviour
{
    [SerializeField] private AudioClip hurtAudio;
    /// <summary>
    /// How much damage it does
    /// </summary>
    public float electricDamage = 20f;

    /// <summary>
    /// damage dealt per second
    /// </summary>
    public float electricRate = 1f;
    private bool playerInElectricZone = false;

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
            playerInElectricZone = true;
            if (gameManager != null)
            {
                InvokeRepeating("ApplyElectricDamage", 0f, 1f / electricRate);
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
            playerInElectricZone = false;
            if (gameManager != null)
            {
                CancelInvoke("ApplyElectricDamage");
                UIManager.instance.hideElectric();
            }
        }
    }

    /// <summary>
    /// damage is applied to player
    /// </summary>
    void ApplyElectricDamage()
    {
        if (playerInElectricZone && gameManager != null)
        {
            gameManager.TakeDamage(electricDamage * electricRate);

            if (hurtAudio != null)
            {
                AudioManager.instance.PlaySFX(hurtAudio, transform.position);
                UIManager.instance.showElectric();
            }
        }
    }
}
