/*
 * Author: Muhammad Farhan
 * Date: 24/6/2024
 * Description: Script related the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCrystal : Interactable
{
    /// <summary>
    /// sound when collected
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// bool for whether player has crystal
    /// </summary>
    public bool hasCrystal;

    /// <summary>
    /// function for collecting crystal
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
    /// function to remove interactable
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
    /// function for interacting with the crystal
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        hasCrystal = true;
        GameManager.instance.SetHasCrystal(hasCrystal);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        Debug.Log("Collected");
    }
}
