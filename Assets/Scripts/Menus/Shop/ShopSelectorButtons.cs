using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSelectorButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ShopCard card;
    public string itemName;

    SkinLoader skinLoader;
    KitLoader kitLoader;
    
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

    public void OnPointerDown (PointerEventData eventData)
    {
        if (ShopMenu.Instance.skin && ShopMenu.Instance.male)
        {
            if (ShopManager.Instance.ownedMaleSkins[card.id - 1] == 1)
                ChoosenSkin();
            else
                BuyMenu.Instance.Show(card);
        }
        else if (ShopMenu.Instance.skin && !ShopMenu.Instance.male)
        {
            if (ShopManager.Instance.ownedFemaleSkins[card.id - 1] == 1)
                ChoosenSkin();
            else
                BuyMenu.Instance.Show(card);
        }
        else if (!ShopMenu.Instance.skin && ShopMenu.Instance.male)
        {
            if (ShopManager.Instance.ownedMaleKits[card.id - 1] == 1)
                ChoosenKit();
            else
                BuyMenu.Instance.Show(card);
        }
        else if (!ShopMenu.Instance.skin && !ShopMenu.Instance.male)
        {
            if (ShopManager.Instance.ownedFemaleKits[card.id - 1] == 1)
                ChoosenKit();
            else
                BuyMenu.Instance.Show(card);
        }
	}

	public void OnPointerUp (PointerEventData eventData) {
		// Debug.Log("Up");
	}
}