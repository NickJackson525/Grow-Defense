using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Item_Select : MonoBehaviour
{
    #region Variables

    public GameManager.ShopItems thisItem;
    public GameObject cursor;
    public GameObject buildSelect;
    public GameObject basicSelect;
    public GameObject fireSelect;
    public GameObject iceSelect;
    public GameObject voidSelect;
    public GameObject fertilizerSelect;
    public GameObject sprinklerSelect;
    public GameObject waterSelect;
    public GameObject sicleSelect;
    public GameObject sellSelect;
    bool mouseHover = false;

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		if(!GameManager.Instance.pauseGame && (gameObject.name != "Build_Select") && Input.GetMouseButtonUp(0) && mouseHover)
        {

            buildSelect.transform.position = transform.position;
            GameManager.Instance.currentShopSelection = thisItem;

            #region Placing Upgrade

            if((thisItem == GameManager.ShopItems.FERTILIZER) || (thisItem == GameManager.ShopItems.SPRINKLER))
            {
                GameManager.Instance.placingUpgrade = true;
                GameManager.Instance.wateringCanSelected = false;
                GameManager.Instance.SicleSelected = false;
                GameManager.Instance.sellingItem = false;
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
                GameManager.Instance.sellingItem = false;
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
                GameManager.Instance.sellingItem = false;
            }
            else
            {
                GameManager.Instance.SicleSelected = false;
            }

            #endregion

            #region Sell

            if (thisItem == GameManager.ShopItems.SELL)
            {
                GameManager.Instance.SicleSelected = false;
                GameManager.Instance.wateringCanSelected = false;
                GameManager.Instance.placingUpgrade = false;
                GameManager.Instance.sellingItem = true;
            }
            else
            {
                GameManager.Instance.sellingItem = false;
            }

            #endregion
        }

        #region Hotkeys

        if((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Alpha1))
        {
            buildSelect.transform.position = waterSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.WATER;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = true;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().wateringCanCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Alpha2))
        {
            buildSelect.transform.position = sicleSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.SICLE;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = true;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().sicleCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Alpha3))
        {
            buildSelect.transform.position = sellSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.SELL;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = true;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().sellCursor;
        }
        else if((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Q))
        {
            buildSelect.transform.position = basicSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.BASIC;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().basicSeedPacketCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.W))
        {
            buildSelect.transform.position = iceSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.ICE;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().iceSeedPacketCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.E))
        {
            buildSelect.transform.position = fireSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.FIRE;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().fireSeedPacketCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.R))
        {
            buildSelect.transform.position = voidSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.VOID;
            GameManager.Instance.placingUpgrade = false;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().voidSeedPacketCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.T))
        {
            buildSelect.transform.position = fertilizerSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.FERTILIZER;
            GameManager.Instance.placingUpgrade = true;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().defaultCursor;
        }
        else if ((gameObject.name == "Build_Select") && Input.GetKeyUp(KeyCode.Y))
        {
            buildSelect.transform.position = sprinklerSelect.transform.position;
            GameManager.Instance.currentShopSelection = GameManager.ShopItems.SPRINKLER;
            GameManager.Instance.placingUpgrade = true;
            GameManager.Instance.SicleSelected = false;
            GameManager.Instance.wateringCanSelected = false;
            GameManager.Instance.sellingItem = false;
            cursor.GetComponent<SpriteRenderer>().sprite = cursor.GetComponent<Cursor_Image>().defaultCursor;
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
