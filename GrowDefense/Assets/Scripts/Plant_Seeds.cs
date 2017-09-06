using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Seeds : MonoBehaviour
{
    public GameObject plantLevel1;

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
                    Instantiate(plantLevel1, new Vector3(coll.transform.position.x, coll.transform.position.y, -1), coll.transform.rotation);
                    coll.gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                }
            }
        }
    }
}
