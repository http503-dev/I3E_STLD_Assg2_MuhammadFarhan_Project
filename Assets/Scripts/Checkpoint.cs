/*
 * Author: Muhammad Farhan
 * Date: 18/6/2024
 * Description: Script related checkpoints
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Checkpoint : Interactable
{
    /// <summary>
    /// to set audio when checkpoint reached
    /// </summary>
    [SerializeField] private AudioClip collectAudio;

    /// <summary>
    /// sets checkpoint for player script and plays audio
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        if (collectAudio != null)
        {
            AudioManager.instance.PlaySFX(collectAudio, transform.position);
        }
        UIManager.instance.ShowSuccessPrompt("Checkpoint set. Health restored!");
        GameManager.SetCheckpoint(transform.position);
    }

    /// <summary>
    /// trigger enter/exit to show/hide prompts
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        UIManager.instance.ShowInteractPrompt("Hit 'E' to interact");
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideInteractPrompt();
        UIManager.instance.HideSuccessPrompt();
    }
}
