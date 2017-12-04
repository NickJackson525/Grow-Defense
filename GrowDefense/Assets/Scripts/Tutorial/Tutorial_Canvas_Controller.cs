﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Canvas_Controller : MonoBehaviour
{
    public Audio_Manager audioManager;
    public GameObject dialogWindow;
    public GameObject nextButton;
    public GameObject dialogBox;
    public GameObject gameOverWindow;
    public GameObject shopButton;
    public GameObject tutorialSelect1;
    public GameObject tutorialSelect2;
    public GameObject tutorialSelect3;
    public GameObject spawner;
    public int flashTimer = 30;

    // Use this for initialization
    void Start ()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();
        GameManager.Instance.money = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(dialogWindow.activeSelf)
        {
            GameManager.Instance.pauseGame = true;
        }

        #region Flash selects

        if(Tutorial_Manager.Instance.InstructionsIndex == 4)
        {
            if (flashTimer > 0)
            {
                flashTimer--;
            }
            else
            {
                if (tutorialSelect1.gameObject.activeSelf)
                {
                    tutorialSelect1.gameObject.SetActive(false);
                }
                else
                {
                    tutorialSelect1.gameObject.SetActive(true);
                }

                flashTimer = 30;
            }
        }
        else if (Tutorial_Manager.Instance.InstructionsIndex == 7)
        {
            if (flashTimer > 0)
            {
                flashTimer--;
            }
            else
            {
                if (tutorialSelect3.gameObject.activeSelf)
                {
                    tutorialSelect3.gameObject.SetActive(false);
                }
                else
                {
                    tutorialSelect3.gameObject.SetActive(true);
                }

                flashTimer = 30;
            }
        }

        #endregion

        #region Check completion of tutorial stage

        if ((Tutorial_Manager.Instance.InstructionsIndex == 4) && GameManager.Instance.money == 0)
        {
            dialogWindow.SetActive(true);
            GameManager.Instance.pauseGame = true;
        }
        else if((Tutorial_Manager.Instance.InstructionsIndex == 5) && GameManager.Instance.waterLevel < 100)
        {
            dialogWindow.SetActive(true);
            GameManager.Instance.pauseGame = true;
        }
        else if ((Tutorial_Manager.Instance.InstructionsIndex == 7) && GameManager.Instance.money == 0)
        {
            dialogWindow.SetActive(true);
            GameManager.Instance.pauseGame = true;
        }
        else if ((Tutorial_Manager.Instance.InstructionsIndex == 8) && GameManager.Instance.money > 0)
        {
            dialogWindow.SetActive(true);
            GameManager.Instance.pauseGame = true;
            GameManager.Instance.currentPhase = GameManager.Phase.DAY;
        }

        #endregion
    }

    public void NextDialogText(GameObject button)
    {
        dialogBox.GetComponent<Text>().text = Tutorial_Manager.Instance.InstructionsText[Tutorial_Manager.Instance.InstructionsIndex];

        switch (Tutorial_Manager.Instance.InstructionsIndex)
        {
            case 1:
                button.GetComponentInChildren<Text>().text = "Next";
                break;
            case 2:
                button.GetComponentInChildren<Text>().text = "Okay";
                break;
            case 3:
                GameManager.Instance.money += 25;
                GameManager.Instance.pauseGame = false;
                dialogWindow.SetActive(false);
                button.GetComponentInChildren<Text>().text = "Okay";
                break;
            case 4:
                GameManager.Instance.pauseGame = false;
                dialogWindow.SetActive(false);
                button.GetComponentInChildren<Text>().text = "Next";
                break;
            case 5:
                button.GetComponentInChildren<Text>().text = "Okay";
                break;
            case 6:
                GameManager.Instance.money += 50;
                GameManager.Instance.pauseGame = false;
                dialogWindow.SetActive(false);
                button.GetComponentInChildren<Text>().text = "Okay";
                break;
            case 7:
                GameManager.Instance.currentPhase = GameManager.Phase.NIGHT;
                spawner.GetComponent<Spawner>().SpawnBug();
                dialogWindow.SetActive(false);
                GameManager.Instance.pauseGame = false;
                button.GetComponentInChildren<Text>().text = "Next";
                break;
            case 8:
                button.GetComponentInChildren<Text>().text = "Okay";
                break;
            case 9:
                //TODO: add code to spawn quests here (make sure its a 1 fire plant quest)
                dialogWindow.SetActive(false);
                GameManager.Instance.pauseGame = false;
                button.GetComponentInChildren<Text>().text = "Okay";
                break;
        }

        Tutorial_Manager.Instance.InstructionsIndex++;
    }

    #region Start Tutorial

    public void StartTutorial()
    {
        audioManager.PlayButtonSound();
        dialogWindow.SetActive(true);
        shopButton.SetActive(true);
        gameOverWindow.SetActive(false);
        Tutorial_Manager.Instance.StartTutorial();
        NextDialogText(nextButton);
    }

    #endregion
}
