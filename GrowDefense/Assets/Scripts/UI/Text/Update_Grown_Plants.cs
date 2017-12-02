using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Grown_Plants : MonoBehaviour
{
    #region Variables

    public GameManager.ShopItems type;

    #endregion

    #region Update

    // Update is called once per frame
    void Update()
    {
        switch(type)
        {
            case GameManager.ShopItems.FIRE:
                GetComponent<Text>().text = GameManager.Instance.firePlantsGrown + " / " + GameManager.Instance.firePlantsRequired;
                break;
            case GameManager.ShopItems.ICE:
                GetComponent<Text>().text = GameManager.Instance.icePlantsGrown + " / " + GameManager.Instance.icePlantsRequired;
                break;
            case GameManager.ShopItems.VOID:
                GetComponent<Text>().text = GameManager.Instance.voidPlantsGrown + " / " + GameManager.Instance.voidPlantsRequired;
                break;
            default:
                GetComponent<Text>().text = GameManager.Instance.firePlantsGrown + " / " + GameManager.Instance.firePlantsRequired;
                break;
        }
    }

    #endregion
}
