using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopup : MonoBehaviour
{
    public int popupNumber = 0;
    public GameObject popup;
    public GameManager.ShopItems thisItem;
    public Text title;
    public Text description;
    Vector3 updatePosition;

    private void Update()
    {
        updatePosition = Input.mousePosition;
        updatePosition = Camera.main.ScreenToWorldPoint(updatePosition);

        if (popupNumber == 1)
        {
            updatePosition = new Vector3(popup.transform.position.x, updatePosition.y - .1f, popup.transform.position.z);
        }
        else if (popupNumber == 2)
        {
            updatePosition = new Vector3(updatePosition.x + 1.2f, popup.transform.position.y, popup.transform.position.z);
        }

        popup.transform.position = Vector2.Lerp(popup.transform.position, updatePosition, 5);
    }

    private void OnMouseEnter()
    {
        if (popupNumber == 1)
        {
            switch (thisItem)
            {
                case GameManager.ShopItems.BASIC:
                    title.text = "<Color=green>Basic Plant</Color> $25";
                    description.text = "This is a basic plant that does a moderate amount of damage and is relatively slow firing.";
                    break;
                case GameManager.ShopItems.FIRE:
                    title.text = "<Color=red>Fire Plant</Color> $50";
                    description.text = "This plant causes damage over time to bugs, meaning the longer the enemies are on screen the more damage they take (even if this plant has stopped shooting at it).";
                    break;
                case GameManager.ShopItems.ICE:
                    title.text = "<Color=blue>Ice Plant</Color> $50";
                    description.text = "This plant causes bugs to slow down. It does a low amount of damage and has an average attack speed.";
                    break;
                case GameManager.ShopItems.VOID:
                    title.text = "<Color=purple>Void Plant</Color> $50";
                    description.text = "This plant does an average amount of damage but shoots twice as fast as most other plants.";
                    break;
                case GameManager.ShopItems.SPRINKLER:
                    title.text = "<Color=yellow>Sprinkler</Color> $25";
                    description.text = "This can be placed on a farm tile and makes it so you no longer have to water it!";
                    break;
                case GameManager.ShopItems.FERTILIZER:
                    title.text = "<Color=yellow>Fertilizer</Color> $50";
                    description.text = "This can be placed on a farm tile and makes your plants grow twice as fast.";
                    break;
            }
        }
        else if (popupNumber == 2)
        {
            switch(thisItem)
            {
                case GameManager.ShopItems.WATER:
                    title.text = "<Color=yellow>Watering Can</Color>";
                    description.text = "Use this to water your plants. They need water in order to grow and to attack enemies.";
                    break;
                case GameManager.ShopItems.SICLE:
                    title.text = "<Color=yellow>Sicle</Color>";
                    description.text = "Use this to harvest fully grown plants. This is how you complete quests for other farmers.";
                    break;
                case GameManager.ShopItems.SELL:
                    title.text = "<Color=yellow>Sell</Color>";
                    description.text = "Use this to sell your plants. You can sell them at any level of growth, but you won't make money on them unless they are fully grown.";
                    break;
            }
        }

        popup.SetActive(true);
    }

    private void OnMouseExit()
    {
        popup.SetActive(false);
    }
}
