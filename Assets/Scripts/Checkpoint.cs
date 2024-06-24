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
            AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        }
        Debug.Log("Checkpoint set at position: " + transform.position);
        thePlayer.SetCheckpoint(transform.position);
    }


}
