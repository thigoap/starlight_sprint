using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopCardDisplay : MonoBehaviour
{
    public ShopCard card;

    public Image itemImage;
    public GameObject boughtBadge;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI diamondText;
    
    string item;
    string genre;
    int id;    
    string[] cardInfo;

    void Start()
    {
        coinText.text = card.coin.ToString();
        diamondText.text = card.diamond.ToString();

        itemImage.sprite = card.art;

        boughtBadge.SetActive(false);
        ActivateBadge();
    }

    void Update()
    {
        ActivateBadge();
    }

    public void ActivateBadge()
    {
        cardInfo = card.name.Split(' ');
        item = cardInfo[0];
        genre = cardInfo[1];
        id = int.Parse(cardInfo[2]);

        if (item == "Skin" && genre == "Male" && id > 6)
        {
            if (ShopManager.Instance.ownedMaleSkins[id - 1] == 1)
                boughtBadge.SetActive(true);
        }
        else if (item == "Skin" && genre == "Female" && id > 6)
        {
            if (ShopManager.Instance.ownedFemaleSkins[id - 1] == 1)
                boughtBadge.SetActive(true);
        }
        else if (item == "Kit" && genre == "Male" && id > 1)
        {
            if (ShopManager.Instance.ownedMaleKits[id - 1] == 1)
                boughtBadge.SetActive(true);
        }
        else if (item == "Kit" && genre == "Female" && id > 1)
        {
            if (ShopManager.Instance.ownedFemaleKits[id - 1] == 1)
                boughtBadge.SetActive(true);
        }
    }

}
