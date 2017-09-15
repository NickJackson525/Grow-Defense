using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    public GameObject okayButton;
    public GameObject panel;
    public GameObject instructionsText;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Load_Scene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void Exit_Game()
    {
        
    }

    public void Okay_Button()
    {
        Destroy(okayButton);
        Destroy(panel);
        Destroy(instructionsText);
    }
}
