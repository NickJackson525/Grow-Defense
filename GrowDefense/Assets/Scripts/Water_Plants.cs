using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Plants : MonoBehaviour
{
    public GameObject player;

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
            if ((Input.GetKeyUp(KeyCode.Mouse1)) && (player.GetComponent<Player_Movement>().waterLevel >= 10))
            {
                if (coll.gameObject.GetComponent<Farm_Controller>().waterLevel < 30)
                {
                    coll.gameObject.GetComponent<Farm_Controller>().waterLevel += 10;
                    player.GetComponent<Player_Movement>().waterLevel -= 10;
                }
            }
        }
    }
}
