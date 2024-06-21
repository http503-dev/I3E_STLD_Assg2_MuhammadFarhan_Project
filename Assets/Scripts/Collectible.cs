using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;


    public static int score = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UpdatePlayerInteractable(collision.gameObject.GetComponent<Player>());
        }
    }

    public virtual void Collected(Player thePlayer)
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
        Debug.Log("Collected");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RemovePlayerInteractable(collision.gameObject.GetComponent<Player>());
        }
    }



    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.IncreaseScore(score);
        Destroy(gameObject);
        Collected(thePlayer);
    }

}
