using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    #region Variables
     
    public GameObject[] fullPath;
    public GameObject bug1;
    public GameObject bug2;
    public GameObject bug3;
    GameObject bugCreated;
    public int cooldown = 250;
    public int cooldownConst = 250;
    public int spawnRateIncrease = 10;
    int rand;

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
        if (!GameManager.Instance.pauseGame && GameManager.Instance.gameStarted && (SceneManager.GetActiveScene().name != "Tutorial"))
        {
            if ((GameManager.Instance.currentPhase == GameManager.Phase.NIGHT) && (GameManager.Instance.nightTimer > 0) && (!GameManager.Instance.gameOver))
            {
                cooldown--;

                if (cooldown <= 0)
                {
                    switch(Random.Range(1, 4))
                    {
                        case 1:
                            bugCreated = Instantiate(bug1, transform.position, transform.rotation);
                            bugCreated.GetComponent<Enemy_Controller>().health += 1 * (int)Mathf.Pow(2f, GameManager.Instance.waveNumber - 1);
                            break;
                        case 2:
                            bugCreated = Instantiate(bug2, transform.position, transform.rotation);
                            bugCreated.GetComponent<Enemy_Controller>().health += (1 * (int)Mathf.Pow(2f, GameManager.Instance.waveNumber - 1)) / 2;
                            break;
                        case 3:
                            bugCreated = Instantiate(bug3, transform.position, transform.rotation);
                            bugCreated.GetComponent<Enemy_Controller>().health += (1 * (int)Mathf.Pow(2f, GameManager.Instance.waveNumber - 1)) * 2;
                            break;
                        default:
                            bugCreated = Instantiate(bug1, transform.position, transform.rotation);
                            bugCreated.GetComponent<Enemy_Controller>().health += 1 * (int)Mathf.Pow(2f, GameManager.Instance.waveNumber - 1);
                            break;
                    }

                    bugCreated.GetComponent<Enemy_Controller>().fullPath = fullPath;
                    cooldown = cooldownConst - (GameManager.Instance.waveNumber * 25);

                    if (cooldown < 50)
                    {
                        cooldown = 50;
                    }
                }
            }
            else
            {
                if (GameManager.Instance.currentPhase == GameManager.Phase.NIGHT)
                {
                    cooldown = cooldownConst;
                    //spawnCount = 0;
                    GameManager.Instance.currentPhase = GameManager.Phase.DAY;
                    GameManager.Instance.dayTimer = GameManager.Instance.dayTimerConstant;
                    GameManager.Instance.waveNumber++;
                }
            }
        }
	}

    #endregion

    #region Public Methods

    public void SpawnBug()
    {
        bugCreated = Instantiate(bug1, transform.position, transform.rotation);
        bugCreated.GetComponent<Enemy_Controller>().health += 1 * (int)Mathf.Pow(2f, GameManager.Instance.waveNumber - 1);
    }

    #endregion
}
