using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPrefLoader : MonoBehaviour
{
    string skinName;
    public GameObject[] skins;

    void Start()
    {
        skinName = GameManager.Instance.DefineSkinName();

        for (int i = 0; i <= 17; i++)
        {
            if (transform.GetChild(i).name == skinName)
                this.transform.GetChild(i).gameObject.SetActive(true);
            else
                this.transform.GetChild(i).gameObject.SetActive(false);                
        }                
    }

}
