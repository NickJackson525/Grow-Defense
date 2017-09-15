using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public GameObject water;
    public float speed = 1f;
    public int waterLevel = 100;
    public int money = 150;
    public float startScale;

	// Use this for initialization
	void Start ()
    {
        startScale = water.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -2f);

        water.GetComponent<Image>().fillAmount = (float)waterLevel / 100f;
    }
}
