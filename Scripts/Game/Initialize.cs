using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initialize : MonoBehaviour
{
    public bool LoadSavedData = true;

    [Space(10)]
    PlayerData playerData;

    public GameObject EnvironementSpawner, PlayerBody, PlayerArm;

    public Slider slider;
    public Text TextLevel;

    public AmmoShop Ammo;

    // Start is called before the first frame update
    void Awake()
    {
        if (LoadSavedData)
        {
            playerData = GetComponent<PlayerData>();

            if (!PlayerPrefs.HasKey("isGuest"))
            {
                PlayerPrefs.SetInt("isGuest", 1);
            }

            if (PlayerPrefs.GetInt("FirstLaunch") == 0) //initialize all needed infos
            {

                PlayerPrefs.SetInt("FirstLaunch", 1);
                PlayerPrefs.SetInt("Coins", 100);
            }
            else if (PlayerPrefs.GetInt("FirstLaunch") == 1)
            {
                playerData.CoinsAmount = PlayerPrefs.GetInt("Coins");

                playerData.CurrentMap = PlayerPrefs.GetInt("CurrentMap");
                setEnvironement(playerData.CurrentMap);

                playerData.CurrentWeapon = PlayerPrefs.GetInt("CurrentWeapon"); // load last used weapon

                for (int i = 0; i < playerData.Weapons.Count; i++) // load data of unlocked weapon
                {
                    if (PlayerPrefs.GetInt("Weapon-" + i) == 1)
                    {
                        playerData.Weapons[i].unlocked = true;
                    }
                }

                playerData.CurrentPlayerSkin = PlayerPrefs.GetInt("CurrentPlayerSkin"); // load player skin
                setPlayerSkin(playerData.CurrentPlayerSkin); 

                playerData.Levels = PlayerPrefs.GetInt("Levels"); // load player levels
                TextLevel.text = "level " + playerData.Levels;

                playerData.Experience = PlayerPrefs.GetFloat("Experience"); // load player experience               
                slider.value = playerData.Experience;

                playerData.BestScore = PlayerPrefs.GetInt("BestScore"); // load best score
                 // load LevelAmmo upgrade

                //load Player Name
                if (PlayerPrefs.GetInt("isGuest") == 1)
                {
                    playerData.PlayerName = PlayerPrefs.GetString("PlayerName");
                    playerData.GeneratedName = PlayerPrefs.GetString("GuestName");
                }
                else
                {
                    playerData.GeneratedName = PlayerPrefs.GetString("GuestName");
                    playerData.PlayerName = PlayerPrefs.GetString("PlayerName");
                }                

            }
            else
            {
                PlayerPrefs.SetInt("FirstLaunch", 1);
            }
        }  
        
    }

    void setEnvironement(int MapIndex)
    {
        Object.Destroy(EnvironementSpawner.transform.GetChild(0).gameObject);
        Instantiate(playerData.environements[MapIndex].EnvironementPrefab, EnvironementSpawner.transform);
    }

    void setPlayerSkin(int MapIndex)
    {
        PlayerBody.GetComponent<SpriteRenderer>().sprite = playerData.playerSkins[playerData.CurrentPlayerSkin].SkinSpriteBody;
        PlayerArm.GetComponent<SpriteRenderer>().sprite = playerData.playerSkins[playerData.CurrentPlayerSkin].SkinSpriteArm;
    }


    
}
