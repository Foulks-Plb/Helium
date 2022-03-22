using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public GameObject[] Weapons;
    public int[] PriceWeapons;
    public int[] AmmoWeapons;

    public bool[] Lock;
    public GameObject BuyButtonWeapon;
    public GameObject StartGame;
    public Text PriceText;
    public PlayerData playerData;

    public int Selector;

    // Start is called before the first frame update
    void Start()
    {
        Weapons[Selector].SetActive(true);
        VerifLock();

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void NextWeapon()
    {             
        Selector += 1;       

        if (Selector >= Weapons.Length )
        {            
            Selector = 0;
            Weapons[Weapons.Length - 1].SetActive(false);
            Weapons[Selector].SetActive(true);

        }
        else
        {
            Weapons[Selector].SetActive(true);
            Weapons[Selector-1].SetActive(false);

        }
        VerifLock();
    }


    public void BackWeapon()
    {
        Selector -= 1;

        if (Selector < 0)
        {
            Selector = Weapons.Length - 1;
            Weapons[0].SetActive(false);
            Weapons[Selector].SetActive(true);
        }
        else
        {
            Weapons[Selector].SetActive(true);
            Weapons[Selector + 1].SetActive(false);


        }
        VerifLock();

    }


    public void BuyWeapon()
    {
        if (playerData.CoinsAmount >= PriceWeapons[Selector])
        {
            playerData.CoinsAmount -= PriceWeapons[Selector];
            Lock[Selector] = false;
            VerifLock();
        }
        
    }



    public void VerifLock()
    {
        if (Lock[Selector])
        {
            BuyButtonWeapon.SetActive(true);
            StartGame.SetActive(false);
            PriceText.enabled = true;
            PriceText.text = PriceWeapons[Selector].ToString();
        }
        else
        {
            BuyButtonWeapon.SetActive(false);
            StartGame.SetActive(true);
            PriceText.enabled = false;
        }

    }
}
