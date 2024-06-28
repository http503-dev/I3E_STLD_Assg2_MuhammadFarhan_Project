/*
 * Author: Muhammad Farhan
 * Date: 15/6/2024
 * Description: Script related to the biofuel collectible
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    /// <summary>
    /// collectible sound effect
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// count for biofuel pieces
    /// </summary>
    public static int score = 1;

    /// <summary>
    /// function for interacting with collectible
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.IncreaseScore(score);
        Destroy(gameObject);
        if (collectAudio != null)
        {
            AudioManager.instance.PlaySFX(collectAudio, transform.position);
        }
        Debug.Log("Collected");
    }

}
