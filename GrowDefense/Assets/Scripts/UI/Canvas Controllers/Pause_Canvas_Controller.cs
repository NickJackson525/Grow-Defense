using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Canvas_Controller : MonoBehaviour
{
    #region Variables

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
		
	}

    #endregion

    #region Public Methods

    #region Load Scene

    public void Load_Scene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    #endregion

    #endregion
}
