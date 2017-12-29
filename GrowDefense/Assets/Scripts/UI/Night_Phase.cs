using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Night_Phase : MonoBehaviour
{
    #region Variables

    public GameObject dayNightWheel;
    Color Night = new Color(0, 0, 0, .49f);
    Color Day = new Color(0, 0, 0, 0);
    float temp = 0;

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            if (GameManager.Instance.currentPhase == GameManager.Phase.NIGHT)
            {
                GetComponent<Image>().color = Night;
                temp = ((((float)GameManager.Instance.nightTimerConstant * GameManager.Instance.waveNumber) - GameManager.Instance.nightTimer) / ((float)GameManager.Instance.nightTimerConstant * GameManager.Instance.waveNumber));
                dayNightWheel.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 117 + (temp * 270f));
            }
            else
            {
                GetComponent<Image>().color = Day;
                dayNightWheel.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 27 + (((GameManager.Instance.dayTimerConstant - GameManager.Instance.dayTimer) / (float)GameManager.Instance.dayTimerConstant) * 90f));
            }
        }
        else
        {
            if (GameManager.Instance.currentPhase == GameManager.Phase.NIGHT)
            {
                GetComponent<Image>().color = Night;
            }
            else
            {
                GetComponent<Image>().color = Day;
            }
        }
    }

    #endregion
}
