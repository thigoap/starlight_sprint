using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static PlayerData CurrentPlayerData = new PlayerData();
    public static ShopData CurrentShopData = new ShopData();
    
    public const string SaveDirectory = "/SaveData/";
    public const string PlayerDataFile = "PlayerData.sav";
    public const string ShopDataFile = "ShopData.sav";
    

    public static bool SavePlayerData()
    {
        var dir = Application.persistentDataPath + SaveDirectory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        
        string json = JsonUtility.ToJson(CurrentPlayerData, true);
        File.WriteAllText(dir + PlayerDataFile, json);

        GUIUtility.systemCopyBuffer = dir;

        return true;
    }

    public static void LoadPlayerData()
    {
        string fullPath = Application.persistentDataPath + SaveDirectory + PlayerDataFile;
        PlayerData tempData = new PlayerData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<PlayerData>(json);
            CurrentPlayerData = tempData;
        }
        else
        {
            Debug.LogError("Save File does not exist.");
        }
    }   

    public static bool SaveShopData()
    {
        var dir = Application.persistentDataPath + SaveDirectory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        
        string json = JsonUtility.ToJson(CurrentShopData, true);
        File.WriteAllText(dir + ShopDataFile, json);

        GUIUtility.systemCopyBuffer = dir;

        return true;
    }

    public static void LoadShopData()
    {
        string fullPath = Application.persistentDataPath + SaveDirectory + ShopDataFile;
        ShopData tempData = new ShopData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<ShopData>(json);
            CurrentShopData = tempData;
        }
        else
        {
            Debug.LogError("Save File does not exist.");
        }
    }

}

