using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Controller : MonoBehaviour
{
    #region Variables

    public Audio_Manager audioManager;
    public GameObject plantLevel1;
    public GameObject fireBullet;
    public GameObject iceBullet;
    public GameObject voidBullet;
    public GameObject select;
    public GameObject sprinkler;
    public GameObject fertilizer;
    public Sprite unwateredTile;
    public Sprite wateredTile1;
    public Sprite wateredTile2;
    public Sprite wateredTile3;
    public bool isPlanted = false;
    public float waterLevel = 0;
    public bool isSelected = false;
    public bool hasSprinkler = false;
    public bool hasFertilizer = false;
    GameObject newPlant;
    GameObject createdSelect;
    GameObject createdUpgrade;
    GameObject[] totalMultiSelect;
    public float gridSideLength = .64f;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Game_Manager.Instance.money += 100;
        }

        if(!Game_Manager.Instance.pauseGame)
        {
            #region Update Sprite

            if (waterLevel == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = unwateredTile;
            }
            else if (waterLevel <= 20)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile1;
            }
            else if (waterLevel <= 40)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile2;
            }
            else if (waterLevel <= 60)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile3;
            }

            #endregion

            #region Multi Select

            if ((isSelected) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("LeftTrigger"))) && (!Game_Manager.Instance.gameOver))
            {
                totalMultiSelect = GameObject.FindGameObjectsWithTag("Select");

                if (!createdSelect && (totalMultiSelect.Length <= 3))
                {
                    createdSelect = Instantiate(select, transform.position, transform.rotation);
                }
            }

            if ((!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("LeftTrigger")) && (createdSelect))
            {
                Destroy(createdSelect);
                isSelected = false;
            }

            #endregion
        }

        if (!Game_Manager.Instance.pauseGame && !Game_Manager.Instance.placingUpgrade && !Game_Manager.Instance.wateringCanSelected && !Game_Manager.Instance.SicleSelected)
        {
            #region Create Plant

            if ((isSelected) && (!isPlanted) && (Input.GetMouseButtonUp(0) || Input.GetButtonUp("AButton")) && (Game_Manager.Instance.money >= 25) && (!Game_Manager.Instance.gameOver))
            {
                if ((Game_Manager.Instance.currentShopSelection != Game_Manager.ShopItems.BASIC) && (Game_Manager.Instance.money >= 50))
                {
                    audioManager.PlayPlantingSound();
                    newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                    newPlant.GetComponent<Plant_controller>().thisPlant = Game_Manager.Instance.currentShopSelection;
                    newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
                    gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                    Game_Manager.Instance.money -= 50;

                    if (hasFertilizer)
                    {
                        newPlant.GetComponent<Plant_controller>().isFertilized = true;
                    }
                }
                else
                {
                    audioManager.PlayPlantingSound();
                    newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                    newPlant.GetComponent<Plant_controller>().thisPlant = Game_Manager.Instance.currentShopSelection;
                    newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
                    gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                    Game_Manager.Instance.money -= 25;

                    if (hasFertilizer)
                    {
                        newPlant.GetComponent<Plant_controller>().isFertilized = true;
                    }
                }
            }

            #endregion
        }
        else if (!Game_Manager.Instance.pauseGame && Game_Manager.Instance.placingUpgrade && !Game_Manager.Instance.wateringCanSelected && !Game_Manager.Instance.SicleSelected)
        {
            #region Place Upgrade

            if(Input.GetMouseButtonUp(0) && (isSelected) && (!Game_Manager.Instance.gameOver))
            {
                switch(Game_Manager.Instance.currentShopSelection)
                {
                    case Game_Manager.ShopItems.SPRINKLER:
                        if (!hasSprinkler)
                        {
                            if (Game_Manager.Instance.money >= 25)
                            {
                                Game_Manager.Instance.money -= 25;
                                createdUpgrade = Instantiate(sprinkler, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                                createdUpgrade.GetComponent<Sprinkler>().thisFarmTile = gameObject;
                                hasSprinkler = true;
                            }
                        }
                        break;
                    case Game_Manager.ShopItems.FERTILIZER:
                        if (!hasFertilizer)
                        {
                            if (Game_Manager.Instance.money >= 50)
                            {
                                Game_Manager.Instance.money -= 50;
                                createdUpgrade = Instantiate(fertilizer, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                                hasFertilizer = true;
                            }
                        }
                        break;
                    default:
                        if (!hasSprinkler)
                        {
                            if (Game_Manager.Instance.money >= 25)
                            {
                                Game_Manager.Instance.money -= 25;
                                createdUpgrade = Instantiate(sprinkler, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                                createdUpgrade.GetComponent<Sprinkler>().thisFarmTile = gameObject;
                                hasSprinkler = true;
                            }
                        }
                        break;
                }
            }

            #endregion
        }
        else if (!Game_Manager.Instance.pauseGame && !Game_Manager.Instance.placingUpgrade && Game_Manager.Instance.wateringCanSelected && !Game_Manager.Instance.SicleSelected)
        {
            #region Water Tile

            if ((isSelected) && (Input.GetMouseButtonUp(1) || Input.GetButtonUp("RightTrigger")) && (Game_Manager.Instance.waterLevel >= 10) && (!Game_Manager.Instance.gameOver))
            {
                if (waterLevel <= 50)
                {
                    waterLevel += 20;
                    Game_Manager.Instance.waterLevel -= 10;
                }
            }

            #endregion
        }
        else if (!Game_Manager.Instance.pauseGame && !Game_Manager.Instance.placingUpgrade && !Game_Manager.Instance.wateringCanSelected && Game_Manager.Instance.SicleSelected)
        {
            #region Sicle Plant

            if ((isPlanted) && (isSelected) && (Input.GetMouseButtonUp(1) || Input.GetButtonUp("RightTrigger")) && (!Game_Manager.Instance.gameOver))
            {
                switch(newPlant.GetComponent<Plant_controller>().thisPlant)
                {
                    case Game_Manager.ShopItems.BASIC:
                        Game_Manager.Instance.basicPlantsHarvested++;
                        break;
                    case Game_Manager.ShopItems.FIRE:
                        Game_Manager.Instance.firePlantsHarvested++;
                        break;
                    case Game_Manager.ShopItems.ICE:
                        Game_Manager.Instance.icePlantsHarvested++;
                        break;
                    case Game_Manager.ShopItems.VOID:
                        Game_Manager.Instance.voidPlantsHarvested++;
                        break;
                }

                isPlanted = false;
                Destroy(newPlant);
                newPlant = null;
            }

            #endregion
        }
    }

    #endregion

    #region Public Methods

    public Vector3 GetSnappedPosition(Vector3 position)
    {

        // not fatal in the Editor, but just better not to divide by 0 if we can avoid it
        if (gridSideLength == 0) { return position; }

        Vector3 gridPosition = new Vector3(
            gridSideLength * Mathf.Round(position.x / gridSideLength),
            gridSideLength * Mathf.Round(position.y / gridSideLength),
            -3//gridSideLength * Mathf.Round(position.z / gridSideLength)
        );
        return gridPosition;
    }

    #endregion

    #region Collision Methods

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Select")
        {
            isSelected = true;
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Select")
        {
            isSelected = true;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Select") && (!createdSelect))
        {
            isSelected = false;
        }
    }

    #endregion
}
