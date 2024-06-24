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
    /// function to update interactable
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UpdatePlayerInteractable(collision.gameObject.GetComponent<Player>());
        }
    }

    /// <summary>
    /// function for removing interactable
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RemovePlayerInteractable(collision.gameObject.GetComponent<Player>());
        }
    }

    /// <summary>
    /// function for interacting with the repair station
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        if (GameManager.instance.HasCrystal() && GameManager.instance.GetScore() >= 2)
        {
            Debug.Log("You have successfully made the engine. Time to leave");
        }
        else
        {
            Debug.Log("You don't have all the items");
        }
    }
}
