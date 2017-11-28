using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Popup : MonoBehaviour
{
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

    // Use this for initialization
    void Start ()
    {
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

    #region Popup Type 1

    public void TypeOne()
    {
        letterContent1.SetActive(true);
        letterContent2.SetActive(false);
        letterContent3.SetActive(false);

        if(basicRequired > 0)
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

    public void AcceptQuest()
    {
        switch(Game_Manager.Instance.currentNumQuests)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    public void RejectQuest()
    {
        Destroy(gameObject);
    }
}
