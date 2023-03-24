using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : Singleton<TutorialMenu>
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    } 
}
