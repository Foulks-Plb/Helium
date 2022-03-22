using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShop : MonoBehaviour
{
    public GameObject PlayerBody;
    public GameObject PlayerArm;

    public int PlayerSkinIndex;
    public int price;
    public bool unlocked;

    public GameObject Data;
    PlayerData playerData;

    public GameObject ButtonBuy;
    public GameObject ButtonSelect;

    public GameObject CantBuy;

    // Start is called before the first frame update
    void Start()
    {
        
        playerData = Data.GetComponent<PlayerData>();

        transform.GetChild(0).GetComponent<Text>().text = price.ToString();

        // if unlocked
        if (PlayerPrefs.GetInt("PlayerSkin-" + PlayerSkinIndex) == 1)
        {
            unlocked = true;
            playerData.playerSkins[PlayerSkinIndex].unlocked = unlocked;
            ButtonBuy.SetActive(false);
            ButtonSelect.SetActive(true);
            GetComponent<Image>().color = Color.white;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyPlayer()
    {
        if (price <= playerData.CoinsAmount && !unlocked)
        {
            playerData.CoinsAmount -= price;

            unlocked = true;
            playerData.playerSkins[PlayerSkinIndex].unlocked = unlocked;
            ButtonBuy.SetActive(false);
            ButtonSelect.SetActive(true);
            SelectPlayer();
            GetComponent<Image>().color = Color.white;
            transform.GetChild(0).gameObject.SetActive(false);

            SoundFx.PlaySound("Buy");

            PlayerPrefs.SetInt("PlayerSkin-" + PlayerSkinIndex.ToString(), 1); //Unlock Status
            PlayerPrefs.SetInt("Coins", playerData.CoinsAmount); // Save new coins amount
        }
        else
        {
            unlocked = false;
            SoundFx.PlaySound("CantBuy");
            CantBuy.SetActive(true);
        }
    }


    public void SelectPlayer()
    {
        if (unlocked)
        {
            PlayerBody.GetComponent<SpriteRenderer>().sprite = playerData.playerSkins[PlayerSkinIndex].SkinSpriteBody;
            PlayerArm.GetComponent<SpriteRenderer>().sprite = playerData.playerSkins[PlayerSkinIndex].SkinSpriteArm;
            SoundFx.PlaySound("ClickSimple");

            playerData.CurrentPlayerSkin = PlayerSkinIndex;
            PlayerPrefs.SetInt("CurrentPlayerSkin", PlayerSkinIndex);
        }
        else if (!unlocked)
        {
            BuyPlayer();
        }




    }
}
