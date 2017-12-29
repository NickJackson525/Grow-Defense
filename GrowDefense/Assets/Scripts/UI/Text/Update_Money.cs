using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Money : MonoBehaviour
{
    #region Variables

    public GameObject updatedText;
    GameObject createdText;
    int prevMoney = 200;

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (prevMoney != GameManager.Instance.money)
        {
            createdText = Instantiate(updatedText, transform.position, transform.rotation, GameObject.Find("Bottom UI").transform);

            if(GameManager.Instance.money > prevMoney)
            {
                createdText.GetComponent<Text>().text = "+$ " + (GameManager.Instance.money - prevMoney);
                createdText.GetComponent<Text>().color = Color.green;
            }
            else
            {
                createdText.GetComponent<Text>().text = "-$ " + (prevMoney - GameManager.Instance.money);
                createdText.GetComponent<Text>().color = Color.red;
            }

            GetComponent<Text>().text = "$ " + GameManager.Instance.money;
        }
        else
        {
            GetComponent<Text>().text = "$ " + GameManager.Instance.money;
        }

        prevMoney = GameManager.Instance.money;
	}

    #endregion
}
