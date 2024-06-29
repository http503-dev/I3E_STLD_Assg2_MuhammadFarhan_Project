/*
 * Author: Muhammad Farhan
 * Date: 24/6/2024
 * Description: Script related the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStation : Interactable
{
    /// <summary>
    /// sound when collected
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// bool for whether player has engine
    /// </summary>
    public bool hasEngine;

    /// <summary>
    /// function for interacting with the repair station
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        bool hasCrystal = GameManager.instance.HasCrystal();
        int currentScore = GameManager.instance.GetScore();
        int scrapCount = GameManager.instance.GetScrap();

        if (hasCrystal && currentScore >= 2 && scrapCount >= 2)
        {
            hasEngine = true;
            GameManager.instance.SetHasEngine(hasEngine);
            if (collectAudio != null)
            {
                AudioManager.instance.PlaySFX(collectAudio, transform.position);
            }
            UIManager.instance.ShowSuccessPrompt("Engine made. Time to leave!");
        }
        else
        {
            UIManager.instance.ShowWarningPrompt("You have not collected all the required parts!");
        }
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
        UIManager.instance.HideWarningPrompt();
        UIManager.instance.HideSuccessPrompt();
    }
}
