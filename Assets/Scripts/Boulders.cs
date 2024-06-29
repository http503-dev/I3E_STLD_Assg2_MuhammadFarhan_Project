/*
 * Author: Muhammad Farhan
 * Date: 23/6/2024
 * Description: Script related the player
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boulders : Interactable
{
    /// <summary>
    /// Sound of boulder breaking
    /// </summary>
    [SerializeField]
    private AudioClip destroyAudio;

    /// <summary>
    /// Flags if the boulder is destroyed
    /// </summary>
    bool destroyed = false;

    /// <summary>
    /// Destroy on hit 'e'
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        if (GameManager.instance.HasPick())
        {
            DestroyBoulder();

        }
        UIManager.instance.HideInteractPrompt();
    }

    /// <summary>
    /// trigger enter/exit to show/hide prompts
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bool hasPick = GameManager.instance.HasPick();

            if (hasPick)
            {
                UIManager.instance.ShowInteractPrompt("Hit 'E' to interact");
            }

            else
            {
                UIManager.instance.ShowWarningPrompt("You need a tool to break these boulders!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideInteractPrompt();
        UIManager.instance.HideWarningPrompt();
    }


    /// <summary>
    /// Handles the destruction
    /// </summary>
    private void DestroyBoulder()
    {
        if (!destroyed)
        {
            Destroy(gameObject);
            destroyed = true;
            if (destroyAudio != null)
            {
                AudioManager.instance.PlaySFX(destroyAudio, transform.position);
            }
        }
    }
}
