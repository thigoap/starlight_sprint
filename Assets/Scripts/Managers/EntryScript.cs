using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryScript : MonoBehaviour
{

    public Animator animator;
    AudioSource SFXSource;

    void Start()
    {
        SFXSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void CallStartGame()
    {
        GameManager.Instance.StartGame();
        SFXSource.volume = 0.2f;
    }

    public void AudioStart()
    {
        AudioManager.Instance.PlayCityThemeSong();
    }

    public void CallGoText()
    {
        Debug.Log("Call Go Text");
        animator.SetTrigger("GO");
        CallStartGame();
    }
}
