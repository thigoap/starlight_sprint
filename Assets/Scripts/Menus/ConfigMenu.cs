using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMenu : MonoBehaviour
{
    public IconToggle fxIconToggle;
    public IconToggle musicIconToggle;
    public IconToggle controlIconToggle;
    

    void Start()
    {
        musicIconToggle.ToggleIcon(AudioManager.Instance.musicEnabled);
        fxIconToggle.ToggleIcon(AudioManager.Instance.sfxEnabled);
        controlIconToggle.ToggleIcon(UIManager.Instance.visibleControls);
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.musicEnabled = !AudioManager.Instance.musicEnabled;
        if (!AudioManager.Instance.musicEnabled)
            AudioManager.Instance.Stop();
        else
           AudioManager.Instance.Start(); 

        musicIconToggle.ToggleIcon(AudioManager.Instance.musicEnabled);
    }
    
    public void ToggleSFX()
    {
        AudioManager.Instance.sfxEnabled = !AudioManager.Instance.sfxEnabled;

        fxIconToggle.ToggleIcon(AudioManager.Instance.sfxEnabled);
    }

    public void ToggleControls()
    {
        UIManager.Instance.visibleControls = !UIManager.Instance.visibleControls;

        controlIconToggle.ToggleIcon(UIManager.Instance.visibleControls);
    }

    

}
