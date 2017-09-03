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
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    Instantiate(plantLevel1, this.transform.position, this.transform.rotation);
        //}
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Select")
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (!this.gameObject.GetComponent<Farm_Controller>().isPlanted)
                {
                    Instantiate(plantLevel1, coll.transform.position, coll.transform.rotation);
                    this.gameObject.GetComponent<Farm_Controller>().isPlanted = true;
                }
            }
        }
    }
}
