using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : Singleton<BuyMenu>
{
    
    int totalCoins;
    int totalDiamonds;
    
    ShopCard card;

    void Start()
    {
        gameObject.SetActive(false); 
    }

    public void Show(ShopCard chosenCard)
    {
        gameObject.SetActive(true);
        card = chosenCard;
    }

    public void ClickYes()
    {      
        // GameData
        totalCoins = StatsManager.Instance.totalCoins;
        totalDiamonds = StatsManager.Instance.totalDiamonds;      
        
    
        if (totalCoins >= card.coin && totalDiamonds >= card.diamond)
        {
        

            totalCoins = totalCoins - card.coin;
            totalDiamonds = totalDiamonds - card.diamond;

            // SaveSystem
            StatsManager.Instance.totalCoins = totalCoins;  
            StatsManager.Instance.totalDiamonds = totalDiamonds;

            StatsManager.Instance.UpdateStats();
            ShopManager.Instance.UpdateOwnedItems(card.name);
            
            AudioManager.Instance.PlayBuyConfirmedSFX();
            ShopMenu.Instance.UpdateTotalBudget();
            // ShopMenu.Instance.UpdateCardsVisual();
            
            gameObject.SetActive(false); 


        }
        else
        {
            AudioManager.Instance.PlayBuyErrorSFX();
            NoMoneyMenu.Instance.Show();
            gameObject.SetActive(false);
        }
    }

    public void ClickNo()
    {
        gameObject.SetActive(false); 
    }

}
