using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor_Image : MonoBehaviour
{
    #region Variables

    public Sprite sicleCursor;
    public Sprite sellCursor;
    public Sprite wateringCanCursor;
    public Sprite basicSeedPacketCursor;
    public Sprite fireSeedPacketCursor;
    public Sprite iceSeedPacketCursor;
    public Sprite voidSeedPacketCursor;
    public Sprite fertilizerCursor;
    public Sprite defaultCursor;
    public GameObject select;
    public Vector3 updatePosition;
    float moveSpeed = 10;
    Quaternion startRotation;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        startRotation = transform.rotation;
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        Cursor.visible = false;
        updatePosition = Input.mousePosition;
        updatePosition = Camera.main.ScreenToWorldPoint(updatePosition);
        updatePosition = new Vector3(updatePosition.x + .1f, updatePosition.y - .1f, -3);
        transform.position = Vector2.Lerp(transform.position, updatePosition, moveSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        if(Input.GetMouseButtonDown(0) && ((GetComponent<SpriteRenderer>().sprite.name != wateringCanCursor.name) && (GetComponent<SpriteRenderer>().sprite.name != sicleCursor.name)))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 20f);
        }
        else if (Input.GetMouseButtonDown(1) && ((GetComponent<SpriteRenderer>().sprite.name == wateringCanCursor.name) || (GetComponent<SpriteRenderer>().sprite.name == sicleCursor.name)))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 20f);
        }

        if (Input.GetMouseButtonUp(0) && ((GetComponent<SpriteRenderer>().sprite.name != wateringCanCursor.name) && (GetComponent<SpriteRenderer>().sprite.name != sicleCursor.name)))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 20f);
        }
        else if (Input.GetMouseButtonUp(1) && ((GetComponent<SpriteRenderer>().sprite.name == wateringCanCursor.name) || (GetComponent<SpriteRenderer>().sprite.name == sicleCursor.name)))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 20f);
        }

        if(GameManager.Instance.gameOver || GameManager.Instance.pauseGame || GameManager.Instance.placingUpgrade || (SceneManager.GetActiveScene().name == "Main Menu"))
        {
            GetComponent<SpriteRenderer>().sprite = defaultCursor;
        }

        if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            transform.rotation = startRotation;
        }
    }

    #endregion

    #region Collision Methods

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "FarmTile")
        {
            switch (GameManager.Instance.currentShopSelection)
            {
                case GameManager.ShopItems.BASIC:
                    GetComponent<SpriteRenderer>().sprite = basicSeedPacketCursor;
                    break;
                case GameManager.ShopItems.FIRE:
                    GetComponent<SpriteRenderer>().sprite = fireSeedPacketCursor;
                    break;
                case GameManager.ShopItems.ICE:
                    GetComponent<SpriteRenderer>().sprite = iceSeedPacketCursor;
                    break;
                case GameManager.ShopItems.VOID:
                    GetComponent<SpriteRenderer>().sprite = voidSeedPacketCursor;
                    break;
                case GameManager.ShopItems.FERTILIZER:
                    GetComponent<SpriteRenderer>().sprite = defaultCursor;
                    break;
                case GameManager.ShopItems.SPRINKLER:
                    GetComponent<SpriteRenderer>().sprite = defaultCursor;
                    break;
                case GameManager.ShopItems.WATER:
                    GetComponent<SpriteRenderer>().sprite = wateringCanCursor;
                    break;
                case GameManager.ShopItems.SICLE:
                    GetComponent<SpriteRenderer>().sprite = sicleCursor;
                    break;
                case GameManager.ShopItems.SELL:
                    GetComponent<SpriteRenderer>().sprite = sellCursor;
                    break;
                default:
                    GetComponent<SpriteRenderer>().sprite = defaultCursor;
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "FarmTile")
        {
            switch(GameManager.Instance.currentShopSelection)
            {
                case GameManager.ShopItems.BASIC:
                    GetComponent<SpriteRenderer>().sprite = basicSeedPacketCursor;
                    break;
                case GameManager.ShopItems.FIRE:
                    GetComponent<SpriteRenderer>().sprite = fireSeedPacketCursor;
                    break;
                case GameManager.ShopItems.ICE:
                    GetComponent<SpriteRenderer>().sprite = iceSeedPacketCursor;
                    break;
                case GameManager.ShopItems.VOID:
                    GetComponent<SpriteRenderer>().sprite = voidSeedPacketCursor;
                    break;
                case GameManager.ShopItems.FERTILIZER:
                    GetComponent<SpriteRenderer>().sprite = defaultCursor;
                    break;
                case GameManager.ShopItems.SPRINKLER:
                    GetComponent<SpriteRenderer>().sprite = defaultCursor;
                    break;
                case GameManager.ShopItems.WATER:
                    GetComponent<SpriteRenderer>().sprite = wateringCanCursor;
                    break;
                case GameManager.ShopItems.SICLE:
                    GetComponent<SpriteRenderer>().sprite = sicleCursor;
                    break;
                case GameManager.ShopItems.SELL:
                    GetComponent<SpriteRenderer>().sprite = sellCursor;
                    break;
                default:
                    GetComponent<SpriteRenderer>().sprite = defaultCursor;
                    break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        //GetComponent<SpriteRenderer>().sprite = defaultCursor;
    }

    #endregion
}
