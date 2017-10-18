using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public GameObject water;
    public float speed = 1.5f;
    public float startScale;

	// Use this for initialization
	void Start ()
    {
        startScale = water.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Game_Manager.Instance.gameOver)
        {
            if (Input.GetKey(Game_Manager.Instance.Controls[Game_Manager.Instance.currentControls][Game_Manager.Direction.UP]))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }

            if (Input.GetKey(Game_Manager.Instance.Controls[Game_Manager.Instance.currentControls][Game_Manager.Direction.LEFT]))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (Input.GetKey(Game_Manager.Instance.Controls[Game_Manager.Instance.currentControls][Game_Manager.Direction.DOWN]))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }

            if (Input.GetKey(Game_Manager.Instance.Controls[Game_Manager.Instance.currentControls][Game_Manager.Direction.RIGHT]))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -2f);

            water.GetComponent<Image>().fillAmount = Game_Manager.Instance.waterLevel / 100f;
        }
    }
}
