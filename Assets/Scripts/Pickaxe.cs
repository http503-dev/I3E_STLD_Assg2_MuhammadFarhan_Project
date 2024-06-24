/*
 * Author: Muhammad Farhan
 * Date: 23/6/2024
 * Description: Script related the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Pickaxe : Interactable
{
    /// <summary>
    /// The door that this key card unlocks
    /// </summary>
    public Boulders linkedBoulder;

    /// <summary>
    /// sound for picking up pickaxe
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// bool to determine whether pickaxe has been collected
    /// </summary>
    bool hasPick = false;

    /// <summary>
    /// function to collect pickaxe
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UpdatePlayerInteractable(collision.gameObject.GetComponent<Player>());
            linkedBoulder.SetPick(false);
        }
    }

    /// <summary>
    /// function to remove pickaxe
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
    /// function for what happens on intereacting
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        hasPick = true;
        GameManager.instance.SetHasPick(hasPick);
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        Debug.Log("Collected");
        Destroy(gameObject);
    }

    private void Start()
    {
        // Check if there is a linked boulder
        if (linkedBoulder != null)
        {
            // destroy the boulder that is linked
            linkedBoulder.SetPick(true);
        }
    }
}
