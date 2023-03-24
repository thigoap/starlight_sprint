using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : Singleton<QuitMenu>
{

    void Start()
    {
        gameObject.SetActive(false);   
    }

    public void Quit()
    {
        gameObject.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void DenyQuit()
    {
        gameObject.SetActive(false);
    }

    

}
