/*
 * Author: Muhammad Farhan
 * Date: 23/6/2024
 * Description: Script related the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulders : Interactable
{
    /// <summary>
    /// Sound of boulder breaking
    /// </summary>
    [SerializeField]
    private AudioClip destroyAudio;

    /// <summary>
    /// Flags if the boulder is destroyed
    /// </summary>
    bool destroyed = false;

    /// <summary>
    /// Destroy on hit 'e'
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        if (GameManager.instance.HasPick())
        {
            DestroyBoulder();
        }
        else
        {
            Debug.Log("You need a pickaxe to destroy this boulder.");
        }
    }

    /// <summary>
    /// Handles the destruction
    /// </summary>
    private void DestroyBoulder()
    {
        if (!destroyed)
        {
            AudioSource.PlayClipAtPoint(destroyAudio, transform.position, 0.5f);
            Destroy(gameObject);
            destroyed = true;
        }
    }
}
