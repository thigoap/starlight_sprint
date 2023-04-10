using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitLoader : MonoBehaviour
{
    public GameObject[] kits;
    string kitName;

    void Start()
    {
        kitName = GameManager.Instance.DefineKitName();
        ChoosenKit(kitName);
    }

    public void ChoosenKit(string kitName)
    {
        // for (int i = 0; i <= 3; i++)
        for (int i = 0; i <= 3; i++) 
        {
            if (transform.GetChild(i).name == kitName)
                this.transform.GetChild(i).gameObject.SetActive(true);
            else
                this.transform.GetChild(i).gameObject.SetActive(false);                
        }
    }

}
