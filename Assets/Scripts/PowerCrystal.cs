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
