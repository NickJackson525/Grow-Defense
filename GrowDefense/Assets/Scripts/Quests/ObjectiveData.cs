using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveData : MonoBehaviour
{
    public Button completeQuestButton;
    public Sprite basicPlant;
    public Sprite firePlant;
    public Sprite icePlant;
    public Sprite voidPlant;
    public GameObject plant1;
    public GameObject plant2;
    public GameObject plant3;
    public GameObject plant4;
    public GameObject plant1Grown;
    public GameObject plant2Grown;
    public GameObject plant3Grown;
    public GameObject plant4Grown;
    public int ObjectiveNum = 0;
    public int type = 2;
    public int basicRequired = 0;
    public int fireRequired = 0;
    public int iceRequired = 0;
    public int voidRequired = 0;
    int questReward = 0;

    // Use this for initialization
    void Awake ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((basicRequired <= 0) && (fireRequired <= 0) && (iceRequired <= 0) && (voidRequired <= 0))
        {
            completeQuestButton.interactable = false;
        }
        else if ((Game_Manager.Instance.basicPlantsHarvested >= basicRequired) && (Game_Manager.Instance.firePlantsHarvested >= fireRequired) && (Game_Manager.Instance.icePlantsHarvested >= iceRequired) && (Game_Manager.Instance.voidPlantsHarvested >= voidRequired))
        {
            completeQuestButton.interactable = true;
        }
    }

    #region Complete Quest

    public void CompleteQuest()
    {
        #region Calculate Quest Reward

        if (basicRequired > 0)
        {
            questReward += 25 * basicRequired;
            Game_Manager.Instance.basicPlantsHarvested -= basicRequired;
        }

        if (fireRequired > 0)
        {
            questReward += 50 * fireRequired;
            Game_Manager.Instance.firePlantsHarvested -= fireRequired;
        }

        if (iceRequired > 0)
        {
            questReward += 50 * iceRequired;
            Game_Manager.Instance.icePlantsHarvested -= iceRequired;
        }

        if (voidRequired > 0)
        {
            questReward += 50 * voidRequired;
            Game_Manager.Instance.voidPlantsHarvested -= voidRequired;
        }

        switch(type)
        {
            case 1:
                questReward += 100;
                break;
            case 2:
                questReward += 200;
                break;
            case 3:
                questReward += 300;
                break;
            default:
                questReward += 200;
                break;
        }

        #endregion

        Game_Manager.Instance.money += questReward;
        questReward = 0;
        Game_Manager.Instance.currentNumQuests--;

        #region Delete Objective

        //only had 1 quest
        if (Game_Manager.Instance.currentNumQuests == 0)
        {
            #region Make Objective 1 blank

            plant1.SetActive(false);
            plant2.SetActive(false);
            plant3.SetActive(false);
            plant1Grown.SetActive(false);
            plant2Grown.SetActive(false);
            plant3Grown.SetActive(false);
            basicRequired = 0;
            fireRequired = 0;
            iceRequired = 0;
            voidRequired = 0;

            #endregion
        }
        //only had 2 quests
        else if (Game_Manager.Instance.currentNumQuests == 1)
        {
            if (ObjectiveNum == 2)
            {
                #region Make Objective 2 blank

                plant1.SetActive(false);
                plant2.SetActive(false);
                plant3.SetActive(false);
                plant1Grown.SetActive(false);
                plant2Grown.SetActive(false);
                plant3Grown.SetActive(false);
                basicRequired = 0;
                fireRequired = 0;
                iceRequired = 0;
                voidRequired = 0;

                #endregion
            }
            else
            {
                #region Move Objective 2 Up

                plant1.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite;
                plant2.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite;
                plant3.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite;
                plant1Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text;
                plant2Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text;
                plant3Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text;
                basicRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().basicRequired;
                fireRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().fireRequired;
                iceRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().iceRequired;
                voidRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().voidRequired;

                #endregion

                #region Make Objective 2 blank

                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1.SetActive(false);
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2.SetActive(false);
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3.SetActive(false);
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1Grown.SetActive(false);
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2Grown.SetActive(false);
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3Grown.SetActive(false);
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().basicRequired = 0;
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().fireRequired = 0;
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().iceRequired = 0;
                Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().voidRequired = 0;
                completeQuestButton.interactable = false;

                #endregion
            }
        }
        //had 3 quests
        else
        {
            switch (ObjectiveNum)
            {
                case 1:
                    #region Move Objective 2 Up

                    plant1.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite;
                    plant2.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite;
                    plant3.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite;
                    plant1Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text;
                    plant2Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text;
                    plant3Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text;
                    basicRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().basicRequired;
                    fireRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().fireRequired;
                    iceRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().iceRequired;
                    voidRequired = Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().voidRequired;

                    #endregion

                    #region Move Objective 3 Up

                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().basicRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().basicRequired;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().fireRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().fireRequired;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().iceRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().iceRequired;
                    Game_Manager.Instance.Objective2.GetComponent<ObjectiveData>().voidRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().voidRequired;

                    #endregion

                    #region Make Objective 3 blank

                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1Grown.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2Grown.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3Grown.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().basicRequired = 0;
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().fireRequired = 0;
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().iceRequired = 0;
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().voidRequired = 0;
                    completeQuestButton.interactable = false;

                    #endregion
                    break;
                case 2:
                    #region Move Objective 3 Up

                    plant1.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite;
                    plant2.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite;
                    plant3.GetComponent<SpriteRenderer>().sprite = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite;
                    plant1Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text;
                    plant2Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text;
                    plant3Grown.GetComponent<Text>().text = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text;
                    basicRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().basicRequired;
                    fireRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().fireRequired;
                    iceRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().iceRequired;
                    voidRequired = Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().voidRequired;

                    #endregion

                    #region Make Objective 3 blank

                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant1Grown.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant2Grown.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().plant3Grown.SetActive(false);
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().basicRequired = 0;
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().fireRequired = 0;
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().iceRequired = 0;
                    Game_Manager.Instance.Objective3.GetComponent<ObjectiveData>().voidRequired = 0;
                    completeQuestButton.interactable = false;

                    #endregion
                    break;
                case 3:
                    #region Make Objective 3 blank

                    plant1.SetActive(false);
                    plant2.SetActive(false);
                    plant3.SetActive(false);
                    plant1Grown.SetActive(false);
                    plant2Grown.SetActive(false);
                    plant3Grown.SetActive(false);
                    basicRequired = 0;
                    fireRequired = 0;
                    iceRequired = 0;
                    voidRequired = 0;
                    completeQuestButton.interactable = false;

                    #endregion
                    break;
            }
        }

        #endregion
    }

    #endregion

    public void UpdateObjectives(GameObject objective)
    {
        gameObject.SetActive(true);
        objective.GetComponent<ObjectiveData>().plant1.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant2.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant3.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(false);

        #region Update Basic

        if (basicRequired > 0)
        {
            objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
            objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
            objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = basicPlant;
            objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + basicRequired;
        }

        #endregion

        #region Update Fire

        if (fireRequired > 0)
        {
            if (basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = firePlant;
                objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + fireRequired;
            }
            else
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<ObjectiveData>().firePlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + fireRequired;
            }
        }

        #endregion

        #region Update Ice

        if (iceRequired > 0)
        {
            if (fireRequired > 0)
            {
                if (basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = icePlant;
                    objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + iceRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = icePlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + iceRequired;
                }
            }
            else if (basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = icePlant;
                objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + iceRequired;
            }
            else
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = icePlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + iceRequired;
            }
        }

        #endregion

        #region Update Void

        if (voidRequired > 0)
        {
            if (iceRequired > 0)
            {
                if (fireRequired > 0)
                {
                    if (basicRequired > 0)
                    {
                        objective.GetComponent<ObjectiveData>().plant4.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant4Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant4.GetComponent<SpriteRenderer>().sprite = voidPlant;
                        objective.GetComponent<ObjectiveData>().plant4Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                    }
                    else
                    {
                        objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = voidPlant;
                        objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                    }
                }
                else if (basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = voidPlant;
                    objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = voidPlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
            }
            else if (fireRequired > 0)
            {
                if (basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = voidPlant;
                    objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = voidPlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
            }
            else if (basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = voidPlant;
                objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + voidRequired;
            }
            else
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = voidPlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + voidRequired;
            }
        }

        #endregion
    }
}
