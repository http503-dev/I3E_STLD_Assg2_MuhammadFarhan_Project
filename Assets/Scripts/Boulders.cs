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
    /// Flags if the boulder can be destroyed
    /// </summary>
    bool canDestroy = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the obejct entering the trigger has the "Player" tag
        if (other.gameObject.tag == "Player" && !destroyed)
        {
            UpdatePlayerInteractable(other.gameObject.GetComponent<Player>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the obejct exiting the trigger has the "Player" tag
        if (other.gameObject.tag == "Player")
        {
            RemovePlayerInteractable(other.gameObject.GetComponent<Player>());
        }
    }

    /// <summary>
    /// Destroy on hit 'e'
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        Destroy();
    }

    /// <summary>
    /// Handles the destruction
    /// </summary>
    public void Destroy()
    {
        if (!canDestroy)
        {
            AudioSource.PlayClipAtPoint(destroyAudio, transform.position, 0.5f);
            Destroy(gameObject);
            destroyed = true;
        }
    }

    /// <summary>
    /// Sets the lock status of the door.
    /// </summary>
    /// <param name="pickStatus">The lock status of the door</param>
    public void SetPick(bool pickStatus)
    {
        // Assign the lockStatus value to the locked bool.
        canDestroy = pickStatus;
    }
}
