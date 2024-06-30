/*
 * Author: Muhammad Farhan
 * Date: 30/6/2024
 * Description: Script related the ship door to access last area
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDoor : Interactable
{
    /// <summary>
    /// Sound of opening door
    /// </summary>
    [SerializeField]
    private AudioClip doorAudio;

    /// <summary>
    /// Flags if the door is opened
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Open on hit 'e'
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        if (GameManager.instance.HasEngine())
        {
            OpenDoor();
        }
        UIManager.instance.HideInteractPrompt();
    }

    /// <summary>
    /// trigger enter/exit to show/hide prompts
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bool hasPick = GameManager.instance.HasPick();

            if (hasPick)
            {
                UIManager.instance.ShowInteractPrompt("Hit 'E' to interact");
            }

            else
            {
                UIManager.instance.ShowWarningPrompt("Acquire a repaired engine to access your ship and escape!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideInteractPrompt();
        UIManager.instance.HideWarningPrompt();
    }


    /// <summary>
    /// Handles the opening of door
    /// </summary>
    private void OpenDoor()
    {
        if (!opened)
        {
            Destroy(gameObject);
            opened = true;
            if (doorAudio != null)
            {
                AudioManager.instance.PlaySFX(doorAudio, transform.position);
            }
        }
    }
}
