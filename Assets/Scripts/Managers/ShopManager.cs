using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShopManager : Singleton<ShopManager>
{
    private ShopSavedData MyData = new ShopSavedData();

    public int[] ownedMaleSkins;
    public int[] ownedFemaleSkins;
    public int[] ownedMaleKits;
    public int[] ownedFemaleKits;

    string item;
    string genre;
    int id;
    string[] buyInfo;

    public void Start()
    {
        string fullPath = Application.persistentDataPath + SaveSystem.SaveDirectory + SaveSystem.ShopDataFile;
        // Creates Initial Shop Saved Data
        if (!File.Exists(fullPath))
        {
            // Debug.Log("Creating Shop");
            ownedMaleSkins = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0 };
            ownedFemaleSkins = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0 };
            ownedMaleKits = new int[] { 1, 0, 0 };
            ownedFemaleKits = new int[] { 1, 0, 0 };
            MyData.ownedMaleSkins = ownedMaleSkins;
            MyData.ownedFemaleSkins = ownedFemaleSkins;
            MyData.ownedMaleKits = ownedMaleKits;
            MyData.ownedFemaleKits = ownedFemaleKits;       
            SaveShopData();
        }
        else
            LoadShopData();
    }

    public void UpdateOwnedItems(string cardInfo)
    {
        buyInfo = cardInfo.Split(' ');
        item = buyInfo[0];
        genre = buyInfo[1];
        id = int.Parse(buyInfo[2]) - 1;

        if (item == "Skin" && genre == "Male")
        {
            ownedMaleSkins[id] = 1;
            MyData.ownedMaleSkins = ownedMaleSkins;
        }
        else if (item == "Skin" && genre == "Female")
        {
            ownedFemaleSkins[id] = 1;
            MyData.ownedFemaleSkins = ownedFemaleSkins;
        }
        else if (item == "Kit" && genre == "Male")
        {
            ownedMaleKits[id] = 1;
            MyData.ownedMaleKits = ownedMaleKits;
        }
        else if (item == "Kit" && genre == "Female")
        {
            ownedFemaleKits[id] = 1;
            MyData.ownedFemaleKits = ownedFemaleKits;
        }
        

        SaveShopData();
    }

    // SaveSystem
    public void SaveShopData()
    {       
        SaveSystem.CurrentShopData.ShopSavedData = MyData;
        SaveSystem.SaveShopData();
    }

    public void LoadShopData()
    {
        SaveSystem.LoadShopData();
        MyData = SaveSystem.CurrentShopData.ShopSavedData;
        ownedMaleSkins = MyData.ownedMaleSkins;
        ownedFemaleSkins = MyData.ownedFemaleSkins;
        ownedMaleKits = MyData.ownedMaleKits;
        ownedFemaleKits = MyData.ownedFemaleKits;
    }

    public void UpdateWithResetedData() {
        MyData.ownedMaleSkins = ownedMaleSkins;
        MyData.ownedFemaleSkins = ownedFemaleSkins;
        MyData.ownedMaleKits = ownedMaleKits;
        MyData.ownedFemaleKits = ownedFemaleKits; 
    }
}

[System.Serializable]
public struct ShopSavedData
{
    public bool createShop;
    public int[] ownedMaleSkins;
    public int[] ownedFemaleSkins;
    public int[] ownedMaleKits;
    public int[] ownedFemaleKits;
}
