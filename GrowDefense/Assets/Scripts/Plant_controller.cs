using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_controller : MonoBehaviour
{
    #region Variables

    public Sprite levelOnePlant;
    public Sprite levelTwoPlant;
    public Sprite firePlant;
    public Sprite icePlant;
    public Sprite voidPlant;
    public Game_Manager.PlantType thisPlant;
    public GameObject plantAmmoType;
    public GameObject currentTarget;
    GameObject createdBullet;
    GameObject testEnemyExist;
    public GameObject thisTile;
    int shootTimer = 0;
    int growthTimer = 1800;
    int currentLevel = 1;
    bool canShoot = true;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
		
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        currentTarget = FindClosestEnemy();
        testEnemyExist = GameObject.FindGameObjectWithTag("Enemy");
        shootTimer--;

        if((currentLevel < Game_Manager.maxPlantLevel) && (thisTile.GetComponent<Farm_Controller>().waterLevel > 0))
        {
            growthTimer--;
        }

        if(growthTimer <= 0)
        {
            if(currentLevel == 1)
            {
                currentLevel++;
                GetComponent<SpriteRenderer>().sprite = levelTwoPlant;
                growthTimer = 2700;
            }
            else
            {
                currentLevel++;
                
                switch(thisPlant)
                {
                    case Game_Manager.PlantType.FIRE:
                        GetComponent<SpriteRenderer>().sprite = firePlant;
                        break;
                    case Game_Manager.PlantType.ICE:
                        GetComponent<SpriteRenderer>().sprite = icePlant;
                        break;
                    case Game_Manager.PlantType.VOID:
                        GetComponent<SpriteRenderer>().sprite = voidPlant;
                        break;
                    default:
                        GetComponent<SpriteRenderer>().sprite = firePlant;
                        break;
                }
            }
        }

        if(shootTimer == 0)
        {
            canShoot = true;
        }

        if (canShoot && testEnemyExist != null)
        {
            if (thisTile.GetComponent<Farm_Controller>().waterLevel > 0)
            {
                createdBullet = Instantiate(plantAmmoType, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                createdBullet.GetComponent<Bullet>().move = true;
                createdBullet.GetComponent<Bullet>().target = currentTarget;
                createdBullet.GetComponent<Bullet>().damage = createdBullet.GetComponent<Bullet>().damage * currentLevel;
                canShoot = false;
                shootTimer = 60;
                thisTile.GetComponent<Farm_Controller>().waterLevel -= 1;
            }
        }
	}

    #endregion

    #region Custom Methods

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

    #endregion

    #region Collision Methods

    private void OnCollisionEnter2D(Collision2D coll)
    {

    }

    #endregion
}
