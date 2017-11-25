using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Grown_Plants : MonoBehaviour
{
    #region Variables

    public Game_Manager.ShopItems type;

    #endregion

    #region Update

    // Update is called once per frame
    void Update()
    {
        switch(type)
        {
            case Game_Manager.ShopItems.FIRE:
                GetComponent<Text>().text = Game_Manager.Instance.firePlantsGrown + " / " + Game_Manager.Instance.firePlantsRequired;
                break;
            case Game_Manager.ShopItems.ICE:
                GetComponent<Text>().text = Game_Manager.Instance.icePlantsGrown + " / " + Game_Manager.Instance.icePlantsRequired;
                break;
            case Game_Manager.ShopItems.VOID:
                GetComponent<Text>().text = Game_Manager.Instance.voidPlantsGrown + " / " + Game_Manager.Instance.voidPlantsRequired;
                break;
            default:
                GetComponent<Text>().text = Game_Manager.Instance.firePlantsGrown + " / " + Game_Manager.Instance.firePlantsRequired;
                break;
        }
    }

    #endregion
}
