using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Canvas_Controller : MonoBehaviour
{
    #region Variables

    public GameObject shopWindow;
    public GameObject farmUpgradesButton;
    public GameObject plantUpgradesButton;
    public GameObject farmUpgradesWindow;
    public GameObject plantUpgradesWindow;
    int timer = 0;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
		
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
	}

    #endregion

    #region Public Methods

        #region Load Scene

        public void Load_Scene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

    #endregion

        #region Shop Window

        public void ShopWindowOpenClose()
        {
            if (shopWindow.activeSelf)
            {
                BackToPauseMenu();
                shopWindow.SetActive(false);
                Game_Manager.Instance.pauseGame = false;
            }
            else
            {
                shopWindow.SetActive(true);
                Game_Manager.Instance.pauseGame = true;
            }
        }

        #endregion

        #region Farm Upgrades Window

        public void FarmUpgradesWindow()
        {
            farmUpgradesButton.SetActive(false);
            plantUpgradesButton.SetActive(false);
            farmUpgradesWindow.SetActive(true);
            plantUpgradesWindow.SetActive(false);
        }

        #endregion

        #region Plant Upgrades Window

        public void PlantUpgradesWindow()
        {
            farmUpgradesButton.SetActive(false);
            plantUpgradesButton.SetActive(false);
            farmUpgradesWindow.SetActive(false);
            plantUpgradesWindow.SetActive(true);
        }

        #endregion

        #region Water Efficiency Upgrade

        public void WaterEfficiencyUpgrade()
        {

        }

        #endregion

        #region Sprinkler Upgrade

        public void SprinklerUpgrade()
        {
            if(Game_Manager.Instance.money >= 50)
            {
                Game_Manager.Instance.placingUpgrade = true;
                Game_Manager.Instance.currentUpgrade = Game_Manager.PlaceableUpgrade.Sprinkler;
                Game_Manager.Instance.money -= 50;
                farmUpgradesButton.SetActive(true);
                plantUpgradesButton.SetActive(true);
                farmUpgradesWindow.SetActive(false);
                plantUpgradesWindow.SetActive(false);
                shopWindow.SetActive(false);
                timer = 30;
            }
        }

        #endregion

        #region Fertilizer Upgrade

        public void FertilizerUpgrade()
        {
            if (Game_Manager.Instance.money >= 50)
            {
                Game_Manager.Instance.placingUpgrade = true;
                Game_Manager.Instance.currentUpgrade = Game_Manager.PlaceableUpgrade.Fertilizer;
                Game_Manager.Instance.money -= 50;
                farmUpgradesButton.SetActive(true);
                plantUpgradesButton.SetActive(true);
                farmUpgradesWindow.SetActive(false);
                plantUpgradesWindow.SetActive(false);
                shopWindow.SetActive(false);
                timer = 30;
            }
        }

        #endregion

        #region Back To Pause Menu

        public void BackToPauseMenu()
        {
            farmUpgradesButton.SetActive(true);
            plantUpgradesButton.SetActive(true);
            farmUpgradesWindow.SetActive(false);
            plantUpgradesWindow.SetActive(false);
        }

        #endregion

    #endregion
}
