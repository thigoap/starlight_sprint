using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : Singleton<ShopMenu>
{
    ShopManager shopManager;

    public GameObject skinMaleScrollView;
    public GameObject kitMaleScrollView;
    public GameObject skinFemaleScrollView;
    public GameObject kitFemaleScrollView;

    public IconToggle maleIconToggle;
    public IconToggle femaleIconToggle;
    public IconToggle skinIconToggle;
    public IconToggle kitIconToggle;

    SkinLoader skinLoader;
    KitLoader kitLoader;

    public TextMeshProUGUI totalCoinsText;
    int totalCoins;
    public TextMeshProUGUI totalDiamondsText;
    int totalDiamonds;

    [SerializeField] public bool male;
    [SerializeField] public bool skin;
    

    void Start()
    {
        male = (PlayerPrefs.GetInt("male", 1) == 1);

        UpdateSelection(); 
        UpdateButtonColor(male, skin); 

        skinLoader = GameObject.Find("Skin Loader").GetComponent<SkinLoader>();
        kitLoader = GameObject.Find("Kit Loader").GetComponent<KitLoader>();

        totalCoinsText = GameObject.Find("Coins Quantity Text").GetComponent<TextMeshProUGUI>();
        totalDiamondsText = GameObject.Find("Diamonds Quantity Text").GetComponent<TextMeshProUGUI>();
        UpdateTotalBudget();
    }

    void UpdateSelection()
    {
        if (male && skin)
        {
            // Debug.Log("Male Skin");
            skinMaleScrollView.SetActive(true);
            skinFemaleScrollView.SetActive(false);
            kitMaleScrollView.SetActive(false);
            kitFemaleScrollView.SetActive(false);
        }
        else if (!male && skin)
        {
            // Debug.Log("Female Skin");
            skinMaleScrollView.SetActive(false);
            skinFemaleScrollView.SetActive(true);
            kitMaleScrollView.SetActive(false);
            kitFemaleScrollView.SetActive(false);
        }
        else if (male && !skin)
        {
            // Debug.Log("Male Kit");
            skinMaleScrollView.SetActive(false);
            skinFemaleScrollView.SetActive(false);
            kitMaleScrollView.SetActive(true);
            kitFemaleScrollView.SetActive(false);
        }
        else
        {
            // Debug.Log("Female Kit");
            skinMaleScrollView.SetActive(false);
            skinFemaleScrollView.SetActive(false);
            kitMaleScrollView.SetActive(false);
            kitFemaleScrollView.SetActive(true);
        }
    }

    void UpdateButtonColor(bool male, bool skin)
    {
        maleIconToggle.ToggleIcon(male);
        femaleIconToggle.ToggleIcon(!male);
        skinIconToggle.ToggleIcon(skin);
        kitIconToggle.ToggleIcon(!skin);
    }

    public void MaleButtonPressed()
    {
        male = true;
        skin = true;

        skinLoader.ChoosenSkin("Skin Male 01");
        PlayerPrefs.SetString("selectedSkin", "Skin Male 01");
        kitLoader.ChoosenKit("Kit Male 01");
        PlayerPrefs.SetString("selectedKit", "Kit Male 01");

        // PlayerPrefs.SetInt("male", (male ? 1 : 0));
        PlayerPrefs.SetInt("male", 1);
    

        UpdateSelection();
        UpdateButtonColor(male, skin);
    }

    public void FemaleButtonPressed()
    {
        male = false;
        skin = true;

        skinLoader.ChoosenSkin("Skin Female 01");
        PlayerPrefs.SetString("selectedSkin", "Skin Female 01");
        kitLoader.ChoosenKit("Kit Female 01");
        PlayerPrefs.SetString("selectedKit", "Kit Female 01");

        // PlayerPrefs.SetInt("male", (male ? 1 : 0));
        PlayerPrefs.SetInt("male", 0);

        UpdateSelection();
        UpdateButtonColor(male, skin);
    }
    
    public void SkinButtonPressed()
    {
        skin = true;
        UpdateSelection();
        UpdateButtonColor(male, skin);
    }

    public void KitButtonPressed()
    {
        skin = false;
        UpdateSelection();
        UpdateButtonColor(male, skin);
    }

    public void UpdateTotalBudget()
    {
        // GameData
        totalCoins = StatsManager.Instance.totalCoins;
        totalCoinsText.text = totalCoins.ToString(); 
        
        totalDiamonds = StatsManager.Instance.totalDiamonds;
        totalDiamondsText.text = totalDiamonds.ToString();        
    }    
}
