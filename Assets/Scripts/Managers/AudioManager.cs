using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Status")]
    public bool musicEnabled = true;
    public bool sfxEnabled = true;

    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("Audio Clips")]    
    public AudioClip menuSong;
    public AudioClip inGameSong;
    public AudioClip jumpSFX;
    public AudioClip slideSFX;
    public AudioClip coinCollectedSFX;
    public AudioClip powerUpLifeCollectedSFX;
    public AudioClip takeHitSFX;
    public AudioClip giveHitSFX;
    public AudioClip gameOverSFX;


    public void Start()
    {
        musicSource.Stop(); 
        musicSource.clip = menuSong;
        if (musicEnabled)
        {
            musicSource.Play();
            musicSource.volume = 0.75f;        
        }
    }

    public void PlayInGameSong()
    {
        musicSource.Stop();        
        musicSource.clip = inGameSong;
        if (musicEnabled)
        {
            musicSource.Play(); 
            musicSource.volume = 0.75f; 
        }      
    }

    public void Pause()
    {
        musicSource.volume = 0.25f;
    }
    public void Resume()
    {
        musicSource.volume = 0.75f;
    }
    public void Stop()
    {
        musicSource.Stop();
        musicSource.volume = 0.75f;        
    }

    public void PlayJumpSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(jumpSFX);
    }
    public void PlaySlideSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(slideSFX);
    }
    public void PlayCoinCollectedSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(coinCollectedSFX);
    }
    public void PlayTakeHitSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(takeHitSFX);
    }
    public void PlayGiveHitSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(giveHitSFX);
    }
    public void PlayGameOverSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(gameOverSFX);
    }
    public void PlayPowerUpLifeCollectedSFX()
    {
        if (sfxEnabled)
            SFXSource.PlayOneShot(powerUpLifeCollectedSFX);
    }
    
    
}
