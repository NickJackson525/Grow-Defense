using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Item_Select : MonoBehaviour
{
    #region Variables

    public GameManager.ShopItems thisItem;
    public GameObject buildSelect;
    public GameObject fireSelect;
    public GameObject iceSelect;
    public GameObject voidSelect;
    public GameObject fertilizerSelect;
    public GameObject sprinklerSelect;
    public GameObject waterSelect;
    public GameObject sicleSelect;
    bool mouseHover = false;

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		if((gameObject.name != "Build_Select") && Input.GetMouseButtonUp(0) && mouseHover)
        {

            buildSelect.transform.position = transform.position;
            GameManager.Instance.currentShopSelection = thisItem;

            #region Placing Upgrade

            if((thisItem == GameManager.ShopItems.FERTILIZER) || (thisItem == GameManager.ShopItems.SPRINKLER))
            {
                GameManager.Instance.placingUpgrade = true;
                GameManager.Instance.wateringCanSelected = false;
                GameManager.Instance.SicleSelected = false;
            }
            else
            {
                GameManager.Instance.placingUpgrade = false;
            }

            #endregion

            #region Water

            if(thisItem == GameManager.ShopItems.WATER)
            {
                GameManager.Instance.wateringCanSelected = true;
                GameManager.Instance.placingUpgrade = false;
                GameManager.Instance.SicleSelected = false;
            }
            else
            {
                GameManager.Instance.wateringCanSelected = false;
            }

            #endregion

            #region Sicle

            if (thisItem == GameManager.ShopItems.SICLE)
            {
                GameManager.Instance.SicleSelected = true;
                GameManager.Instance.wateringCanSelected = false;
                GameManager.Instance.placingUpgrade = false;
            }
            else
            {
                GameManager.Instance.SicleSelected = false;
            }

            #endregion
        }

        #region 1 Through 4 Hotkeys

        if((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Alpha1))
        {
            buildSelect.transform.position = waterSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.WATER;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = true;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Alpha2))
        {
            buildSelect.transform.position = sicleSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.SICLE;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = true;
            GameManager.Instance.wateringCanSelected = false;
        }

        #endregion
    }

    #endregion

    #region Change Select

    public void ChangeSelect()
    {
        if (buildSelect.transform.position == fireSelect.transform.position)
        {
            buildSelect.transform.position = iceSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.ICE;
            GameManager.Instance.placingUpgrade = false;
        }
        else if (buildSelect.transform.position == iceSelect.transform.position)
        {
            buildSelect.transform.position = voidSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.VOID;
            GameManager.Instance.placingUpgrade = false;
        }
        else if (buildSelect.transform.position == voidSelect.transform.position)
        {
            buildSelect.transform.position = waterSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.WATER;
            GameManager.Instance.placingUpgrade = false;
        }
        else if(buildSelect.transform.position == waterSelect.transform.position)
        {
            buildSelect.transform.position = fertilizerSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.FERTILIZER;
            GameManager.Instance.placingUpgrade = true;
        }
        else if (buildSelect.transform.position == fertilizerSelect.transform.position)
        {
            buildSelect.transform.position = sprinklerSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.SPRINKLER;
            GameManager.Instance.placingUpgrade = true;
        }
        else
        {
            buildSelect.transform.position = fireSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.FIRE;
            GameManager.Instance.placingUpgrade = false;
        }
    }

    #endregion

    #region Mouse Enter and Exit

    private void OnMouseEnter()
    {
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }

    #endregion
}
