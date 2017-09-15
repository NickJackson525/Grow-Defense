﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Controller : MonoBehaviour
{
    public Sprite water1;
    public Sprite water2;
    public Sprite water3;
    public Sprite water4;
    public Sprite water5;
    public Sprite water6;
    public Sprite water7;
    public Sprite water8;
    public Sprite water9;
    public Sprite water10;
    public int health = 100;
    bool isSelected = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((isSelected) && (Input.GetMouseButtonUp(0)))
        {
            Game_Manager.Instance.waterLevel += health;

            if (Game_Manager.Instance.waterLevel > 100)
            {
                Game_Manager.Instance.waterLevel = 100;
            }
        }
    }

    public void updateSprite()
    {
        switch (health)
        {
            case 100:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water1;
                break;
            case 90:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water2;
                break;
            case 80:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water3;
                break;
            case 70:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water4;
                break;
            case 60:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water5;
                break;
            case 50:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water6;
                break;
            case 40:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water7;
                break;
            case 30:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water8;
                break;
            case 20:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water9;
                break;
            case 10:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = water10;
                break;
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