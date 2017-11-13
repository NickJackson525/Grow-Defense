﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    public GameObject thisFarmTile;
    public bool playAnimation;
    public Sprite startFrame;
    public Sprite endFrame;
    public int timer = 300;
    public Animator thisAnimation;

	// Use this for initialization
	void Start ()
    {
        thisAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer--;
        }

        if((GetComponent<SpriteRenderer>().sprite.name == endFrame.name) && playAnimation)
        {
            playAnimation = false;
            thisFarmTile.GetComponent<Farm_Controller>().waterLevel += 20;
        }

        if((timer == 0) && (thisFarmTile.GetComponent<Farm_Controller>().waterLevel <= 50))
        {
            playAnimation = true;
            timer = 300;
        }

        if(playAnimation)
        {
            thisAnimation.speed = 2;
        }
        else
        {
            thisAnimation.speed = 0;
        }
	}
}
