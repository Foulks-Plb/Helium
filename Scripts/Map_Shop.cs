using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Shop : MonoBehaviour
{
    public int MapIndex;
    public GameObject EnvironementSpawner;
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
        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(0,40) + (new Vector2(20,0) * transform.GetChild(0).GetComponent<Text>().text.Length);


        // if unlocked
        if (PlayerPrefs.GetInt("Map-" + MapIndex) == 1)
        {
            unlocked = true;
            playerData.environements[MapIndex].unlocked = unlocked;
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

    public void BuyMap()
    {
        if (price <= playerData.CoinsAmount && !unlocked)
        {
            playerData.CoinsAmount -=  price;

            unlocked = true;
            playerData.environements[MapIndex].unlocked = unlocked;
            ButtonBuy.SetActive(false);
            ButtonSelect.SetActive(true);
            SelectMap();
            GetComponent<Image>().color = Color.white;
            transform.GetChild(0).gameObject.SetActive(false);

            SoundFx.PlaySound("Buy");

            PlayerPrefs.SetInt("Map-" + MapIndex.ToString(), 1); //Unlock Status
            PlayerPrefs.SetInt("Coins", playerData.CoinsAmount); // Save new coins amount
        }
        else
        {
            unlocked = false;
            SoundFx.PlaySound("CantBuy");
            CantBuy.SetActive(true);
        }
    }


    public void SelectMap()
    {
        if (unlocked)
        {
            Object.Destroy(EnvironementSpawner.transform.GetChild(0).gameObject);
            Instantiate(playerData.environements[MapIndex].EnvironementPrefab, EnvironementSpawner.transform);
            playerData.CurrentMap = MapIndex;
            PlayerPrefs.SetInt("CurrentMap", MapIndex);
            SoundFx.PlaySound("ClickSimple");

        }
        else if (!unlocked)
        {
            BuyMap();
        }
        



    }


}
