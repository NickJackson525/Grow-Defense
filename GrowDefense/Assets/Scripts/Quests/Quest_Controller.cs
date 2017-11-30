using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Controller : MonoBehaviour
{
    #region Variables

    public GameObject questPopup;
    public GameObject parent;
    public GameObject spawnLocation;
    GameObject createdQuest;
    public Sprite mailIcon;
    public Sprite newMailIcon;
    int timer = 0;
    public int basicRequired = 0;
    public int fireRequired = 0;
    public int iceRequired = 0;
    public int voidRequired = 0;
    bool unviewedQuest = false;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        timer = Random.Range(480, 916);
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		if(timer > 0)
        {
            timer--;
        }
        else
        {
            if((Game_Manager.Instance.currentNumQuests < 3) && !unviewedQuest && Game_Manager.Instance.gameStarted)
            {
                CreateQuest();
                unviewedQuest = true;
                Game_Manager.Instance.currentNumQuests++;
            }

            timer = Random.Range(480, 916);
        }
	}

    #endregion

    #region Create Quest

    public void CreateQuest()
    {
        int questType = Random.Range(1, 4);

        switch(questType)
        {
            case 1:
                OnePlantTypeQuest();
                break;
            case 2:
                TwoPlantTypeQuest();
                break;
            case 3:
                ThreePlantTypeQuest();
                break;
            default:
                TwoPlantTypeQuest();
                break;
        }

        createdQuest.GetComponent<Quest_Popup>().basicRequired = basicRequired;
        createdQuest.GetComponent<Quest_Popup>().fireRequired = fireRequired;
        createdQuest.GetComponent<Quest_Popup>().iceRequired = iceRequired;
        createdQuest.GetComponent<Quest_Popup>().voidRequired = voidRequired;

        GetComponent<Image>().sprite = newMailIcon;

        basicRequired = 0;
        fireRequired = 0;
        iceRequired = 0;
        voidRequired = 0;
    }

    #endregion

    #region Quest Types

    public void OnePlantTypeQuest()
    {
        createdQuest = Instantiate(questPopup, spawnLocation.transform.position, transform.rotation, parent.transform);
        createdQuest.GetComponent<Quest_Popup>().type = 1;
        PickPlantType();
    }

    public void TwoPlantTypeQuest()
    {
        createdQuest = Instantiate(questPopup, spawnLocation.transform.position, transform.rotation, parent.transform);
        createdQuest.GetComponent<Quest_Popup>().type = 2;
        PickPlantType();
        PickPlantType();
    }

    public void ThreePlantTypeQuest()
    {
        createdQuest = Instantiate(questPopup, spawnLocation.transform.position, transform.rotation, parent.transform);
        createdQuest.GetComponent<Quest_Popup>().type = 3;
        PickPlantType();
        PickPlantType();
        PickPlantType();
    }

    #endregion

    #region Pick Plant Type

    public void PickPlantType()
    {
        bool hasBeenPicked = true;
        int rand = 0;

        while (hasBeenPicked)
        {
            rand = Random.Range(1, 5);

            switch (rand)
            {
                case 1:
                    if (basicRequired == 0)
                    {
                        basicRequired = Random.Range(1, 4);
                        hasBeenPicked = false;
                    }
                    else
                    {
                        hasBeenPicked = true;
                    }
                    break;
                case 2:
                    if (fireRequired == 0)
                    {
                        fireRequired = Random.Range(1, 4);
                        hasBeenPicked = false;
                    }
                    else
                    {
                        hasBeenPicked = true;
                    }
                    break;
                case 3:
                    if (iceRequired == 0)
                    {
                        iceRequired = Random.Range(1, 4);
                        hasBeenPicked = false;
                    }
                    else
                    {
                        hasBeenPicked = true;
                    }
                    break;
                case 4:
                    if (voidRequired == 0)
                    {
                        voidRequired = Random.Range(1, 4);
                        hasBeenPicked = false;
                    }
                    else
                    {
                        hasBeenPicked = true;
                    }
                    break;
                default:
                    if (basicRequired == 0)
                    {
                        basicRequired = Random.Range(1, 4);
                        hasBeenPicked = false;
                    }
                    else
                    {
                        hasBeenPicked = true;
                    }
                    break;
            }
        }
    }

    #endregion

    public void OpenNewQuest()
    {
        if(unviewedQuest)
        {
            unviewedQuest = false;
            timer = Random.Range(480, 916);
            createdQuest.SetActive(true);
            GetComponent<Image>().sprite = mailIcon;
            Game_Manager.Instance.pauseGame = true;
        }
    }
}
