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
    public GameObject select;
    public Sprite unwateredTile;
    public Sprite wateredTile1;
    public Sprite wateredTile2;
    public Sprite wateredTile3;
    public bool isPlanted = false;
    public int waterLevel = 0;
    public bool isSelected = false;
    GameObject newPlant;
    GameObject createdSelect;
    GameObject[] totalMultiSelect;
    public float gridSideLength = .64f;

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
        if (!Game_Manager.Instance.pauseGame)
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

            #region Create Plant

            if ((isSelected) && (!isPlanted) && (Input.GetMouseButtonUp(0) || Input.GetButtonUp("AButton")) && (Game_Manager.Instance.money >= 50) && (!Game_Manager.Instance.gameOver))
            {
                newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                newPlant.GetComponent<Plant_controller>().thisPlant = Game_Manager.Instance.currentPlantSelection;
                newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
                gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                Game_Manager.Instance.money -= 50;
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
