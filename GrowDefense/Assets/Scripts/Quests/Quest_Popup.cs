using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest_Popup : MonoBehaviour
{
    #region Variables

    public Button completeQuestButton;
    public Sprite Portrait1;
    public Sprite Portrait2;
    public Sprite Portrait3;
    public Sprite Portrait4;
    public Sprite Portrait5;
    public Sprite Portrait6;
    public GameObject letterContent1;
    public GameObject letterContent2;
    public GameObject letterContent3;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject Objective3;
    public int type = 2;
    public int basicRequired = 0;
    public int fireRequired = 0;
    public int iceRequired = 0;
    public int voidRequired = 0;
    int randomCharacter = 0;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        Objective1 = GameManager.Instance.Objective1;
        Objective2 = GameManager.Instance.Objective2;
        Objective3 = GameManager.Instance.Objective3;
        randomCharacter = Random.Range(1, 6);

        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            randomCharacter = 1;
        }

        switch (type)
        {
            case 1:
                TypeOne();
                break;
            case 2:
                TypeTwo();
                break;
            case 3:
                TypeThree();
                break;
            default:
                TypeTwo();
                break;
        }
    }

    #endregion

    #region Popup Type 1

    public void TypeOne()
    {
        letterContent1.SetActive(true);
        letterContent2.SetActive(false);
        letterContent3.SetActive(false);

        letterContent1.GetComponent<Quest_Letter_Content>().type = type;
        letterContent1.GetComponent<Quest_Letter_Content>().basicRequired = basicRequired;
        letterContent1.GetComponent<Quest_Letter_Content>().fireRequired = fireRequired;
        letterContent1.GetComponent<Quest_Letter_Content>().iceRequired = iceRequired;
        letterContent1.GetComponent<Quest_Letter_Content>().voidRequired = voidRequired;

        #region Change Character Icon

        switch (randomCharacter)
        {
            case 1:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Linus"; 
                break;
            case 2:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait2;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Frank";
                break;
            case 3:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait3;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Chandler";
                break;
            case 4:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait4;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Jane";
                break;
            case 5:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait5;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Chris";
                break;
            case 6:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait6;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-George";
                break;
            default:
                letterContent1.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                letterContent1.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Linus";
                break;
        }

        #endregion

        if (basicRequired > 0)
        {
            letterContent1.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color> Plants for defense.";
            letterContent1.GetComponent<Quest_Letter_Content>().Line4.text = "pay you well! I need <Color=green>" + basicRequired + "</Color> to";
        }
        else if(fireRequired > 0)
        {
            letterContent1.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=red>Fire</Color> Plants for defense.";
            letterContent1.GetComponent<Quest_Letter_Content>().Line4.text = "pay you well! I need <Color=red>" + fireRequired + "</Color> to";
        }
        else if (iceRequired > 0)
        {
            letterContent1.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=blue>Ice</Color> Plants for defense.";
            letterContent1.GetComponent<Quest_Letter_Content>().Line4.text = "pay you well! I need <Color=blue>" + iceRequired + "</Color> to";
        }
        else if (voidRequired > 0)
        {
            letterContent1.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=purple>Void</Color> Plants for defense.";
            letterContent1.GetComponent<Quest_Letter_Content>().Line4.text = "pay you well! I need <Color=purple>" + voidRequired + "</Color> to";
        }
    }

    #endregion

    #region Popup Type 2

    public void TypeTwo()
    {
        letterContent1.SetActive(false);
        letterContent2.SetActive(true);
        letterContent3.SetActive(false);

        letterContent2.GetComponent<Quest_Letter_Content>().type = type;
        letterContent2.GetComponent<Quest_Letter_Content>().basicRequired = basicRequired;
        letterContent2.GetComponent<Quest_Letter_Content>().fireRequired = fireRequired;
        letterContent2.GetComponent<Quest_Letter_Content>().iceRequired = iceRequired;
        letterContent2.GetComponent<Quest_Letter_Content>().voidRequired = voidRequired;

        #region Change Character Icon

        switch (randomCharacter)
        {
            case 1:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Linus";
                break;
            case 2:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait2;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Frank";
                break;
            case 3:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait3;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Chandler";
                break;
            case 4:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait4;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Jane";
                break;
            case 5:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait5;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Chris";
                break;
            case 6:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait6;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-George";
                break;
            default:
                letterContent2.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                letterContent2.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Linus";
                break;
        }

        #endregion

        if ((basicRequired > 0) && (fireRequired > 0))
        {
            letterContent2.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color> and <Color=red>Fire</Color> Plants for";
            letterContent2.GetComponent<Quest_Letter_Content>().Line5.text = "<Color=green>" + basicRequired + " Basic</Color> and <Color=red>" + fireRequired + " Fire</Color> to defend my";
        }
        else if ((basicRequired > 0) && (iceRequired > 0))
        {
            letterContent2.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color> and <Color=blue>Ice</Color> Plants for";
            letterContent2.GetComponent<Quest_Letter_Content>().Line5.text = "<Color=green>" + basicRequired + " Basic</Color> and <Color=blue>" + iceRequired + " Ice</Color> to defend my";
        }
        else if ((basicRequired > 0) && (voidRequired > 0))
        {
            letterContent2.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color> and <Color=purple>Void</Color> Plants for";
            letterContent2.GetComponent<Quest_Letter_Content>().Line5.text = "<Color=green>" + basicRequired + " Basic</Color> and <Color=purple>" + voidRequired + " Void</Color> to defend my";
        }
        else if ((fireRequired > 0) && (iceRequired > 0))
        {
            letterContent2.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=red>Fire</Color> and <Color=blue>Ice</Color> Plants for";
            letterContent2.GetComponent<Quest_Letter_Content>().Line5.text = "<Color=red>" + fireRequired + " Fire</Color> and <Color=blue>" + iceRequired + " Ice</Color> to defend my";

        }
        else if ((fireRequired > 0) && (voidRequired > 0))
        {
            letterContent2.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=red>Fire</Color> and <Color=purple>Void</Color> Plants for";
            letterContent2.GetComponent<Quest_Letter_Content>().Line5.text = "<Color=red>" + fireRequired + " Fire</Color> and <Color=purple>" + voidRequired + " Void</Color> to defend my";
        }
        else if ((iceRequired > 0) && (voidRequired > 0))
        {
            letterContent2.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=blue>Ice</Color> and <Color=purple>Void</Color> Plants for";
            letterContent2.GetComponent<Quest_Letter_Content>().Line5.text = "<Color=blue>" + iceRequired + " Ice</Color> and <Color=purple>" + voidRequired + " Void</Color> to defend my";
        }
    }

    #endregion

    #region Popup Type 3

    public void TypeThree()
    {
        letterContent1.SetActive(false);
        letterContent2.SetActive(false);
        letterContent3.SetActive(true);

        letterContent3.GetComponent<Quest_Letter_Content>().type = type;
        letterContent3.GetComponent<Quest_Letter_Content>().basicRequired = basicRequired;
        letterContent3.GetComponent<Quest_Letter_Content>().fireRequired = fireRequired;
        letterContent3.GetComponent<Quest_Letter_Content>().iceRequired = iceRequired;
        letterContent3.GetComponent<Quest_Letter_Content>().voidRequired = voidRequired;

        #region Change Character Icon

        switch (randomCharacter)
        {
            case 1:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Linus";
                break;
            case 2:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait2;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Frank";
                break;
            case 3:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait3;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Chandler";
                break;
            case 4:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait4;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Jane";
                break;
            case 5:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait5;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Chris";
                break;
            case 6:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait6;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-George";
                break;
            default:
                letterContent3.GetComponent<Quest_Letter_Content>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                letterContent3.GetComponent<Quest_Letter_Content>().SignatureLine.text = "-Linus";
                break;
        }

        #endregion

        if ((basicRequired > 0) && (fireRequired > 0) && (iceRequired > 0))
        {
            letterContent3.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color>, <Color=red>Fire</Color>, and <Color=blue>Ice</Color> Plants";
            letterContent3.GetComponent<Quest_Letter_Content>().Line5.text = "need <Color=green>" + basicRequired + " Basic</Color>, <Color=red>" + fireRequired + " Fire</Color>, and <Color=blue>" + iceRequired + " Ice</Color>";
        }
        else if ((basicRequired > 0) && (fireRequired > 0) && (voidRequired > 0))
        {
            letterContent3.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color>, <Color=red>Fire</Color>, and <Color=purple>Void</Color> Plants";
            letterContent3.GetComponent<Quest_Letter_Content>().Line5.text = "need <Color=green>" + basicRequired + " Basic</Color>, <Color=red>" + fireRequired + " Fire</Color>, and <Color=purple>" + voidRequired + " Void</Color>";
        }
        else if ((basicRequired > 0) && (iceRequired > 0) && (voidRequired > 0))
        {
            letterContent3.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=green>Basic</Color>, <Color=blue>Ice</Color>, and <Color=purple>Void</Color> Plants";
            letterContent3.GetComponent<Quest_Letter_Content>().Line5.text = "need <Color=green>" + basicRequired + " Basic</Color>, <Color=blue>" + iceRequired + " Ice</Color>, and <Color=purple>" + voidRequired + " Void</Color>";
        }
        else if ((fireRequired > 0) && (iceRequired > 0) && (voidRequired > 0))
        {
            letterContent3.GetComponent<Quest_Letter_Content>().Line2.text = "some <Color=red>Fire</Color>, <Color=blue>Ice</Color>, and <Color=purple>Void</Color> Plants";
            letterContent3.GetComponent<Quest_Letter_Content>().Line5.text = "need <Color=red>" + fireRequired + " Fire</Color>, <Color=blue>" + iceRequired + " Ice</Color>, and <Color=purple>" + voidRequired + " Void</Color>";
        }
    }

    #endregion

    #region Accept Quest

    public void AcceptQuest()
    {
        switch(GameManager.Instance.currentNumQuests)
        {
            case 1:
                UpdateObjectives(Objective1);
                break;
            case 2:
                UpdateObjectives(Objective2);
                break;
            case 3:
                UpdateObjectives(Objective3);
                break;
        }

        GameManager.Instance.pauseGame = false;
        Destroy(gameObject);
    }

    #endregion

    #region Reject Quest

    public void RejectQuest()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            GameManager.Instance.pauseGame = false;
            GameManager.Instance.currentNumQuests--;
            Destroy(gameObject);
        }
    }

    #endregion

    #region Update Objectives

    public void UpdateObjectives(GameObject objective)
    {
        objective.SetActive(true);
        objective.GetComponent<ObjectiveData>().type = type;
        objective.GetComponent<ObjectiveData>().basicRequired = basicRequired;
        objective.GetComponent<ObjectiveData>().fireRequired = fireRequired;
        objective.GetComponent<ObjectiveData>().iceRequired = iceRequired;
        objective.GetComponent<ObjectiveData>().voidRequired = voidRequired;
        objective.GetComponent<ObjectiveData>().plant1.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant2.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant3.SetActive(false);
        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(false);

        switch(randomCharacter)
        {
            case 1:
                objective.GetComponent<ObjectiveData>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                break;
            case 2:
                objective.GetComponent<ObjectiveData>().characterIcon.GetComponent<Image>().sprite = Portrait2;
                break;
            case 3:
                objective.GetComponent<ObjectiveData>().characterIcon.GetComponent<Image>().sprite = Portrait3;
                break;
            case 4:
                objective.GetComponent<ObjectiveData>().characterIcon.GetComponent<Image>().sprite = Portrait4;
                break;
            case 5:
                objective.GetComponent<ObjectiveData>().characterIcon.GetComponent<Image>().sprite = Portrait5;
                break;
            default:
                objective.GetComponent<ObjectiveData>().characterIcon.GetComponent<Image>().sprite = Portrait1;
                break;
        }

        #region Update Basic

        if (basicRequired > 0)
        {
            objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
            objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
            objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().basicPlant;
            objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + basicRequired;
        }

        #endregion

        #region Update Fire

        if (fireRequired > 0)
        {
            if(basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().firePlant;
                objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + fireRequired;
            }
            else
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().firePlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + fireRequired;
            }
        }

        #endregion

        #region Update Ice

        if (iceRequired > 0)
        {
            if(fireRequired > 0)
            {
                if (basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                    objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + iceRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + iceRequired;
                }
            }
            else if (basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + iceRequired;
            }
            else
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().icePlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + iceRequired;
            }
        }

        #endregion

        #region Update Void

        if (voidRequired > 0)
        {
            if(iceRequired > 0)
            {
                if(fireRequired > 0)
                {
                    if(basicRequired > 0)
                    {
                        objective.GetComponent<ObjectiveData>().plant4.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant4Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant4.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                        objective.GetComponent<ObjectiveData>().plant4Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                    }
                    else
                    {
                        objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                        objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                        objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                    }
                }
                else if (basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                    objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
            }
            else if(fireRequired > 0)
            {
                if(basicRequired > 0)
                {
                    objective.GetComponent<ObjectiveData>().plant3.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant3.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                    objective.GetComponent<ObjectiveData>().plant3Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
                else
                {
                    objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                    objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                    objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + voidRequired;
                }
            }
            else if (basicRequired > 0)
            {
                objective.GetComponent<ObjectiveData>().plant2.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant2.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                objective.GetComponent<ObjectiveData>().plant2Grown.GetComponent<Text>().text = "0 / " + voidRequired;
            }
            else
            {
                objective.GetComponent<ObjectiveData>().plant1.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1Grown.SetActive(true);
                objective.GetComponent<ObjectiveData>().plant1.GetComponent<SpriteRenderer>().sprite = objective.GetComponent<ObjectiveData>().voidPlant;
                objective.GetComponent<ObjectiveData>().plant1Grown.GetComponent<Text>().text = "0 / " + voidRequired;
            }
        }

        #endregion
    }

    #endregion
}
