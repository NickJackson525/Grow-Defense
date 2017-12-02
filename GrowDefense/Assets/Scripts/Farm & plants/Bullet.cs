using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables

    public Sprite thisSprite;
    public bool move = false;
    public GameObject target;
    public int damage = 15;
    public float slowDownPercent = 0;
    public int damageOverTime = 0;
    public int DOT_effectTimer = 0;
    public int slowEffectTimer = 0;
    public int level = 1;
    public float speed = .2f;
    public GameManager.ShopItems type = GameManager.ShopItems.BASIC;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
		switch(type)
        {
            case GameManager.ShopItems.BASIC:
                GetComponent<SpriteRenderer>().sprite = thisSprite;
                damage = 2 * level;
                slowDownPercent = 0;
                damageOverTime = 0;
                DOT_effectTimer = 0;
                slowEffectTimer = 0;

                if (GameManager.Instance.purchasedFireUpgrade)
                {
                    damageOverTime = damageOverTime * 2;
                }
                break;
            case GameManager.ShopItems.FIRE:
                GetComponent<SpriteRenderer>().sprite = thisSprite;
                damage = 2 * level;
                slowDownPercent = 0;
                damageOverTime = 1 * level;
                DOT_effectTimer = 600;
                slowEffectTimer = 0;

                if(GameManager.Instance.purchasedFireUpgrade)
                {
                    damageOverTime = damageOverTime * 2;
                }
                break;
            case GameManager.ShopItems.ICE:
                GetComponent<SpriteRenderer>().sprite = thisSprite;
                damage = 6 * level;
                slowDownPercent = .1f * (float)level;
                damageOverTime = 0;
                DOT_effectTimer = 0;
                slowEffectTimer = 300;

                if (GameManager.Instance.purchasedIceUpgrade)
                {
                    slowDownPercent = slowDownPercent * 2;
                }
                break;
            case GameManager.ShopItems.VOID:
                GetComponent<SpriteRenderer>().sprite = thisSprite;
                damage = 5;
                slowDownPercent = 0;
                damageOverTime = 0;
                DOT_effectTimer = 0;
                slowEffectTimer = 0;

                if (GameManager.Instance.purchasedVoidUpgrade)
                {
                    damage = damage * 2;
                }
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = thisSprite;
                damage = 2 * level;
                slowDownPercent = 0;
                damageOverTime = 0;
                DOT_effectTimer = 0;
                slowEffectTimer = 0;

                if (GameManager.Instance.purchasedFireUpgrade)
                {
                    damageOverTime = damageOverTime * 2;
                }
                break;
        }
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (!GameManager.Instance.pauseGame)
        {
            if (target == null)
            {
                Destroy(this.gameObject);
            }
            else if (move)
            {
                this.gameObject.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
            }
        }
	}

    #endregion
}
