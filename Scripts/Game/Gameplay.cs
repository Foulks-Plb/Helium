using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    
    public Slider slider;
    public Text TextLevel;
    public float experienceActual;
    public float experienceIntermediaire;
    

    public bool Playing;
    public bool Paused;
    public bool Ressucite;
    public GameObject BalloonSpawner;
    public GameObject Balloonrescue;
    public GameObject GameOverPopup;
    public GameObject GameUI;
    public GameObject RescueUi;
    public Destroyer ScriptDestroyer;
    public int life;

    public Text scoreGameOver;
    public Text BestscoreText;
    public Text BestscoreMenuText;

    public PlayerData PlayerData;
    public FB_FirestoreDB FB_FirestoreDB;

    public static int AmmoNumberStart;
    public Text textAmmo;

    private int CountTime;
    public Text countdownDisplay;

    public LifeShop LifeShopScript;
    public AmmoShop AmmoShopScript;


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 50 * Mathf.Pow(1.2f, PlayerData.Levels);
        BestscoreText.text = PlayerData.BestScore.ToString();
        BestscoreMenuText.text = PlayerData.BestScore.ToString();

        LifeShopScript.LevelLife = PlayerPrefs.GetInt("LevelLife");
        LifeShopScript.LifeUpgrade = LifeShopScript.LevelLife * 2;

        AmmoShopScript.LevelAmmo = PlayerPrefs.GetInt("LevelAmmo");
        AmmoShopScript.AmmoUpgrade = AmmoShopScript.LevelAmmo * 5;
    }

    // Update is called once per frame
    void Update()
    {        
        textAmmo.text = AmmoNumberStart.ToString();
        if (AmmoNumberStart <= 0 && Playing)
        {
            StartCoroutine(WaitLastWeapon());
        }
        else if(Destroyer.LifeNumber <= 0 && Playing)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        ScoreScript.ScoreValue = 0;

        Playing = true;
        Ressucite = false;
        CountTime = 3;

        AmmoNumberStart = PlayerData.Weapons[PlayerData.CurrentWeapon].Ammo + AmmoShopScript.AmmoUpgrade;
        Destroyer.LifeNumber = life + LifeShopScript.LifeUpgrade;                     
    }

    public void GameOver()
    {
        BalloonSpawner.SetActive(false);
        Balloonrescue.SetActive(false);
        GameUI.SetActive(false);
        //Rescue.SetActive(false);
        Playing = false;

        scoreGameOver.text = ScoreScript.ScoreValue.ToString();
        if (ScoreScript.ScoreValue > PlayerData.BestScore) // si  bestscore est depassé
        {
            PlayerData.BestScore = ScoreScript.ScoreValue;           
            BestscoreText.text = ScoreScript.ScoreValue.ToString();
            BestscoreMenuText.text = ScoreScript.ScoreValue.ToString();
            FB_FirestoreDB.LeaderboardSubmit();
        }
       
        GameOverPopup.SetActive(true);
        PlayerData.CoinsAmount += ScoreScript.ScoreValue;
        LevelUp();
        slider.value = experienceActual;

        PlayerData.Experience = experienceActual;

        SoundFx.PlaySound("GameOver1");

        PlayerPrefs.SetInt("BestScore", PlayerData.BestScore);
        PlayerPrefs.SetFloat("Experience", PlayerData.Experience);
        PlayerPrefs.SetInt("Levels", PlayerData.Levels);
        PlayerPrefs.SetInt("Coins", PlayerData.CoinsAmount);

        BalloonSpawner.SetActive(true);
        Balloonrescue.SetActive(true);
    }


    public void PauseGame()
    {
        if (Paused)
        {
            Time.timeScale = 1;
            Paused = false;
        }
        else
        {
            Time.timeScale = 0;
            Paused = true;
        }
    }

    public void LevelUp()
    {
        if (ScoreScript.ScoreValue > slider.maxValue) // si le score est plus gros que xp max level
        {
            PlayerData.Levels ++;
            experienceIntermediaire = slider.maxValue - experienceActual;
            experienceActual = 0;
            experienceActual = ScoreScript.ScoreValue - experienceIntermediaire;
            slider.maxValue *= 1.2f;

            if (experienceActual > slider.maxValue) // si xp depasse la max value du slider
            {
                PlayerData.Levels ++;

                experienceActual = Random.Range(0, slider.maxValue);               
                slider.maxValue *= 1.2f;
            }
        }
        else if (ScoreScript.ScoreValue == slider.maxValue)
        {
            PlayerData.Levels ++;
            slider.maxValue *= 1.2f;

        }
        else
        { 
            experienceActual += ScoreScript.ScoreValue;                   
            if (experienceActual > slider.maxValue) // si xp depasse la max value du slider
            {              
                PlayerData.Levels ++;
                experienceActual -= ScoreScript.ScoreValue;
                experienceIntermediaire = slider.maxValue - experienceActual;
                
                experienceActual = 0;
                experienceActual = ScoreScript.ScoreValue - experienceIntermediaire;

                slider.maxValue *= 1.2f;
            }           
        }
        TextLevel.text = "level " + PlayerData.Levels;
    }

    IEnumerator WaitLastWeapon()  //compteur pour respawn
    {              
            Playing = false;
            yield return new WaitForSeconds(0.8f);
        if (AmmoNumberStart <= 0 && Playing == false)
        {           
            RescueUi.SetActive(true);
            GameOver();
        } 
        else if (AmmoNumberStart > 0 && Playing == false)
        {
            Playing = true;
        }
    }


    public void Rescue()
    {
        GameOverPopup.SetActive(false);
        Ressucite = true;
        Playing = true;      
        BalloonSpawner.SetActive(true);
        Balloonrescue.SetActive(true);
        //RescueUi.SetActive(false);

        AmmoNumberStart = PlayerData.Weapons[PlayerData.CurrentWeapon].Ammo + AmmoShopScript.AmmoUpgrade;
        Destroyer.LifeNumber = life + LifeShopScript.LifeUpgrade;
    }


}
