using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeShop : MonoBehaviour
{
    public int price;
    public Text PriceText;

    public Text LevelLifeUpgrade;
    public int LevelLife;
    public int LifeUpgrade;

    public PlayerData Data;

    public GameObject ButtonUpgrade;
    public GameObject CantBuy;



    // Start is called before the first frame update
    void Start()
    {
        LevelLifeUpgrade.text = "Lvl:" + LevelLife.ToString();

        price = price * (int)Mathf.Pow(2, LevelLife);

        PriceText.text = price.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        if (price <= Data.CoinsAmount)
        {
            SoundFx.PlaySound("Buy");
            Data.CoinsAmount -= price;
            price *= 2;
            PriceText.text = price.ToString();
            LevelLife += 1;
            LevelLifeUpgrade.text = "Lvl:"+ LevelLife.ToString();
            LifeUpgrade += 2;

            
            PlayerPrefs.SetInt("Coins", Data.CoinsAmount);
            PlayerPrefs.SetInt("LevelLife", LevelLife); //save Life in this script ( ---> je save directe ici et pas dans data )
        }
        else
        {

            SoundFx.PlaySound("CantBuy");
            CantBuy.SetActive(true);
        }
    }
   
}
