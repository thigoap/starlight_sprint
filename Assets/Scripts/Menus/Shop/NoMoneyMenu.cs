using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoneyMenu : Singleton<NoMoneyMenu>
{

    void Start()
    {
        gameObject.SetActive(false); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void ClickOK()
    {
        gameObject.SetActive(false); 
    }

}
