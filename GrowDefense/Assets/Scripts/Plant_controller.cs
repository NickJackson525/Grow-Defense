using System;
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
    public Sprite fireBullet;
    public Sprite iceBullet;
    public Sprite voidBullet;
    public Game_Manager.PlantType thisPlant;
    public GameObject bullet;
    public GameObject currentTarget;
    GameObject createdBullet;
    GameObject testEnemyExist;
    public GameObject thisTile;
    int shootTimer = 0;
    int growthTimer = 1800;
    int currentLevel = 1;
    bool canShoot = true;
    public float range = 1f;

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

        if((currentLevel < Game_Manager.maxPlantLevel) && (thisTile.GetComponent<Farm_Controller>().waterLevel > 0) && (Game_Manager.Instance.currentPhase == Game_Manager.Phase.DAY))
        {
            growthTimer--;
        }

        if(growthTimer <= 0)
        {
            if(currentLevel == 1)
            {
                currentLevel++;
                range++;
                GetComponent<SpriteRenderer>().sprite = levelTwoPlant;
                growthTimer = 2700;
            }
            else
            {
                currentLevel++;
                range++;
                growthTimer = 100;

                switch(thisPlant)
                {
                    case Game_Manager.PlantType.FIRE:
                        GetComponent<SpriteRenderer>().sprite = firePlant;
                        Game_Manager.Instance.firePlantsGrown++;
                        break;
                    case Game_Manager.PlantType.ICE:
                        GetComponent<SpriteRenderer>().sprite = icePlant;
                        Game_Manager.Instance.icePlantsGrown++;
                        break;
                    case Game_Manager.PlantType.VOID:
                        GetComponent<SpriteRenderer>().sprite = voidPlant;
                        Game_Manager.Instance.voidPlantsGrown++;
                        break;
                    default:
                        GetComponent<SpriteRenderer>().sprite = firePlant;
                        Game_Manager.Instance.firePlantsGrown++;
                        break;
                }
            }
        }

        if(shootTimer == 0)
        {
            canShoot = true;
        }

        if (canShoot && (testEnemyExist != null) && (currentTarget != null))
        {
            if (thisTile.GetComponent<Farm_Controller>().waterLevel > 0)
            {
                float temp = Vector2.Distance(currentTarget.transform.position, this.gameObject.transform.position);
                if (Vector2.Distance(currentTarget.transform.position, this.gameObject.transform.position) <= range)
                {
                    createdBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
                    createdBullet.GetComponent<Bullet>().move = true;
                    createdBullet.GetComponent<Bullet>().target = currentTarget;
                    createdBullet.GetComponent<Bullet>().damage = createdBullet.GetComponent<Bullet>().damage * currentLevel;
                    createdBullet.GetComponent<Bullet>().type = thisPlant;
                    canShoot = false;
                    shootTimer = 60 - ((currentLevel - 1) * 20);
                    thisTile.GetComponent<Farm_Controller>().waterLevel -= 1;

                    if(thisPlant == Game_Manager.PlantType.VOID)
                    {
                        shootTimer = shootTimer / 2;
                    }

                    switch(thisPlant)
                    {
                        case Game_Manager.PlantType.FIRE:
                            createdBullet.GetComponent<Bullet>().thisSprite = fireBullet;
                            break;
                        case Game_Manager.PlantType.ICE:
                            createdBullet.GetComponent<Bullet>().thisSprite = iceBullet;
                            break;
                        case Game_Manager.PlantType.VOID:
                            createdBullet.GetComponent<Bullet>().thisSprite = voidBullet;
                            break;
                        default:
                            createdBullet.GetComponent<Bullet>().thisSprite = fireBullet;
                            break;
                    }
                }
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
