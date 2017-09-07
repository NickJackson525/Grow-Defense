using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Plants : MonoBehaviour
{
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
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                if (coll.gameObject.GetComponent<Farm_Controller>().waterLevel < 30)
                {
                    coll.gameObject.GetComponent<Farm_Controller>().waterLevel += 10;
                }
            }
        }
    }
}
