using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Seeds : MonoBehaviour
{
    public GameObject plantLevel1;
    GameObject newPlant;

	// Use this for initialization
	void Start ()
    {
		
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
                if (!coll.gameObject.GetComponent<Farm_Controller>().isPlanted)
                {
                    newPlant = Instantiate(plantLevel1, new Vector3(coll.transform.position.x, coll.transform.position.y, 0), coll.transform.rotation);
                    newPlant.GetComponent<Plant_controller>().thisPlant = Plant_controller.PlantType.FIRE;
                    newPlant.GetComponent<Plant_controller>().thisTile = coll.gameObject;
                    coll.gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                }
            }
        }
    }
}
