using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuestCompleted : MonoBehaviour
{
    #region Update

    void Update ()
    {
        if (GameManager.Instance.gameStarted)
        {
            GetComponent<Text>().text = GameManager.Instance.questsCompleted + " / " + GameManager.Instance.questsRequired;
        }
        else
        {
            GetComponent<Text>().text = "";
        }
	}

    #endregion
}
