using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFx : MonoBehaviour
{
    public static AudioClip CoinPlusSound0, CoinPlusSound1, CoinPlusSound2; //ok
    public static AudioClip LaunchWeaponSound0, LaunchWeaponSound1, LaunchWeaponSound2; //ok
    public static AudioClip SpawnBalloonSound0, SpawnBalloonSound1, SpawnBalloonSound2, SpawnBalloonSound3; //ok

    public static AudioClip UiClickSound, UiClickBackSound; // ok
    public static AudioClip BalloonPopSound; //ok mais il faudrait des sons variés
    public static AudioClip LooseLifeSound; // ok
    public static AudioClip GameOverSound1, GameOverSound2; //ok (1)
    public static AudioClip ClickSimpleSound; //ok
    public static AudioClip BuySound, CantBuySound; //ok
    public static AudioClip LifePlusSound, AmmoPlusSound;// ok
    public static AudioClip CutInFloorSound;

    static AudioSource audioSrc;
    // Start is call before the first frame update
    void Start()
    {
        UiClickSound = Resources.Load<AudioClip>("UiClick");
        UiClickBackSound = Resources.Load<AudioClip>("UiClickBack");
        BuySound = Resources.Load<AudioClip>("Buy");
        CantBuySound = Resources.Load<AudioClip>("CantBuy");
        ClickSimpleSound = Resources.Load<AudioClip>("ClickWeapon");
        LooseLifeSound = Resources.Load<AudioClip>("LooseLife");
        BalloonPopSound = Resources.Load<AudioClip>("BalloonPop");
        CutInFloorSound = Resources.Load<AudioClip>("CutInFloor");

        CoinPlusSound0 = Resources.Load<AudioClip>("CoinPlus0");
        CoinPlusSound1 = Resources.Load<AudioClip>("CoinPlus1");
        CoinPlusSound2 = Resources.Load<AudioClip>("CoinPlus2");

        LifePlusSound = Resources.Load<AudioClip>("LifePlus");
        AmmoPlusSound = Resources.Load<AudioClip>("AmmoPlus");

        GameOverSound1 = Resources.Load<AudioClip>("GameOver1");
        GameOverSound2 = Resources.Load<AudioClip>("GameOver2");

        SpawnBalloonSound0 = Resources.Load<AudioClip>("SpawnBalloon0");
        SpawnBalloonSound1 = Resources.Load<AudioClip>("SpawnBalloon1");
        SpawnBalloonSound2 = Resources.Load<AudioClip>("SpawnBalloon2");
        SpawnBalloonSound3 = Resources.Load<AudioClip>("SpawnBalloon3");
        

        LaunchWeaponSound0 = Resources.Load<AudioClip>("LaunchWeapon0");
        LaunchWeaponSound1 = Resources.Load<AudioClip>("LaunchWeapon1");
        LaunchWeaponSound2 = Resources.Load<AudioClip>("LaunchWeapon2");



        audioSrc = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "UiClick":
                audioSrc.PlayOneShot(UiClickSound, 0.8f);
                break;

            case "UiClickBack":
                audioSrc.PlayOneShot(UiClickBackSound);
                break;

            case "Buy":
                audioSrc.PlayOneShot(BuySound);
                break;

            case "CantBuy":
                audioSrc.PlayOneShot(CantBuySound);
                break;

            case "ClickSimple":
                audioSrc.PlayOneShot(ClickSimpleSound);
                break;

            case "GameOver1":
                audioSrc.PlayOneShot(GameOverSound1);
                break;

            case "GameOver2":
                audioSrc.PlayOneShot(GameOverSound2);
                break;

            case "LooseLife":
                audioSrc.PlayOneShot(LooseLifeSound);
                break;

            case "BalloonPop":
                audioSrc.PlayOneShot(BalloonPopSound, Random.Range(0.8f, 1f));
                break;

            case "LifePlus":
                audioSrc.PlayOneShot(LifePlusSound);
                break;

            case "AmmoPlus":
                audioSrc.PlayOneShot(AmmoPlusSound);
                break;

            case "CutInFloor":
                audioSrc.PlayOneShot(CutInFloorSound);
                break;





                // SoundFx.PlaySound ("CutInFloor");
        }
    }



    public static void RandomPopSound(int randompop)
    {
        switch (randompop)
        {
            case 0:
                audioSrc.PlayOneShot(SpawnBalloonSound0);
                break;

            case 1:
                audioSrc.PlayOneShot(SpawnBalloonSound1);
                break;

            case 2:
                audioSrc.PlayOneShot(SpawnBalloonSound2);
                break;

            case 3:
                audioSrc.PlayOneShot(SpawnBalloonSound3);
                break;

                // SoundFx.RandomPopSound (Random.Range(0, 7));
        }
    }



    public static void RandomLaunchWeaponSound(int randomLaunch)
    {
        switch (randomLaunch)
        {
            case 0:
                audioSrc.PlayOneShot(LaunchWeaponSound0);
                break;

            case 1:
                audioSrc.PlayOneShot(LaunchWeaponSound1);
                break;

            case 2:
                audioSrc.PlayOneShot(LaunchWeaponSound2);
                break;


                // SoundFx.RandomLaunchWeaponSound (Random.Range(0, 3));

        }
    }

    public static void RandomCoinPlusSound(int randomCoinPlus)
    {
        switch (randomCoinPlus)
        {
            case 0:
                audioSrc.PlayOneShot(CoinPlusSound0);
                break;

            case 1:
                audioSrc.PlayOneShot(CoinPlusSound1);
                break;

            case 2:
                audioSrc.PlayOneShot(CoinPlusSound2);
                break;

                // SoundFx.RandomCoinPlusSound (Random.Range(0, 3));

        }
    }

}
