using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceWeaponSelect : MonoBehaviour
{
    GameObject previousWeapon, nextWeapon, currentWeapon, TempWeapon;
    bool goNextWeapon, weaponSwitching;
    float timeSwitch = -1;

    Vector3[] posTemp;

    public GameObject Data;
    PlayerData playerData;

    public GameObject BuyButtonWeapon;
    public GameObject StartGame;
    public Text PriceText;

    // Start is called before the first frame update
    void Start()
    {
        playerData = Data.GetComponent<PlayerData>();

        posTemp = new Vector3[4];

        if ( playerData.CurrentWeapon > 0 && playerData.CurrentWeapon < playerData.Weapons.Count - 1) // when current weapon is either not first or last
        {
            previousWeaponCreate();

            currentWeaponCreate();

            nextWeaponCreate();
        }
        else if ( playerData.CurrentWeapon == playerData.Weapons.Count - 1) // when current weapon is the last one
        {
            previousWeaponCreate();

            currentWeaponCreate();
        }
        else // when current weapon is the first one
        {
            currentWeaponCreate();

            nextWeaponCreate();
        }

        if (!playerData.Weapons[playerData.CurrentWeapon].unlocked)
        {
            BuyButtonWeapon.SetActive(true);
            StartGame.SetActive(false);
            PriceText.enabled = true;
            PriceText.text = playerData.Weapons[playerData.CurrentWeapon].Price.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( !playerData.Weapons[playerData.CurrentWeapon].unlocked ) // if current weapon isn't unlocked
        {

        }

        if (timeSwitch > -1 && timeSwitch < .4f && goNextWeapon)
        {
            if ( previousWeapon != null)
                WeaponSwitch(previousWeapon.GetComponent<RectTransform>(), -1, 0, posTemp[0]);

            WeaponSwitch(currentWeapon.GetComponent<RectTransform>(), -1, 0.7f, posTemp[1]);
            WeaponSwitch(nextWeapon.GetComponent<RectTransform>(), -1, 1, posTemp[2]);

            if (TempWeapon != null)
                WeaponSwitch(TempWeapon.GetComponent<RectTransform>(), -1, 0.7f, posTemp[3]);

            timeSwitch += 1 * Time.deltaTime;
        }
        else if (timeSwitch > .4f && goNextWeapon)
        {
            Object.Destroy(previousWeapon);

            previousWeapon = currentWeapon;
            currentWeapon = nextWeapon;

            if (playerData.CurrentWeapon < playerData.Weapons.Count - 1)
            {
                nextWeapon = TempWeapon;
                TempWeapon = null;
            }
            else
            {
                nextWeapon = null;
            }
            

            timeSwitch = -1;
            weaponSwitching = false;

        }
        else if (timeSwitch > -1 && timeSwitch < 0.4f && !goNextWeapon)
        {
            WeaponSwitch(previousWeapon.GetComponent<RectTransform>(), 1, 1, posTemp[0]);
            WeaponSwitch(currentWeapon.GetComponent<RectTransform>(), 1, 0.7f, posTemp[1]);

            if (nextWeapon != null)
                WeaponSwitch(nextWeapon.GetComponent<RectTransform>(), 1, 0, posTemp[2]);

            if (TempWeapon != null)
                WeaponSwitch(TempWeapon.GetComponent<RectTransform>(), 1, 0.7f, posTemp[3]);

            timeSwitch += 1 * Time.deltaTime;
        }
        else if (timeSwitch > 0.4f && !goNextWeapon)
        {
            Object.Destroy(nextWeapon);

            nextWeapon = currentWeapon;
            currentWeapon = previousWeapon;

            if (playerData.CurrentWeapon < playerData.Weapons.Count - 1)
            {
                previousWeapon = TempWeapon;
                TempWeapon = null;
            }
            else
            {
                previousWeapon = null;
            }

            timeSwitch = -1;
            weaponSwitching = false;
        }
    }

    public void NextWeapon()
    {
        SoundFx.PlaySound("ClickSimple");

        if ( playerData.CurrentWeapon < playerData.Weapons.Count - 1 && !weaponSwitching)
        {
            goNextWeapon = true;
            weaponSwitching = true;

            playerData.CurrentWeapon++;

            if (playerData.CurrentWeapon < playerData.Weapons.Count - 1)
            {
                TempWeapon = Instantiate(playerData.Weapons[playerData.CurrentWeapon + 1].DisplayPrefab, transform);
                TempWeapon.GetComponent<RectTransform>().localPosition = new Vector3(100, 0, 0);
                TempWeapon.GetComponent<RectTransform>().localScale = Vector3.zero;

                posTemp[3] = TempWeapon.GetComponent<RectTransform>().localPosition;
            }

            if ( previousWeapon != null)
                posTemp[0] = previousWeapon.GetComponent<RectTransform>().localPosition;

            posTemp[1] = currentWeapon.GetComponent<RectTransform>().localPosition;

            posTemp[2] = nextWeapon.GetComponent<RectTransform>().localPosition;


            timeSwitch = 0;
            PlayerPrefs.SetInt("CurrentWeapon", playerData.CurrentWeapon);
            if (!playerData.Weapons[playerData.CurrentWeapon].unlocked)
            {
                BuyButtonWeapon.SetActive(true);
                StartGame.SetActive(false);
                PriceText.enabled = true;
                PriceText.text = playerData.Weapons[playerData.CurrentWeapon].Price.ToString();
            }
            else
            {
                BuyButtonWeapon.SetActive(false);
                StartGame.SetActive(true);
                PriceText.enabled = false;
            }
        }

    }

    public void PreviousWeapon()
    {
        SoundFx.PlaySound("ClickSimple");

        if (playerData.CurrentWeapon > 0 && !weaponSwitching)
        {
            goNextWeapon = false;
            weaponSwitching = true;

            playerData.CurrentWeapon--;

            if (playerData.CurrentWeapon > 0)
            {
                TempWeapon = Instantiate(playerData.Weapons[playerData.CurrentWeapon - 1].DisplayPrefab, transform);
                TempWeapon.GetComponent<RectTransform>().localPosition = new Vector3(-100, 0, 0);
                TempWeapon.GetComponent<RectTransform>().localScale = Vector3.zero;

                posTemp[3] = TempWeapon.GetComponent<RectTransform>().localPosition;
            }

            posTemp[0] = previousWeapon.GetComponent<RectTransform>().localPosition;

            posTemp[1] = currentWeapon.GetComponent<RectTransform>().localPosition;

            if (nextWeapon != null)
                posTemp[2] = nextWeapon.GetComponent<RectTransform>().localPosition;


            timeSwitch = 0;
            PlayerPrefs.SetInt("CurrentWeapon", playerData.CurrentWeapon);
            if (!playerData.Weapons[playerData.CurrentWeapon].unlocked)
            {
                BuyButtonWeapon.SetActive(true);
                StartGame.SetActive(false);
                PriceText.enabled = true;
                PriceText.text = playerData.Weapons[playerData.CurrentWeapon].Price.ToString();
            }
            else
            {
                BuyButtonWeapon.SetActive(false);
                StartGame.SetActive(true);
                PriceText.enabled = false;
            }
        }
    }

    void WeaponSwitch(RectTransform Weapon, int Dir, float scaleTarget, Vector3 currentPos)
    {
        Weapon.localPosition = Vector3.Slerp(Weapon.localPosition, currentPos + new Vector3(50 * Dir, 0, 0), timeSwitch);
        Weapon.localScale = Vector3.Slerp(Weapon.localScale, Vector3.one * scaleTarget, timeSwitch);

    }

    // Displayed Weapon Creator (For Start)
    void previousWeaponCreate()
    {
        previousWeapon = Instantiate(playerData.Weapons[playerData.CurrentWeapon - 1].DisplayPrefab, transform);

        previousWeapon.GetComponent<RectTransform>().localPosition = new Vector3(-50, 0, 0);
        previousWeapon.GetComponent<RectTransform>().localScale = Vector3.one * 0.7f;
    }

    void currentWeaponCreate()
    {
        currentWeapon = Instantiate(playerData.Weapons[playerData.CurrentWeapon].DisplayPrefab, transform);

    }

    void nextWeaponCreate()
    {
        nextWeapon = Instantiate(playerData.Weapons[playerData.CurrentWeapon + 1].DisplayPrefab, transform);

        nextWeapon.GetComponent<RectTransform>().localPosition = new Vector3(50, 0, 0);
        nextWeapon.GetComponent<RectTransform>().localScale = Vector3.one * 0.7f;
    }

    public void BuyWeapon()
    {
        if (playerData.CoinsAmount >= playerData.Weapons[playerData.CurrentWeapon].Price)
        {
            playerData.CoinsAmount -= playerData.Weapons[playerData.CurrentWeapon].Price;
            playerData.Weapons[playerData.CurrentWeapon].unlocked = true;
            PlayerPrefs.SetInt("Weapon-" + playerData.CurrentWeapon.ToString(), 1); //save Unlock Status
            PlayerPrefs.SetInt("Coins", playerData.CoinsAmount);

            BuyButtonWeapon.SetActive(false);
            StartGame.SetActive(true);
            PriceText.enabled = false;
        }

    }
    
}
