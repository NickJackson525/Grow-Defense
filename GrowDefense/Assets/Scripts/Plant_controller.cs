using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_controller : MonoBehaviour
{
    public enum PlantType { FIRE, ICE }

    public Sprite levelOnePlant;
    public Sprite levelTwoPlant;
    public Sprite firePlant;
    public Sprite icePlant;
    public PlantType thisPlant;
    public GameObject ammo;
    public GameObject currentTarget;
    GameObject createdBullet;
    GameObject testEnemyExist;
    public GameObject thisTile;
    int shootTimer = 0;
    bool canShoot = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTarget = FindClosestEnemy();
        testEnemyExist = GameObject.FindGameObjectWithTag("Enemy");
        shootTimer--;

        if(shootTimer == 0)
        {
            canShoot = true;
        }

        if (canShoot && testEnemyExist != null)
        {
            if (thisTile.GetComponent<Farm_Controller>().waterLevel > 0)
            {
                createdBullet = Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                createdBullet.GetComponent<Bullet>().move = true;
                createdBullet.GetComponent<Bullet>().target = currentTarget;
                canShoot = false;
                shootTimer = 60;
                thisTile.GetComponent<Farm_Controller>().waterLevel -= 1;
            }
        }
	}

    public GameObject FindClosestEnemy()
    {
        GameObject[] allEnemies;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in allEnemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

    }
}
