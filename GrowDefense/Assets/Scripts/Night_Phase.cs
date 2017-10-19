using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Night_Phase : MonoBehaviour
{
    Color Night = new Color(0, 0, 0, .49f);
    Color Day = new Color(0, 0, 0, 0);

    // Update is called once per frame
    void Update ()
    {
		if(Game_Manager.Instance.currentPhase == Game_Manager.Phase.NIGHT)
        {
            GetComponent<Image>().color = Night;
        }
        else
        {
            GetComponent<Image>().color = Day;
        }
	}
}
