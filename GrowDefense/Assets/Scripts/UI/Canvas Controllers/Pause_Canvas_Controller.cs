using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Canvas_Controller : MonoBehaviour
{
    #region Variables

    public Audio_Manager audioManager;
    public GameObject shopWindow;
    public GameObject pauseWindow;
    public GameObject pauseTitle;
    public GameObject objectivesButton;
    public GameObject controlsButton;
    public GameObject instructionsButton;
    public GameObject creditsButton;
    public GameObject backstoryButton;
    public GameObject mainMenuButton;
    public GameObject objectivesPanel;
    public GameObject controlsPanel;
    public GameObject instructionsPanel;
    public GameObject creditsPanel;
    public GameObject backstoryPanel;

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
        UpdateObjectives(GameManager.Instance.Objective1);
        UpdateObjectives(GameManager.Instance.Objective2);
        UpdateObjectives(GameManager.Instance.Objective3);

        if (Input.GetKeyUp(KeyCode.Escape) && !shopWindow.activeSelf)
        {
            if(pauseWindow.activeSelf)
            {
                BackToPauseMenu();
                pauseWindow.SetActive(false);
                GameManager.Instance.pauseGame = false;
            }
            else
            {
                pauseWindow.SetActive(true);
                GameManager.Instance.pauseGame = true;
            }
        }

        if (pauseWindow.activeSelf)
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

        #region Objectives Window

        public void ObjectivesOpen()
        {
            audioManager.PlayButtonSound();
            pauseTitle.SetActive(false);
            objectivesButton.SetActive(false);
            controlsButton.SetActive(false);
            instructionsButton.SetActive(false);
            creditsButton.SetActive(false);
            backstoryButton.SetActive(false);
            mainMenuButton.SetActive(false);
            objectivesPanel.SetActive(true);
            controlsPanel.SetActive(false);
            instructionsPanel.SetActive(false);
            creditsPanel.SetActive(false);
            backstoryPanel.SetActive(false);
        }

        #endregion

        #region Controls Window

        public void ControlsOpen()
        {
            audioManager.PlayButtonSound();
            pauseTitle.SetActive(false);
            objectivesButton.SetActive(false);
            controlsButton.SetActive(false);
            instructionsButton.SetActive(false);
            creditsButton.SetActive(false);
            backstoryButton.SetActive(false);
            mainMenuButton.SetActive(false);
            objectivesPanel.SetActive(false);
            controlsPanel.SetActive(true);
            instructionsPanel.SetActive(false);
            creditsPanel.SetActive(false);
            backstoryPanel.SetActive(false);
        }

        #endregion

        #region Instructions Window

        public void InstructionsOpen()
        {
            audioManager.PlayButtonSound();
            pauseTitle.SetActive(false);
            objectivesButton.SetActive(false);
            controlsButton.SetActive(false);
            instructionsButton.SetActive(false);
            creditsButton.SetActive(false);
            backstoryButton.SetActive(false);
            mainMenuButton.SetActive(false);
            objectivesPanel.SetActive(false);
            controlsPanel.SetActive(false);
            instructionsPanel.SetActive(true);
            creditsPanel.SetActive(false);
            backstoryPanel.SetActive(false);
        }

        #endregion

        #region Credits Window

        public void CreditsOpen()
        {
            audioManager.PlayButtonSound();
            pauseTitle.SetActive(false);
            objectivesButton.SetActive(false);
            controlsButton.SetActive(false);
            instructionsButton.SetActive(false);
            creditsButton.SetActive(false);
            backstoryButton.SetActive(false);
            mainMenuButton.SetActive(false);
            objectivesPanel.SetActive(false);
            controlsPanel.SetActive(false);
            instructionsPanel.SetActive(false);
            creditsPanel.SetActive(true);
            backstoryPanel.SetActive(false);
        }

        #endregion

        #region Backstory Window

        public void BackstoryOpen()
        {
            audioManager.PlayButtonSound();
            pauseTitle.SetActive(false);
            objectivesButton.SetActive(false);
            controlsButton.SetActive(false);
            instructionsButton.SetActive(false);
            creditsButton.SetActive(false);
            backstoryButton.SetActive(false);
            mainMenuButton.SetActive(false);
            objectivesPanel.SetActive(false);
            controlsPanel.SetActive(false);
            instructionsPanel.SetActive(false);
            creditsPanel.SetActive(false);
            backstoryPanel.SetActive(true);
        }

        #endregion

        #region Back To Pause Menu

        public void BackToPauseMenu()
        {
            audioManager.PlayButtonSound();
            pauseTitle.SetActive(true);
            objectivesButton.SetActive(true);
            controlsButton.SetActive(true);
            instructionsButton.SetActive(true);
            creditsButton.SetActive(true);
            backstoryButton.SetActive(true);
            mainMenuButton.SetActive(true);
            objectivesPanel.SetActive(false);
            controlsPanel.SetActive(false);
            instructionsPanel.SetActive(false);
            creditsPanel.SetActive(false);
            backstoryPanel.SetActive(false);
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

        #region Update Objectives

        public void UpdateObjectives(GameObject objective)
        {
            gameObject.SetActive(true);
            objective.GetComponent<ObjectiveData>().plant1.SetActive(false);
            objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(false);
            objective.GetComponent<ObjectiveData>().plant2.SetActive(false);
            objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(false);
            objective.GetComponent<ObjectiveData>().plant3.SetActive(false);
            objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(false);

            #region Update Basic

            if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().basicPlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = GameManager.Instance.basicPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().basicRequired;
            }

            #endregion

            #region Update Fire

            if (objective.GetComponent<ObjectiveData>().fireRequired > 0)
            {
                if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().firePlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = GameManager.Instance.firePlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().fireRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().firePlant;
                    objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = GameManager.Instance.firePlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().fireRequired;
                }
            }

            #endregion

            #region Update Ice

            if (objective.GetComponent<ObjectiveData>().iceRequired > 0)
            {
                if (objective.GetComponent<ObjectiveData>().fireRequired > 0)
                {
                    if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                    {
                        objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                        objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = GameManager.Instance.icePlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().iceRequired;
                    }
                    else
                    {
                        objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                        objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = GameManager.Instance.icePlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().iceRequired;
                    }
                }
                else if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = GameManager.Instance.icePlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().iceRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                    objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = GameManager.Instance.icePlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().iceRequired;
                }
            }

            #endregion

            #region Update Void

            if (objective.GetComponent<ObjectiveData>().voidRequired > 0)
            {
                if (objective.GetComponent<ObjectiveData>().iceRequired > 0)
                {
                    if (objective.GetComponent<ObjectiveData>().fireRequired > 0)
                    {
                        if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                        {
                            objective.GetComponent<ObjectiveData>().plant4.SetActive(true);
                            objective.GetComponent<ObjectiveData>().plant4Grown.SetActive(true);
                            objective.GetComponent<ObjectiveData>().plant4.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                            objective.GetComponent<ObjectiveData>().plant4Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                        }
                        else
                        {
                            objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                            objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                            objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                            objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                        }
                    }
                    else if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                    {
                        objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                        objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                    }
                    else
                    {
                        objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                        objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                    }
                }
                else if (objective.GetComponent<ObjectiveData>().fireRequired > 0)
                {
                    if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                    {
                        objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                        objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                    }
                    else
                    {
                        objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                        objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                    }
                }
                else if (objective.GetComponent<ObjectiveData>().basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                    objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = GameManager.Instance.voidPlantsHarvested + " / " + objective.GetComponent<ObjectiveData>().voidRequired;
                }
            }

            #endregion
        }

        #endregion

    #endregion
}
