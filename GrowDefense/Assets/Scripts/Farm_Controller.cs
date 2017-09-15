using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Controller : MonoBehaviour
{
    public GameObject plantLevel1;
    public Sprite unwateredTile;
    public Sprite wateredTile1;
    public Sprite wateredTile2;
    public Sprite wateredTile3;
    public bool isPlanted = false;
    public int waterLevel = 0;
    bool isSelected = false;
    GameObject newPlant;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (waterLevel == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = unwateredTile ;
        }
        else if (waterLevel <= 10)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile1;
        }
        else if (waterLevel <= 20)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile2;
        }
        else if(waterLevel <= 30)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile3;
        }

        if ((isSelected) && (!isPlanted) && (Input.GetMouseButtonUp(0)) && (Game_Manager.Instance.money >= 50))
        {
            newPlant = Instantiate(plantLevel1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            newPlant.GetComponent<Plant_controller>().thisPlant = Plant_controller.PlantType.FIRE;
            newPlant.GetComponent<Plant_controller>().thisTile = gameObject;
            gameObject.GetComponent<Farm_Controller>().isPlanted = true;
            Game_Manager.Instance.money -= 50;
        }

        if ((isSelected) && (Input.GetMouseButtonUp(1)) && (Game_Manager.Instance.waterLevel >= 10))
        {
            if (waterLevel <= 20)
            {
                waterLevel += 10;
                Game_Manager.Instance.waterLevel -= 10;
            }
        }
    }

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
}
