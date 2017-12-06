using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPopup : MonoBehaviour
{
    public Dictionary<HelpType, string> PopupInfo = new Dictionary<HelpType, string>
    {
        {HelpType.DRYPLANTS, "Remember to keep your plants watered or they won't grow or attack!"},
        {HelpType.NOMONEY1, "You need more money to do that, try pressing start and killing bugs!"},
        {HelpType.NOMONEY2, "You need more money to do that, try completing quests!"},
        {HelpType.NOMONEY3, "You need more money to do that, try selling a grown plant with the \"$\" tool."}
    };

    public enum HelpType {DRYPLANTS, NOMONEY1, NOMONEY2, NOMONEY3}
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

            if((autoHide == 0) && (transform.position != startPos))
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

        if(moveDown)
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