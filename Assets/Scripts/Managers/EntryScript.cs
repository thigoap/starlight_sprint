using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryScript : MonoBehaviour
{

    public Animator animator;

    public void CallStartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void AudioStart()
    {
        AudioManager.Instance.PlayInGameSong();
    }

    public void CallGoText()
    {
        Debug.Log("Call Go Text");
        animator.SetTrigger("GO");
        CallStartGame();
    }
}
