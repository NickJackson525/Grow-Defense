using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Canvas_Controller : MonoBehaviour
{
    #region Variables

    public Audio_Manager audioManager;
    public GameObject levelSelectWindow;
    public GameObject instructionsWindow;
    public GameObject gameOverWindow;
    public GameObject gameOverMenuButton;
    public GameObject gameOverNextLevelButton;
    public GameObject gameOverTitle;
    public GameObject settingsWindow;
    public GameObject shopButton;
    public GameObject helpPopup;
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

        if ((GameManager.Instance.totalUnwateredPlants >= 2) && GameManager.Instance.gameStarted)
        {
            helpPopup.GetComponent<HelpPopup>().thisHelpType = HelpPopup.HelpType.DRYPLANTS;
            helpPopup.GetComponent<HelpPopup>().MoveDown();
        }

        if (GameManager.Instance.gameOver)
        {
            if (!gameOverWindow.activeSelf)
            {
                gameOverWindow.SetActive(true);
                gameOverMenuButton.SetActive(true);

                if ((Input.GetJoystickNames().Length > 0) && (Input.GetJoystickNames()[0] != ""))
                {
                    mainMenu.Select();
                }

                if (GameManager.Instance.questsCompleted >= GameManager.Instance.questsRequired)
                {
                    gameOverTitle.GetComponent<Text>().text = "You Win!";
                    gameOverNextLevelButton.SetActive(true);
                }
                else
                {
                    gameOverTitle.GetComponent<Text>().text = "You Lose!";
                }
            }
        }
	}

    #endregion

    #region Public Methods

        #region Play Game

        public void PlayGame(int levelNumber)
        {
            switch(levelNumber)
            {
                case 1:
                    SceneManager.LoadScene("Map 1");
                    break;
                case 2:
                    SceneManager.LoadScene("Map 2");
                    break;
                case 3:
                    SceneManager.LoadScene("Map 3");
                    break;
                case 4:
                    SceneManager.LoadScene("Map 4");
                    break;
            }
        }

        #endregion

        #region Level Select

        public void LevelSelectWindow()
        {
            audioManager.PlayButtonSound();

            if (levelSelectWindow.activeSelf)
            {
                levelSelectWindow.SetActive(false);
            }
            else
            {
                levelSelectWindow.SetActive(true);
            }
        }

        #endregion

        #region Start Game

        public void StartGame()
        {
            audioManager.PlayButtonSound();
            shopButton.SetActive(true);
            gameOverMenuButton.SetActive(false);
            gameOverNextLevelButton.SetActive(false);
            gameOverWindow.SetActive(false);
            GameManager.Instance.StartLevel();
        }

        #endregion

        #region Next Level

        public void NextLevel()
        {
            audioManager.PlayButtonSound();
            shopButton.SetActive(true);
            gameOverMenuButton.SetActive(false);
            gameOverNextLevelButton.SetActive(false);
            gameOverWindow.SetActive(false);
            GameManager.Instance.currentLevel++;
            GameManager.Instance.NextLevel();
        }

        #endregion

        #region Load Scene

        public void Load_Scene(string sceneName)
        {
            audioManager.PlayButtonSound();
            SceneManager.LoadScene(sceneName);
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
            GameManager.Instance.MainMenu();
            Load_Scene("Main Menu");
        }

        #endregion

    #endregion
}
