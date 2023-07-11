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
    
    [Header("Music")]    
    public AudioClip menuSong;
    public AudioClip cityThemeSong;
    [Header("SFX in game")]      
    public AudioClip jumpSFX;
    public AudioClip slideSFX;
    public AudioClip coinCollectedSFX;
    public AudioClip powerUpLifeCollectedSFX;
    public AudioClip takeHitSFX;
    public AudioClip giveHitSFX;
    public AudioClip gameOverSFX;
    [Header("SFX")]     
    public AudioClip buyConfirmedSFX;
    public AudioClip buyErrorSFX;
    

    public void Start() {
        musicSource.Stop(); 
        musicSource.clip = menuSong;
        if (musicEnabled)
        {
            musicSource.Play();
            musicSource.volume = 1f;        
        }
    }

    public void PlayCityThemeSong() {
        musicSource.Stop();        
        musicSource.clip = cityThemeSong;
        if (musicEnabled)
        {
            musicSource.Play(); 
            musicSource.volume = 1f; 
        }      
    }

    public void Pause()  {
        musicSource.volume = 0.25f;
    }

    public void Resume()  {
        musicSource.volume = 1f;
    }

    public void Stop() {
        musicSource.Stop();
        musicSource.volume = 1f;        
    }

    public void PlayJumpSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(jumpSFX);
    }

    public void PlaySlideSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(slideSFX);
    }

    public void PlayCoinCollectedSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(coinCollectedSFX);
    }

    public void PlayTakeHitSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(takeHitSFX);
    }

    public void PlayGiveHitSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(giveHitSFX);
    }

    public void PlayGameOverSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(gameOverSFX);
    }

    public void PlayPowerUpLifeCollectedSFX() {
        if (sfxEnabled)
            SFXSource.PlayOneShot(powerUpLifeCollectedSFX);
    }

    public void PlayBuyConfirmedSFX() {
        SFXSource.PlayOneShot(buyConfirmedSFX);
    }

    public void PlayBuyErrorSFX() {
        SFXSource.PlayOneShot(buyErrorSFX);
    }
    
}
