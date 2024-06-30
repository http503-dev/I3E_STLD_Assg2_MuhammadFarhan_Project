/*
 * Author: Muhammad Farhan
 * Date: 30/6/2024
 * Description: Script related to escaping
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : Interactable
{
    /// <summary>
    /// to set audio when escaping
    /// </summary>
    [SerializeField] private AudioClip escapeAudio;

    /// <summary>
    /// plays audio and shows congratulatory message
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        if (escapeAudio != null)
        {
            AudioManager.instance.PlaySFX(escapeAudio, transform.position);
        }
        UIManager.instance.ShowCongrats();

    }

    /// <summary>
    /// trigger enter/exit to show/hide prompts
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        UIManager.instance.ShowSuccessPrompt("Hit 'E' to return home!");
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideSuccessPrompt();
    }
}
