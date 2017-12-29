using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpPopup : MonoBehaviour
{
    public Dictionary<HelpType, string> PopupInfo = new Dictionary<HelpType, string>
    {
        {HelpType.DRYPLANTS, "Remember to keep your plants watered or they won't grow or attack!"},
        {HelpType.NOMONEY1, "You need more money to do that, try pressing start and killing bugs!"},
        {HelpType.NOMONEY2, "You need more money to do that, try completing quests!"},
        {HelpType.NOMONEY3, "You need more money to do that, try selling a grown plant with the \"$\" tool."},
        {HelpType.TUTORIAL1, "Left click the basic plant, then left click the flashing farm tile to plant it."},
        {HelpType.TUTORIAL2, "Left click the watering can or press 1, then right click to water your plant."},
        {HelpType.TUTORIAL3, "Left click the fire plant, then left click the flashing farm tile to plant it."},
        {HelpType.TUTORIAL4, "Remember to water your plants or they won't attack or grow!"},
        {HelpType.TUTORIAL5, "Left click the mail icon to see the quest, then use the sicle tool to harvest your plant."},
        {HelpType.TUTORIAL6, "Press escape to access the pause menu, then click quest log to see current quests."},
        {HelpType.TUTORIAL7, "7"},
        {HelpType.TUTORIAL8, "8"},
    };

    public enum HelpType {DRYPLANTS, NOMONEY1, NOMONEY2, NOMONEY3, TUTORIAL1, TUTORIAL2, TUTORIAL3, TUTORIAL4, TUTORIAL5, TUTORIAL6, TUTORIAL7, TUTORIAL8}
    public HelpType thisHelpType = HelpType.DRYPLANTS;
    public Text popupText;
    public Vector3 startPos;
    public int popupCooldown = 0;
    int autoHide = 0;
    bool moveBack = false;
    bool moveDown = false;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(popupCooldown > 0)
        {
            popupCooldown--;
        }

        if(autoHide > 0)
        {
            autoHide--;

            if((autoHide == 0) && (transform.position != startPos) && (SceneManager.GetActiveScene().name != "Tutorial"))
            {
                MoveUp();
            }
        }

        if(moveBack)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, startPos.y, transform.position.z), .05f);

            if(Vector3.Distance(transform.position, startPos) <= .1f)
            {
                transform.position = startPos;
                moveBack = false;
                autoHide = 0;
            }
        }

        if (moveDown && GameManager.Instance.helpPopupsEnabled)
        {
            if ((Vector3.Distance(transform.position, new Vector3(transform.position.x, 4.6f, transform.position.z)) > .1f) && (popupCooldown <= 0))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 4.6f, transform.position.z), .05f);
            }
            else if (Vector3.Distance(transform.position, new Vector3(transform.position.x, 4.6f, transform.position.z)) < .1f)
            {
                autoHide = 240;
                moveDown = false;
            }
        }
    }

    public void MoveDown()
    {
        popupText.text = PopupInfo[thisHelpType];
        moveDown = true;
    }

    public void MoveUp()
    {
        moveBack = true;
        popupCooldown = 360;
    }
}