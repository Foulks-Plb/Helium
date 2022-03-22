using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject shopMenu;
    public GameObject Game;
    public GameObject Ammount;
    public GameObject LogoHelium;
    public GameObject GameOver;
    public GameObject BalloonSpawner;
    public GameObject Player;
    public GameObject MoreMoneyUI;
    public GameObject XpBar;
    public GameObject CantBuy;
    public GameObject Setting;
    public GameObject BestScoreMenu;
    public GameObject LeadearBoardUi;

    public Text InputTextName;
    public PlayerData playerData;

    public void ShopUi()
    {
        SoundFx.PlaySound("UiClick");
        menu.SetActive(false);
        shopMenu.SetActive(true);
        LogoHelium.SetActive(false);
       
    }

    public void CancelShop()
    {
        menu.SetActive(true);
        shopMenu.SetActive(false);
        MoreMoneyUI.SetActive(false);
        LogoHelium.SetActive(true);
        SoundFx.PlaySound("UiClickBack");
    }

    public void StartGame()
    {
        Game.SetActive(true);
        menu.SetActive(false);
        shopMenu.SetActive(false);
        Ammount.SetActive(false);
        LogoHelium.SetActive(false);
        Player.SetActive(true);
        XpBar.SetActive(false);
        GameOver.SetActive(false);
        BestScoreMenu.SetActive(false);
        SoundFx.PlaySound("UiClick");
    }

    public void MenuUI()
    {
        Game.SetActive(false);
        menu.SetActive(true);
        Ammount.SetActive(true);
        LogoHelium.SetActive(true);
        GameOver.SetActive(false);       
        Player.SetActive(false);
        XpBar.SetActive(true);
        BestScoreMenu.SetActive(true);
        SoundFx.PlaySound("UiClick");
    }

    public void MoreMoney()
    {       
        MoreMoneyUI.SetActive(true);
        CantBuy.SetActive(false);
        SoundFx.PlaySound("UiClick");
    }


    public void CancelCantBuy()
    {
        CantBuy.SetActive(false);       
        SoundFx.PlaySound("UiClickBack");
    }

    public void CancelMoreMoney()
    {
        MoreMoneyUI.SetActive(false);
        SoundFx.PlaySound("UiClickBack");

    }

    public void Settings()
    {
        Setting.SetActive(true);
        menu.SetActive(false);
        LogoHelium.SetActive(false);
        SoundFx.PlaySound("UiClick");
    }

    public void CancelSettings()
    {
        Setting.SetActive(false);
        menu.SetActive(true);
        LogoHelium.SetActive(true);
        SoundFx.PlaySound("UiClickBack");
    }

    public void LeaderBoard()
    {
        LeadearBoardUi.SetActive(true);
        menu.SetActive(false);
        LogoHelium.SetActive(false);
        InputTextName.text = playerData.PlayerName;
        SoundFx.PlaySound("UiClick");
    }

    public void CancelLeaderBoard()
    {
        LeadearBoardUi.SetActive(false);
        menu.SetActive(true);
        LogoHelium.SetActive(true);
        SoundFx.PlaySound("UiClickBack");
    }


}
