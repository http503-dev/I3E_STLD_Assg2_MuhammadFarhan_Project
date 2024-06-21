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
    /// sets checkpoint for player script
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                Collected(player);
            }
        }
    }

    /// <summary>
    /// plays sound cue when checkpoint reached
    /// </summary>
    /// <param name="thePlayer"></param>
    private void Collected(Player thePlayer)
    {
        if (collectAudio != null)
        {
            AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        }
        Debug.Log("Checkpoint set at position: " + transform.position);
    }

    /// <summary>
    /// interact from interacble script
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        thePlayer.SetCheckpoint(transform.position);
        Collected(thePlayer);
    }

}
