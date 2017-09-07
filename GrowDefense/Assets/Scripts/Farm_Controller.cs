using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm_Controller : MonoBehaviour
{
    public Sprite unwateredTile;
    public Sprite wateredTile1;
    public Sprite wateredTile2;
    public Sprite wateredTile3;
    public bool isPlanted = false;
    public int waterLevel = 0;

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
	}
}
