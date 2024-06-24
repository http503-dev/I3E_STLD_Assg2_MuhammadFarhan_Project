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
    /// function for interacting with the repair station
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);

        bool hasCrystal = GameManager.instance.HasCrystal();
        int currentScore = GameManager.instance.GetScore();

        Debug.Log($"RepairStation Interact - HasCrystal: {hasCrystal}, CurrentScore: {currentScore}");

        if (hasCrystal && currentScore >= 2)
        {
            Debug.Log("You have successfully made the engine. Time to leave");
        }
        else
        {
            Debug.Log("You don't have all the items");
        }
    }
}
