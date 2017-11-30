using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Canvas_Controller : MonoBehaviour
{
    #region Variables

    public Audio_Manager audioManager;
    public GameObject shopWindow;
    public GameObject shopButton;
    public GameObject pauseWindow;
    public GameObject shopWindowTitle;
    public GameObject waterEfficiencyUpgradeButton;
    public GameObject fireUpgradeButton;
    public GameObject iceUpgradeButton;
    public GameObject voidUpgradeButton;
    int timer = 0;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if(timer > 0)
        {
            timer--;
        }
        else
        {
            if (Game_Manager.Instance.placingUpgrade)
            {
                Game_Manager.Instance.pauseGame = false;
            }
        }

        if(Game_Manager.Instance.purchasedWaterEfficiency)
        {
            waterEfficiencyUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if (Game_Manager.Instance.purchasedFireUpgrade)
        {
            fireUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if (Game_Manager.Instance.purchasedIceUpgrade)
        {
            iceUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if (Game_Manager.Instance.purchasedVoidUpgrade)
        {
            voidUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if(shopWindow.activeSelf)
        {
            Game_Manager.Instance.pauseGame = true;
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (shopWindow.activeSelf)
            {
                shopWindow.SetActive(false);
                Game_Manager.Instance.pauseGame = false;
            }
        }
    }

    #endregion

    #region Public Methods

        #region Load Scene

        public void Load_Scene(string sceneName)
        {
            audioManager.PlayButtonSound();
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        #endregion

        #region Shop Window

        public void ShopWindowOpenClose()
        {
            audioManager.PlayButtonSound();

            if (!pauseWindow.activeSelf)
            {
                if (shopWindow.activeSelf)
                {
                    shopWindow.SetActive(false);
                    shopButton.GetComponentInChildren<Text>().text = "Shop";
                    Game_Manager.Instance.pauseGame = false;
                }
                else
                {
                    shopWindow.SetActive(true);
                    shopButton.GetComponentInChildren<Text>().text = "Exit";
                    Game_Manager.Instance.pauseGame = true;
                }
            }
        }

        #endregion

        #region Water Efficiency Upgrade

        public void WaterEfficiencyUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((Game_Manager.Instance.money >= 200) && !Game_Manager.Instance.purchasedWaterEfficiency)
            {
                waterEfficiencyUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
                Game_Manager.Instance.purchasedWaterEfficiency = true;
                Game_Manager.Instance.money -= 200;
            }
        }

        #endregion

        #region Fire Plant Upgrade

        public void FirePlantUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((Game_Manager.Instance.money >= 200) && !Game_Manager.Instance.purchasedFireUpgrade)
            {
                Game_Manager.Instance.money -= 200;
                Game_Manager.Instance.purchasedFireUpgrade = true;
                fireUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        #endregion

        #region Ice Plant Upgrade

        public void IcePlantUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((Game_Manager.Instance.money >= 200) && !Game_Manager.Instance.purchasedIceUpgrade)
            {
                Game_Manager.Instance.money -= 200;
                Game_Manager.Instance.purchasedIceUpgrade = true;
                iceUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        #endregion

        #region Void Plant Upgrade

        public void VoidPlantUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((Game_Manager.Instance.money >= 200) && !Game_Manager.Instance.purchasedVoidUpgrade)
            {
                Game_Manager.Instance.money -= 200;
                Game_Manager.Instance.purchasedVoidUpgrade = true;
                voidUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        #endregion

    #endregion
}
