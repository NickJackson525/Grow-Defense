using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor.SceneManagement;

public class UI_Canvas_Controller : MonoBehaviour
{
    public GameObject instructionsWindow;
    public GameObject gameOverWindow;
    public GameObject gameOverTitle;
    public GameObject settingsWindow;
    public Sound buttonSuond;

	// Use this for initialization
	void Start ()
    {
        Game_Manager.Instance.firePlantsGrown = 0;
        Game_Manager.Instance.gameOver = false;
        Game_Manager.Instance.money = 200;
        Game_Manager.Instance.waterLevel = 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Game_Manager.Instance.Update();

        if (Game_Manager.Instance.gameOver)
        {
            gameOverWindow.SetActive(true);

            if (Game_Manager.Instance.firePlantsGrown >= 10)
            {
                gameOverTitle.GetComponent<Text>().text = "You Win!";
            }
            else
            {
                gameOverTitle.GetComponent<Text>().text = "You Lose!";
            }
        }
	}

    public void Load_Scene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void InstructionsOpen()
    {
        instructionsWindow.SetActive(true);
    }

    public void InstructionsClose()
    {
        instructionsWindow.SetActive(false);
    }

    public void SettingsOpenClose()
    {
        if (settingsWindow.activeSelf)
        {
            settingsWindow.SetActive(false);
        }
        else
        {
            settingsWindow.SetActive(true);
        }
    }

    public void SetControls(string newControls)
    {
        switch(newControls)
        {
            case "WASD":
                Game_Manager.Instance.currentControls = Game_Manager.ControlScheme.WASD;
                break;
            case "Arrows":
                Game_Manager.Instance.currentControls = Game_Manager.ControlScheme.ARROWS;
                break;
            case "IJKL":
                Game_Manager.Instance.currentControls = Game_Manager.ControlScheme.IJKL;
                break;
            default:
                Game_Manager.Instance.currentControls = Game_Manager.ControlScheme.WASD;
                break;
        }
    }

    public void CreditsOpen()
    {
        gameOverWindow.SetActive(true);
    }

    public void CreditsClose()
    {
        gameOverWindow.SetActive(false);
    }

    public void MainMenu()
    {
        Game_Manager.Instance.firePlantsGrown = 0;
        Game_Manager.Instance.gameOver = false;
        Load_Scene("Main Menu");
    }
}
