using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoShop : MonoBehaviour
{
    public int price;
    public Text PriceText;

    public Text LevelAmmoUpgrade;
    public int LevelAmmo;
    public int AmmoUpgrade;

    public PlayerData Data;

    public GameObject ButtonUpgrade;
    public GameObject CantBuy;



    // Start is called before the first frame update
    void Start()
    {
        LevelAmmoUpgrade.text = "Lvl:" + LevelAmmo.ToString();

        price = price * (int)Mathf.Pow(2, LevelAmmo);

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
            LevelAmmo += 1;
            LevelAmmoUpgrade.text = "Lvl:" + LevelAmmo.ToString();
            AmmoUpgrade += 5;
           
            PlayerPrefs.SetInt("Coins", Data.CoinsAmount);
            PlayerPrefs.SetInt("LevelAmmo", LevelAmmo); //save ammo in this script ( ---> je save directe ici et pas dans data )
        }
        else
        {

            SoundFx.PlaySound("CantBuy");
            CantBuy.SetActive(true);
        }
    }
}
