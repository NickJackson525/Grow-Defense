using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables

    public GameObject bug1;
    GameObject bugCreated;
    public int cooldown = 250;
    public int cooldownConst = 250;
    public int spawnCount = 0;
    public int spawnRateIncrease = 10;
    int totalWaveEnemies = 5;
    int waveEnemyConstant = 15;

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
        if (!GameManager.Instance.pauseGame && GameManager.Instance.gameStarted && !Tutorial_Manager.Instance.tutorialStartred)
        {
            if ((GameManager.Instance.currentPhase == GameManager.Phase.NIGHT) && (spawnCount < totalWaveEnemies) && (!GameManager.Instance.gameOver))
            {
                cooldown--;

                if (spawnCount == 0)
                {
                    totalWaveEnemies = waveEnemyConstant * GameManager.Instance.waveNumber;
                    GameManager.Instance.totalWaveEnemies = totalWaveEnemies;
                }

                if (cooldown <= 0)
                {
                    bugCreated = Instantiate(bug1, transform.position, transform.rotation);
                    bugCreated.GetComponent<Enemy_Controller>().health += 1 * (int)Mathf.Pow(2f, GameManager.Instance.waveNumber - 1);
                    cooldown = cooldownConst - (GameManager.Instance.waveNumber * 25);

                    if (cooldown < 50)
                    {
                        cooldown = 50;
                    }

                    spawnCount++;
                    GameManager.Instance.spawnCount = spawnCount;
                }
            }
            else
            {
                if ((GameObject.FindGameObjectWithTag("Enemy") == null) && (GameManager.Instance.currentPhase == GameManager.Phase.NIGHT))
                {
                    cooldown = cooldownConst;
                    spawnCount = 0;
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
