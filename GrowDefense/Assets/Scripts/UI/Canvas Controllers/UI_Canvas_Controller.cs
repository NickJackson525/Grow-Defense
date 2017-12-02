using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Canvas_Controller : MonoBehaviour
{
    #region Variables

    public Audio_Manager audioManager;
    public GameObject instructionsWindow;
    public GameObject gameOverWindow;
    public GameObject gameOverMenuButton;
    //public GameObject gameOverNextLevelButton;
    public GameObject gameOverTitle;
    public GameObject settingsWindow;
    public GameObject shopButton;
    public Button playButton;
    public Button instructionsButton;
    public Button creditsButton;
    public Button instructionsBack;
    public Button creditsBack;
    public Button mainMenu;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();
        GameManager.Instance.firePlantsGrown = 0;
        GameManager.Instance.gameOver = false;
        GameManager.Instance.money = 200;
        GameManager.Instance.waterLevel = 100;

        if (playButton)
        {
            if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
            {
                playButton.Select();
            }

        }
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        GameManager.Instance.Update();

        if (GameManager.Instance.gameOver)
        {
            gameOverWindow.SetActive(true);
            gameOverMenuButton.SetActive(true);
            //gameOverNextLevelButton.SetActive(true);

            if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
            {
                mainMenu.Select();
            }

            if ((GameManager.Instance.firePlantsGrown >= GameManager.Instance.firePlantsRequired) && (GameManager.Instance.icePlantsGrown >= GameManager.Instance.icePlantsRequired) && (GameManager.Instance.voidPlantsGrown >= GameManager.Instance.voidPlantsRequired))
            {
                gameOverTitle.GetComponent<Text>().text = "You Win!";
            }
            else
            {
                gameOverTitle.GetComponent<Text>().text = "You Lose!";
            }
        }
	}

    #endregion

    #region Public Methods

        #region Start Game

        public void StartGame()
        {
            audioManager.PlayButtonSound();
            shopButton.SetActive(true);
            gameOverMenuButton.SetActive(false);
            //gameOverNextLevelButton.SetActive(false);
            gameOverWindow.SetActive(false);

            GameManager.Instance.StartLevel(GameManager.Instance.currentLevel);
            GameManager.Instance.gameStarted = true;

            switch(GameManager.Instance.currentLevel)
            {
                case GameManager.Level.ONE:
                    GameManager.Instance.currentLevel = GameManager.Level.TWO;
                    break;
                case GameManager.Level.TWO:
                    GameManager.Instance.currentLevel = GameManager.Level.THREE;
                    break;
                case GameManager.Level.THREE:
                    GameManager.Instance.currentLevel = GameManager.Level.FOUR;
                    break;
            }
        }

        #endregion

        #region Load Scene

        public void Load_Scene(string sceneName)
        {
            audioManager.PlayButtonSound();
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        #endregion

        #region Instructions

        public void InstructionsOpen()
        {
            audioManager.PlayButtonSound();
            instructionsWindow.SetActive(true);

            if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
            {
                instructionsBack.Select();
            }
        }

        public void InstructionsClose()
        {
            audioManager.PlayButtonSound();
            instructionsWindow.SetActive(false);

            if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
            {
                instructionsButton.Select();
            }
        }

        #endregion

        #region Settings

        public void SettingsOpenClose()
        {
            audioManager.PlayButtonSound();

            if (settingsWindow.activeSelf)
            {
                settingsWindow.SetActive(false);
            }
            else
            {
                settingsWindow.SetActive(true);
            }
        }

        #endregion

        #region Set Controls

        public void SetControls(string newControls)
        {
            audioManager.PlayButtonSound();

            switch (newControls)
            {
                case "WASD":
                    GameManager.Instance.currentControls = GameManager.ControlScheme.WASD;
                    break;
                case "Arrows":
                    GameManager.Instance.currentControls = GameManager.ControlScheme.ARROWS;
                    break;
                case "IJKL":
                    GameManager.Instance.currentControls = GameManager.ControlScheme.IJKL;
                    break;
                default:
                    GameManager.Instance.currentControls = GameManager.ControlScheme.WASD;
                    break;
            }
        }

        #endregion

        #region Credits

        public void CreditsOpen()
        {
            audioManager.PlayButtonSound();
            gameOverWindow.SetActive(true);

            if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
            {
                creditsBack.Select();
            }
        }

        public void CreditsClose()
        {
            audioManager.PlayButtonSound();
            gameOverWindow.SetActive(false);
            
            if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
            {
                creditsButton.Select();
            }
        }

        #endregion

        #region Main Menu

        public void MainMenu()
        {
            audioManager.PlayButtonSound();
            GameManager.Instance.firePlantsGrown = 0;
            GameManager.Instance.gameOver = false;
            GameManager.Instance.pauseGame = false;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.purchasedFireUpgrade = false;
            GameManager.Instance.purchasedIceUpgrade = false;
            GameManager.Instance.purchasedVoidUpgrade = false;
            GameManager.Instance.purchasedWaterEfficiency = false;
            GameManager.Instance.money = 200;
            GameManager.Instance.dayTimer = 900;
            GameManager.Instance.waveNumber = 1;
            GameManager.Instance.firePlantsGrown = 0;
            GameManager.Instance.icePlantsGrown = 0;
            GameManager.Instance.voidPlantsGrown = 0;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.FIRE;
            GameManager.Instance.gameStarted = false;
            Load_Scene("Main Menu");
        }

        #endregion

    #endregion
}
