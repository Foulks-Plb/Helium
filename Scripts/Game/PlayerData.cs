using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class Weapon
{
    [Header("                  Weapon Infos")]
    public string weaponName;

    [Space(10)]
    public GameObject ProjectilePrefab;

    [Space(10)]
    public int Ammo = 15;

    [Space(10)]
    public int Price = 100;

    [Space(10)]
    public GameObject DisplayPrefab;

    [Space(10)]
    public bool unlocked = false;
}

[Serializable]
public class Environement
{
    [Header("                  Environement Infos")]
    public GameObject EnvironementPrefab;

    [Space(10)]
    public bool unlocked = false;
}

[Serializable]
public class PlayerSkin
{
    [Header("                  PLayerSkin Infos")]
    public Sprite SkinSpriteBody;
    public Sprite SkinSpriteArm;

    [Space(10)]
    public bool unlocked = false;
}


public class PlayerData : MonoBehaviour
{
    public List<Weapon> Weapons;
    public List<Environement> environements;
    public List<PlayerSkin> playerSkins;
    public int CurrentMap = 0;
    public int CurrentWeapon = 0;
    public int CurrentPlayerSkin = 0;
    public int CoinsAmount;

    public int LevelAmmo;
    public int Levels;
    public float Experience;
    public int BestScore;
    public string PlayerName;
    public string GeneratedName;

    public GameObject txtCoins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtCoins.GetComponent<Text>().text = CoinsAmount.ToString();
        
    }
}
