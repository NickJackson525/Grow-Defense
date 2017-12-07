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
        if (GameManager.Instance.gameOver)
        {
            shopWindow.SetActive(false);
        }

        if (timer > 0)
        {
            timer--;
        }
        else
        {
            if (GameManager.Instance.placingUpgrade)
            {
                GameManager.Instance.pauseGame = false;
            }
        }

        if(GameManager.Instance.purchasedWaterEfficiency)
        {
            waterEfficiencyUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if (GameManager.Instance.purchasedFireUpgrade)
        {
            fireUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if (GameManager.Instance.purchasedIceUpgrade)
        {
            iceUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if (GameManager.Instance.purchasedVoidUpgrade)
        {
            voidUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
        }

        if(shopWindow.activeSelf)
        {
            GameManager.Instance.pauseGame = true;
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
                    GameManager.Instance.pauseGame = false;
                }
                else
                {
                    shopWindow.SetActive(true);
                    shopButton.GetComponentInChildren<Text>().text = "Exit";
                    GameManager.Instance.pauseGame = true;
                }
            }
        }

        #endregion

        #region Water Efficiency Upgrade

        public void WaterEfficiencyUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((GameManager.Instance.money >= 200) && !GameManager.Instance.purchasedWaterEfficiency)
            {
                waterEfficiencyUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
                GameManager.Instance.purchasedWaterEfficiency = true;
                GameManager.Instance.money -= 200;
            }
        }

        #endregion

        #region Fire Plant Upgrade

        public void FirePlantUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((GameManager.Instance.money >= 200) && !GameManager.Instance.purchasedFireUpgrade)
            {
                GameManager.Instance.money -= 200;
                GameManager.Instance.purchasedFireUpgrade = true;
                fireUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        #endregion

        #region Ice Plant Upgrade

        public void IcePlantUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((GameManager.Instance.money >= 200) && !GameManager.Instance.purchasedIceUpgrade)
            {
                GameManager.Instance.money -= 200;
                GameManager.Instance.purchasedIceUpgrade = true;
                iceUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        #endregion

        #region Void Plant Upgrade

        public void VoidPlantUpgrade()
        {
            audioManager.PlayButtonSound();

            if ((GameManager.Instance.money >= 200) && !GameManager.Instance.purchasedVoidUpgrade)
            {
                GameManager.Instance.money -= 200;
                GameManager.Instance.purchasedVoidUpgrade = true;
                voidUpgradeButton.GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        #endregion

    #endregion
}
