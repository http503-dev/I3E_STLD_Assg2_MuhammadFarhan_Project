/*
 * Author: Muhammad Farhan
 * Date: 29/6/2024
 * Description: Script related persistant ui
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// references ui manager
    /// </summary>
    public static UIManager instance;
    
    /// <summary>
    /// references ui elements
    /// </summary>
    public TextMeshProUGUI interactPrompt;
    public GameObject interactBackground;
    public TextMeshProUGUI warningPrompt;
    public GameObject warningBackground;
    public TextMeshProUGUI successPrompt;
    public GameObject successBackground;
    public GameObject gasPanel;
    public GameObject electricPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// function to show interct prompts
    /// </summary>
    /// <param name="message"></param>
    public void ShowInteractPrompt(string message)
    {
        interactPrompt.text = message;
        interactBackground.SetActive(true);
    }

    /// <summary>
    /// function to hide interact prompts
    /// </summary>
    public void HideInteractPrompt()
    {
        interactPrompt.text = null;
        interactBackground.SetActive(false);
    }

    /// <summary>
    /// function to show success prompts
    /// </summary>
    /// <param name="message"></param>
    public void ShowSuccessPrompt(string message)
    {
        successPrompt.text = message;
        successBackground.SetActive(true);
    }

    /// <summary>
    /// function to hide success prompts
    /// </summary>
    public void HideSuccessPrompt()
    {
        successPrompt.text = null;
        successBackground.SetActive(false);
    }

    /// <summary>
    /// function to show warning prompts
    /// </summary>
    /// <param name="message"></param>
    public void ShowWarningPrompt(string message)
    {
        warningPrompt.text = message;
        warningBackground.SetActive(true);
    }

    /// <summary>
    /// function to hide warning prompts
    /// </summary>
    public void HideWarningPrompt()
    {
        warningPrompt.text = null;
        warningBackground.SetActive(false);
    }

    /// <summary>
    /// function to show gas panel
    /// </summary>
    public void showGas()
    {
        gasPanel.SetActive(true);
    }

    /// <summary>
    /// function to hide gas panel
    /// </summary>
    public void hideGas()
    {
        gasPanel.SetActive(false);
    }

    /// <summary>
    /// function to show electric panel
    /// </summary>
    public void showElectric()
    {
        electricPanel.SetActive(true);
    }

    /// <summary>
    /// function to hide electric panel
    /// </summary>
    public void hideElectric()
    {
        electricPanel.SetActive(false);
    }
}
