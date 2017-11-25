using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Item_Select : MonoBehaviour
{
    public Game_Manager.ShopItems thisItem;
    public GameObject buildSelect;
    public GameObject fireSelect;
    public GameObject iceSelect;
    public GameObject voidSelect;
    public GameObject fertilizerSelect;
    public GameObject sprinklerSelect;
    public GameObject waterSelect;
    bool mouseHover = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if((gameObject.name != "Build_Select") && Input.GetMouseButtonUp(0) && mouseHover)
        {
            buildSelect.transform.position = transform.position;
            Game_Manager.Instance.currentShopSelection = thisItem;

            if((thisItem == Game_Manager.ShopItems.FERTILIZER) || (thisItem == Game_Manager.ShopItems.SPRINKLER))
            {
                Game_Manager.Instance.placingUpgrade = true;
            }
            else
            {
                Game_Manager.Instance.placingUpgrade = false;
            }

            if(thisItem == Game_Manager.ShopItems.WATER)
            {
                Game_Manager.Instance.wateringCanSelected = true;
            }
            else
            {
                Game_Manager.Instance.wateringCanSelected = false;
            }
        }

        if((gameObject.name == "Build_Select") && Input.GetButtonUp("XButton"))
        {
            ChangeSelect();
        }
	}

    public void ChangeSelect()
    {
        if (buildSelect.transform.position == fireSelect.transform.position)
        {
            buildSelect.transform.position = iceSelect.transform.position;
            Game_Manager.Instance.currentShopSelection = Game_Manager.ShopItems.ICE;
            Game_Manager.Instance.placingUpgrade = false;
        }
        else if (buildSelect.transform.position == iceSelect.transform.position)
        {
            buildSelect.transform.position = voidSelect.transform.position;
            Game_Manager.Instance.currentShopSelection = Game_Manager.ShopItems.VOID;
            Game_Manager.Instance.placingUpgrade = false;
        }
        else if (buildSelect.transform.position == voidSelect.transform.position)
        {
            buildSelect.transform.position = waterSelect.transform.position;
            Game_Manager.Instance.currentShopSelection = Game_Manager.ShopItems.WATER;
            Game_Manager.Instance.placingUpgrade = false;
        }
        else if(buildSelect.transform.position == waterSelect.transform.position)
        {
            buildSelect.transform.position = fertilizerSelect.transform.position;
            Game_Manager.Instance.currentShopSelection = Game_Manager.ShopItems.FERTILIZER;
            Game_Manager.Instance.placingUpgrade = true;
        }
        else if (buildSelect.transform.position == fertilizerSelect.transform.position)
        {
            buildSelect.transform.position = sprinklerSelect.transform.position;
            Game_Manager.Instance.currentShopSelection = Game_Manager.ShopItems.SPRINKLER;
            Game_Manager.Instance.placingUpgrade = true;
        }
        else
        {
            buildSelect.transform.position = fireSelect.transform.position;
            Game_Manager.Instance.currentShopSelection = Game_Manager.ShopItems.FIRE;
            Game_Manager.Instance.placingUpgrade = false;
        }
    }

    private void OnMouseEnter()
    {
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }
}
