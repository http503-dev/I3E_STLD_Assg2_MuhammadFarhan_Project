/*
 * Author: Muhammad Farhan
 * Date:28/6/2024
 * Description: Script related to the scraps collectible
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCollectible : Interactable
{
    /// <summary>
    /// collectible sound effect
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// count for biofuel pieces
    /// </summary>
    public static int scraps = 1;

    /// <summary>
    /// function for interacting with collectible
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.IncreaseScrap(scraps);
        Destroy(gameObject);
        if (collectAudio != null)
        {
            AudioManager.instance.PlaySFX(collectAudio, transform.position);
        }
        UIManager.instance.HideInteractPrompt();
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
    }
}
