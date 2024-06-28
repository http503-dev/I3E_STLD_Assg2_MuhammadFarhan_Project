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

        Debug.Log($"RepairStation Interact - HasCrystal: {hasCrystal}, CurrentScore: {currentScore}, Scrap: {scrapCount}");

        if (hasCrystal && currentScore >= 2 && scrapCount >= 2)
        {
            hasEngine = true;
            GameManager.instance.SetHasEngine(hasEngine);
            if (collectAudio != null)
            {
                AudioManager.instance.PlaySFX(collectAudio, transform.position);
            }
            Debug.Log("You have made the engine! Time to leave!");
        }
        else
        {
            Debug.Log("You don't have all the items");
        }
    }
}
