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
    bool moveBack = false;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(moveBack)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, .05f);

            if(Vector3.Distance(transform.position, startPos) <= .1f)
            {
                transform.position = startPos;
                moveBack = false;
            }
        }
    }

    public void MoveDown()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 4.6f, transform.position.z), .05f);
    }

    public void MoveUp()
    {
        moveBack = true;
    }
}