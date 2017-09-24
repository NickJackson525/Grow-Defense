using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Type_Select : MonoBehaviour
{
    public Game_Manager.PlantType thisPlant;
    public GameObject buildSelect;
    bool mouseHover = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonUp(0) && mouseHover)
        {
            buildSelect.transform.position = transform.position;
            Game_Manager.Instance.currentPlantSelection = thisPlant;
        }
	}

    private void OnMouseEnter()
    {
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }
}
