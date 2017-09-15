using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bug1;
    public int cooldown = 180;
    public int cooldownConst = 180;
    public int spawnCount = 0;
    int spawnReset = 10;
    int initialSpawnCountDown = 240;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cooldown--;

        if (initialSpawnCountDown > 0)
        {
            initialSpawnCountDown--;
        }

        if(cooldown <= 0 && initialSpawnCountDown == 0)
        {
            Instantiate(bug1, transform.position, transform.rotation);
            cooldown = cooldownConst;
            spawnCount++;
        }

        if((spawnCount == spawnReset) && (cooldownConst > 50))
        {
            cooldownConst -= 50;
            spawnCount = 0;
        }
	}
}
