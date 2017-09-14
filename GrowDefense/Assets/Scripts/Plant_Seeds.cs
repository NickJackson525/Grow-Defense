using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Seeds : MonoBehaviour
{
    public GameObject plantLevel1;
    public GameObject player;
    GameObject newPlant;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "FarmTile")
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if ((!coll.gameObject.GetComponent<Farm_Controller>().isPlanted) && (player.GetComponent<Player_Movement>().money >= 50))
                {
                    newPlant = Instantiate(plantLevel1, new Vector3(coll.transform.position.x, coll.transform.position.y, 0), coll.transform.rotation);
                    newPlant.GetComponent<Plant_controller>().thisPlant = Plant_controller.PlantType.FIRE;
                    newPlant.GetComponent<Plant_controller>().thisTile = coll.gameObject;
                    coll.gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                    player.GetComponent<Player_Movement>().money -= 50;
                }
            }
        }
    }
}
