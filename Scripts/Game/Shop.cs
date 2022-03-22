using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//////////////////////////////////////////////////////////////////
//                                                              //
//          OLD Script for weapon selection (not working)       //
//                                                              //
//////////////////////////////////////////////////////////////////


public class Shop : MonoBehaviour
{

    PlayerData playerData;
    public Vector3 weaponShopPos = new Vector3( 0, 25, 0);
    public GameObject WeaponDisplayer;

    bool weaponSwitching = false;
    bool nextWeapon;
    float timeSwitch = -1;
    Vector3[] posTemp;
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();


        for ( int i = 0; i < 4; i++)
        {
            if (playerData.CurrentWeapon == 0)
            {
                if ( i > 0)
                {
                    WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                }
                else
                {
                    //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                }
            }
            else if (playerData.CurrentWeapon == playerData.Weapons.Count - 1)
            {
                if (i < 2)
                {
                    WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                }
                else
                {
                    //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                }
            }
            else
            {
                if ( playerData.Weapons.Count < 4)
                {
                    if ( i < 4)
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i].sprite;
                    }
                }
                else
                {
                    WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i].sprite;
                }
                
            }

        }

        posTemp = new Vector3[4];
    }

    // Update is called once per frame
    void Update()
    {

        if ( timeSwitch > -1 && timeSwitch < 1 && nextWeapon)
        {
            WeaponSwitch(WeaponDisplayer.transform.GetChild(0).GetComponent<RectTransform>(), -1, 0.3f, posTemp[0] );
            WeaponSwitch(WeaponDisplayer.transform.GetChild(1).GetComponent<RectTransform>(), -1, 0.3f, posTemp[1] );
            WeaponSwitch(WeaponDisplayer.transform.GetChild(2).GetComponent<RectTransform>(), -1, 0.5f, posTemp[2] );
            WeaponSwitch(WeaponDisplayer.transform.GetChild(3).GetComponent<RectTransform>(), -1, 0.3f, posTemp[3] );

            timeSwitch += 1 * Time.deltaTime;
        }
        else if ( timeSwitch > 1 && nextWeapon)
        {
            //WeaponDisplayer.transform.GetChild(0).GetComponent<Image>().enabled = false;


            timeSwitch = -1;
            weaponSwitching = false;
        }
        else if (timeSwitch > -1 && timeSwitch < 1 && !nextWeapon)
        {
            WeaponSwitch(WeaponDisplayer.transform.GetChild(0).GetComponent<RectTransform>(), 1, 0.5f, posTemp[0]);
            WeaponSwitch(WeaponDisplayer.transform.GetChild(1).GetComponent<RectTransform>(), 1, 0.3f, posTemp[1]);
            WeaponSwitch(WeaponDisplayer.transform.GetChild(2).GetComponent<RectTransform>(), 1, 0.3f, posTemp[2]);
            WeaponSwitch(WeaponDisplayer.transform.GetChild(3).GetComponent<RectTransform>(), 1, 0.3f, posTemp[3]);

            timeSwitch += 1 * Time.deltaTime;
        }
        else if (timeSwitch > 1 && !nextWeapon)
        {
            if (playerData.CurrentWeapon > 1)
            {
               // WeaponDisplayer.transform.GetChild(3).GetComponent<Image>().enabled = true;
            }
                

            timeSwitch = -1;
            weaponSwitching = false;
        }

    }


    // Weapons Shop/Selector
    public void NextWeapon()
    {
        if (playerData.CurrentWeapon < playerData.Weapons.Count - 1 && !weaponSwitching)
        {
            nextWeapon = true;
            weaponSwitching = true;

            for (int i = 0; i < 4; i++)
            {
                if (playerData.CurrentWeapon == 0)
                {
                    if (i > 0)
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                    }
                    else
                    {
                        //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                    }
                }
                else if (playerData.CurrentWeapon == playerData.Weapons.Count - 1)
                {
                    if (i < 2)
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                    }
                    else
                    {
                        //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                    }
                }
                else
                {
                    if (playerData.Weapons.Count < 4)
                    {
                        if (i < 3)
                        {
                            WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                        }
                        else
                        {
                            //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                        }
                    }
                    else
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                    }

                }

            }

            //WeaponDisplayer.transform.GetChild(0).GetComponent<Image>().enabled = true;
            //WeaponDisplayer.transform.GetChild(3).GetComponent<Image>().enabled = true;

            WeaponDisplayer.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(-55, 0, 0);
            WeaponDisplayer.transform.GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            WeaponDisplayer.transform.GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3(55, 0, 0);
            WeaponDisplayer.transform.GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(110, 0, 0);


            playerData.CurrentWeapon ++;

            posTemp[0] = WeaponDisplayer.transform.GetChild(0).GetComponent<RectTransform>().localPosition;
            posTemp[1] = WeaponDisplayer.transform.GetChild(1).GetComponent<RectTransform>().localPosition;
            posTemp[2] = WeaponDisplayer.transform.GetChild(2).GetComponent<RectTransform>().localPosition;
            posTemp[3] = WeaponDisplayer.transform.GetChild(3).GetComponent<RectTransform>().localPosition;

            timeSwitch = 0;
        }
    }

    public void PreviousWeapon()
    {
        if (playerData.CurrentWeapon > 0 && !weaponSwitching)
        {
            nextWeapon = false;
            weaponSwitching = true;

            for (int i = 0; i < 4; i++)
            {
                if (playerData.CurrentWeapon == 0)
                {
                    if (i > 0)
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                    }
                    else
                    {
                        //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                    }
                }
                else if (playerData.CurrentWeapon == playerData.Weapons.Count - 1)
                {
                    if (i < 2)
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                    }
                    else
                    {
                        //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                    }
                }
                else
                {
                    if (playerData.Weapons.Count < 4)
                    {
                        if (i < 3)
                        {
                            WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                        }
                        else
                        {
                            //WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
                        }
                    }
                    else
                    {
                        WeaponDisplayer.transform.GetChild(i).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon + i - 1].sprite;
                    }

                }

            }

            //WeaponDisplayer.transform.GetChild(0).GetComponent<Image>().enabled = true;
            if (playerData.CurrentWeapon > 1)
            {
                WeaponDisplayer.transform.GetChild(3).GetComponent<Image>().sprite = playerData.Weapons[playerData.CurrentWeapon - 2].sprite;
            }
            else
            {
                //WeaponDisplayer.transform.GetChild(3).GetComponent<Image>().enabled = false;
            }
            

            WeaponDisplayer.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(-55, 0, 0);
            WeaponDisplayer.transform.GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            WeaponDisplayer.transform.GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3(55, 0, 0);
            WeaponDisplayer.transform.GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(-110, 0, 0);

            playerData.CurrentWeapon--;

            posTemp[0] = WeaponDisplayer.transform.GetChild(0).GetComponent<RectTransform>().localPosition;
            posTemp[1] = WeaponDisplayer.transform.GetChild(1).GetComponent<RectTransform>().localPosition;
            posTemp[2] = WeaponDisplayer.transform.GetChild(2).GetComponent<RectTransform>().localPosition;
            posTemp[3] = WeaponDisplayer.transform.GetChild(3).GetComponent<RectTransform>().localPosition;

            timeSwitch = 0;

        }
    }

    void WeaponSwitch(RectTransform Weapon, int Dir, float scaleTarget, Vector3 currentPos)
    {


        Weapon.localPosition = Vector3.Slerp(Weapon.localPosition, currentPos + new Vector3(55 * Dir, 0, 0), timeSwitch);
        Weapon.localScale = Vector3.Slerp(Weapon.localScale, Vector3.one * scaleTarget, timeSwitch);
    }
    */
}
