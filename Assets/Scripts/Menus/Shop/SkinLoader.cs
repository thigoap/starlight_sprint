using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public GameObject[] skins;
    string skinName;

    void Start()
    {
        skinName = GameManager.Instance.DefineSkinName();
        ChoosenSkin(skinName);
    }

    public void ChoosenSkin(string skinName)
    {
        for (int i = 0; i <= 17; i++)
        {
            if (transform.GetChild(i).name == skinName)
                this.transform.GetChild(i).gameObject.SetActive(true);
            else
                this.transform.GetChild(i).gameObject.SetActive(false);                
        }
    }

}
