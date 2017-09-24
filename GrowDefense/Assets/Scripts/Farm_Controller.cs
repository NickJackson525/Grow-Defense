using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Controller : MonoBehaviour
{
    #region Variables

    public GameObject plantLevel1;
    public GameObject fireBullet;
    public GameObject iceBullet;
    public GameObject voidBullet;
    public Sprite unwateredTile;
    public Sprite wateredTile1;
    public Sprite wateredTile2;
    public Sprite wateredTile3;
    public bool isPlanted = false;
    public int waterLevel = 0;
    bool isSelected = false;
    GameObject newPlant;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (waterLevel == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = unwateredTile ;
        }
        else if (waterLevel <= 20)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile1;
        }
        else if (waterLevel <= 40)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile2;
        }
        else if(waterLevel <= 60)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile3;
        }

        if ((isSelected) && (!isPlanted) && (Input.GetMouseButtonUp(0)) && (Game_Manager.Instance.money >= 50) && (!Game_Manager.Instance.gameOver))
        {
            newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            newPlant.GetComponent<Plant_controller>().thisPlant = Game_Manager.Instance.currentPlantSelection;
            newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
            gameObject.GetComponent<Farm_Controller>().isPlanted = true;
            Game_Manager.Instance.money -= 50;

            //switch(newPlant.GetComponent<Plant_controller>().thisPlant)
            //{
            //    case Game_Manager.PlantType.FIRE:
            //        newPlant.GetComponent<Plant_controller>().bullet = fireBullet;
            //        break;
            //    case Game_Manager.PlantType.ICE:
            //        newPlant.GetComponent<Plant_controller>().bullet = iceBullet;
            //        break;
            //    case Game_Manager.PlantType.VOID:
            //        newPlant.GetComponent<Plant_controller>().bullet = voidBullet;
            //        break;
            //    default:
            //        newPlant.GetComponent<Plant_controller>().bullet = fireBullet;
            //        break;
            //}
        }

        if ((isSelected) && (Input.GetMouseButtonUp(1)) && (Game_Manager.Instance.waterLevel >= 10) && (!Game_Manager.Instance.gameOver))
        {
            if (waterLevel <= 50)
            {
                waterLevel += 20;
                Game_Manager.Instance.waterLevel -= 10;
            }
        }
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

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Select")
        {
            isSelected = false;
        }
    }

    #endregion
}
