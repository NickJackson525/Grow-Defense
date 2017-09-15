using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Controller : MonoBehaviour
{
    public GameObject player;
    public Sprite unwateredTile;
    public Sprite wateredTile1;
    public Sprite wateredTile2;
    public Sprite wateredTile3;
    public bool isPlanted = false;
    public int waterLevel = 0;
    bool isSelected = false;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (waterLevel == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = unwateredTile ;
        }
        else if (waterLevel == 10)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile1;
        }
        else if (waterLevel == 20)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile2;
        }
        else if(waterLevel == 30)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wateredTile3;
        }

        if ((isSelected) && (Input.GetMouseButtonUp(0)) && (player.GetComponent<Player_Movement>().waterLevel >= 10))
        {
            if (waterLevel < 30)
            {
                waterLevel += 10;
                player.GetComponent<Player_Movement>().waterLevel -= 10;
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
