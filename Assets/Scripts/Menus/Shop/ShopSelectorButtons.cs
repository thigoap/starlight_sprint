using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSelectorButtons : MonoBehaviour
{
    public string itemName;

    SkinLoader skinLoader;
    KitLoader kitLoader;
    // SkinFemaleLoader skinFemaleLoader;
    
    void Awake()
    {
        skinLoader = GameObject.Find("Skin Loader").GetComponent<SkinLoader>();
        kitLoader = GameObject.Find("Kit Loader").GetComponent<KitLoader>();
    }

    public void ChoosenSkin()
    {
        Debug.Log(itemName);
        skinLoader.ChoosenSkin(itemName);
        PlayerPrefs.SetString("selectedSkin", itemName);
    }
    public void ChoosenKit()
    {
        Debug.Log(itemName);
        kitLoader.ChoosenKit(itemName);
        PlayerPrefs.SetString("selectedKit", itemName);
    }
}