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
    /// sound for picking up pickaxe
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// bool to determine whether pickaxe has been collected
    /// </summary>
    bool hasPick = false;

    /// <summary>
    /// function for what happens on intereacting
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        hasPick = true;
        GameManager.instance.SetHasPick(hasPick);
        UIManager.instance.HideInteractPrompt();
        Destroy(gameObject);
        if (collectAudio != null)
        {
            AudioManager.instance.PlaySFX(collectAudio, transform.position);
        }
    }

    /// <summary>
    /// trigger enter/exit to show/hide prompts
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        UIManager.instance.ShowInteractPrompt("Hit 'E' to interact");
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideInteractPrompt();
    }
}
