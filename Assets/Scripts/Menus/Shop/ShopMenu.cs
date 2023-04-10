using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
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

    [SerializeField] bool male = true;
    [SerializeField] bool skin = true;
    
        
    void Start()
    {
        UpdateSelection(); 
        UpdateSelector(male, skin); 

        skinLoader = GameObject.Find("Skin Loader").GetComponent<SkinLoader>();
        kitLoader = GameObject.Find("Kit Loader").GetComponent<KitLoader>();
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

    void UpdateSelector(bool male, bool skin)
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

        UpdateSelection();
        UpdateSelector(male, skin);
    }

    public void FemaleButtonPressed()
    {
        male = false;
        skin = true;

        skinLoader.ChoosenSkin("Skin Female 01");
        PlayerPrefs.SetString("selectedSkin", "Skin Female 01");
        kitLoader.ChoosenKit("Kit Female 01");
        PlayerPrefs.SetString("selectedKit", "Kit Female 01");

        UpdateSelection();
        UpdateSelector(male, skin);
    }
    
    public void SkinButtonPressed()
    {
        skin = true;
        UpdateSelection();
        UpdateSelector(male, skin);
  
    }

    public void KitButtonPressed()
    {
        skin = false;
        UpdateSelection();
        UpdateSelector(male, skin);
    }
    
}
