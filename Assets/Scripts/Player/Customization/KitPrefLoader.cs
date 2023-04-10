using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitPrefLoader : MonoBehaviour
{
    string kitName;
    public GameObject[] kits;

    void Start()
    {
        kitName = GameManager.Instance.DefineKitName();

        for (int i = 0; i <= 3; i++)
        {
            if (transform.GetChild(i).name == kitName)
                this.transform.GetChild(i).gameObject.SetActive(true);
            else
                this.transform.GetChild(i).gameObject.SetActive(false);                
        }
    }
}
