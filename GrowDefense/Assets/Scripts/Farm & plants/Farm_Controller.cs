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
            GameManager.Instance.money += 100;
        }

        if(!isSelected)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        if(!GameManager.Instance.pauseGame)
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

            if ((isSelected) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("LeftTrigger"))) && (!GameManager.Instance.gameOver))
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

        if (!GameManager.Instance.pauseGame && !GameManager.Instance.placingUpgrade && !GameManager.Instance.wateringCanSelected && !GameManager.Instance.SicleSelected)
        {
            #region Create Plant

            if ((isSelected) && (!isPlanted) && (Input.GetMouseButtonUp(0) || Input.GetButtonUp("AButton")) && (GameManager.Instance.money >= 25) && (!GameManager.Instance.gameOver))
            {
                if ((GameManager.Instance.currentShopSelection != GameManager.ShopItems.BASIC) && (GameManager.Instance.money >= 50))
                {
                    audioManager.PlayPlantingSound();
                    newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                    newPlant.GetComponent<Plant_controller>().thisPlant = GameManager.Instance.currentShopSelection;
                    newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
                    gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                    GameManager.Instance.money -= 50;

                    if (hasFertilizer)
                    {
                        newPlant.GetComponent<Plant_controller>().isFertilized = true;
                    }
                }
                else
                {
                    audioManager.PlayPlantingSound();
                    newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                    newPlant.GetComponent<Plant_controller>().thisPlant = GameManager.Instance.currentShopSelection;
                    newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
                    gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                    GameManager.Instance.money -= 25;

                    if (hasFertilizer)
                    {
                        newPlant.GetComponent<Plant_controller>().isFertilized = true;
                    }
                }
            }

            #endregion
        }
        else if (!GameManager.Instance.pauseGame && GameManager.Instance.placingUpgrade && !GameManager.Instance.wateringCanSelected && !GameManager.Instance.SicleSelected)
        {
            #region Place Upgrade

            if(Input.GetMouseButtonUp(0) && (isSelected) && (!GameManager.Instance.gameOver))
            {
                switch(GameManager.Instance.currentShopSelection)
                {
                    case GameManager.ShopItems.SPRINKLER:
                        if (!hasSprinkler)
                        {
                            if (GameManager.Instance.money >= 25)
                            {
                                GameManager.Instance.money -= 25;
                                createdUpgrade = Instantiate(sprinkler, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                                createdUpgrade.GetComponent<Sprinkler>().thisFarmTile = gameObject;
                                hasSprinkler = true;
                            }
                        }
                        break;
                    case GameManager.ShopItems.FERTILIZER:
                        if (!hasFertilizer)
                        {
                            if (GameManager.Instance.money >= 50)
                            {
                                GameManager.Instance.money -= 50;
                                createdUpgrade = Instantiate(fertilizer, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                                hasFertilizer = true;
                            }
                        }
                        break;
                    default:
                        if (!hasSprinkler)
                        {
                            if (GameManager.Instance.money >= 25)
                            {
                                GameManager.Instance.money -= 25;
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
        else if (!GameManager.Instance.pauseGame && !GameManager.Instance.placingUpgrade && GameManager.Instance.wateringCanSelected && !GameManager.Instance.SicleSelected)
        {
            #region Water Tile

            if ((isSelected) && (Input.GetMouseButtonUp(1) || Input.GetButtonUp("RightTrigger")) && (GameManager.Instance.waterLevel >= 10) && (!GameManager.Instance.gameOver))
            {
                if (waterLevel <= 50)
                {
                    waterLevel += 20;
                    GameManager.Instance.waterLevel -= 10;
                }
            }

            #endregion
        }
        else if (!GameManager.Instance.pauseGame && !GameManager.Instance.placingUpgrade && !GameManager.Instance.wateringCanSelected && GameManager.Instance.SicleSelected)
        {
            #region Sicle Plant

            if ((isPlanted) && (isSelected) && (Input.GetMouseButtonUp(1) || Input.GetButtonUp("RightTrigger")) && (!GameManager.Instance.gameOver))
            {
                switch(newPlant.GetComponent<Plant_controller>().thisPlant)
                {
                    case GameManager.ShopItems.BASIC:
                        GameManager.Instance.basicPlantsHarvested++;
                        break;
                    case GameManager.ShopItems.FIRE:
                        GameManager.Instance.firePlantsHarvested++;
                        break;
                    case GameManager.ShopItems.ICE:
                        GameManager.Instance.icePlantsHarvested++;
                        break;
                    case GameManager.ShopItems.VOID:
                        GameManager.Instance.voidPlantsHarvested++;
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

            switch(GameManager.Instance.currentShopSelection)
            {
                case GameManager.ShopItems.FERTILIZER:
                    if(!hasFertilizer && (GameManager.Instance.money < 50))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if(!hasFertilizer && (GameManager.Instance.money >= 50))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    break;
                case GameManager.ShopItems.SPRINKLER:
                    if (!hasSprinkler && (GameManager.Instance.money < 25))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if (!hasSprinkler && (GameManager.Instance.money >= 25))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    break;
                case GameManager.ShopItems.SICLE:
                    if (!isPlanted || (isPlanted && (newPlant.GetComponent<Plant_controller>().currentLevel < 3)))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if ((isPlanted && (newPlant.GetComponent<Plant_controller>().currentLevel == 3)))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    break;
                case GameManager.ShopItems.WATER:
                    if (GameManager.Instance.waterLevel <= 0)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    break;
                default:
                    if (!isPlanted && (((GameManager.Instance.currentShopSelection == GameManager.ShopItems.BASIC) && (GameManager.Instance.money >= 25)) || ((GameManager.Instance.currentShopSelection != GameManager.ShopItems.BASIC) && (GameManager.Instance.money >= 50))))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else if (!isPlanted && (((GameManager.Instance.currentShopSelection == GameManager.ShopItems.BASIC) && (GameManager.Instance.money < 25)) || ((GameManager.Instance.currentShopSelection != GameManager.ShopItems.BASIC) && (GameManager.Instance.money < 50))))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if (isPlanted)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    break;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Select")
        {
            isSelected = true;

            switch (GameManager.Instance.currentShopSelection)
            {
                case GameManager.ShopItems.FERTILIZER:
                    if (!hasFertilizer && (GameManager.Instance.money < 50))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if (!hasFertilizer && (GameManager.Instance.money >= 50))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    break;
                case GameManager.ShopItems.SPRINKLER:
                    if (!hasSprinkler && (GameManager.Instance.money < 25))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if (!hasSprinkler && (GameManager.Instance.money >= 25))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    break;
                case GameManager.ShopItems.SICLE:
                    if (!isPlanted || (isPlanted && (newPlant.GetComponent<Plant_controller>().currentLevel < 3)))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if ((isPlanted && (newPlant.GetComponent<Plant_controller>().currentLevel == 3)))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    break;
                case GameManager.ShopItems.WATER:
                    if (GameManager.Instance.waterLevel <= 0)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    break;
                default:
                    if(!isPlanted && (((GameManager.Instance.currentShopSelection == GameManager.ShopItems.BASIC) && (GameManager.Instance.money >= 25)) || ((GameManager.Instance.currentShopSelection != GameManager.ShopItems.BASIC) && (GameManager.Instance.money >= 50))))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                    }
                    else if(!isPlanted && (((GameManager.Instance.currentShopSelection == GameManager.ShopItems.BASIC) && (GameManager.Instance.money < 25)) || ((GameManager.Instance.currentShopSelection != GameManager.ShopItems.BASIC) && (GameManager.Instance.money < 50))))
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else if (isPlanted)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, .447f, .447f, 1);
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Select") && (!createdSelect))
        {
            isSelected = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    #endregion
}
