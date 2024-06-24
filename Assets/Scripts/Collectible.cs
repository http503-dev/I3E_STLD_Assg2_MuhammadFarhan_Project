/*
 * Author: Muhammad Farhan
 * Date: 15/6/2024
 * Description: Script related to the collectible
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
    /// to update player interactable
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
    /// function for collecting biofuel
    /// </summary>
    /// <param name="thePlayer"></param>
    public virtual void Collected(Player thePlayer)
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        Debug.Log("Collected");
    }

    /// <summary>
    /// to remove the collectible 
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
    /// function for interacting with collectible
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.IncreaseScore(score);
        Destroy(gameObject);
        Collected(thePlayer);
    }

}
