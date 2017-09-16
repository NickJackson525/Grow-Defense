using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    #region Variables

    public float speed = 1f;
    public GameObject[] fullPath;
    public int pathCount = 0;
    public int health = 90;
    public int moneyGivenOnDeath = 5;
    bool hasRotated = false;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {

    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if (pathCount <= fullPath.Length)
        {
            if (Vector2.Distance(this.gameObject.transform.position, fullPath[pathCount].gameObject.transform.position) < .07f)
            {
                pathCount++;
                hasRotated = false;
            }

            switch (pathCount)
            {
                case 0:
                    this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
                    break;
                case 1:
                    this.gameObject.transform.position += Vector3.right * speed * Time.deltaTime;

                    if (!hasRotated)
                    {
                        this.gameObject.transform.Rotate(Vector3.forward * 90);
                        hasRotated = true;
                    }
                    break;
                case 2:
                    this.gameObject.transform.position += Vector3.up * speed * Time.deltaTime;

                    if (!hasRotated)
                    {
                        this.gameObject.transform.Rotate(Vector3.forward * 90);
                        hasRotated = true;
                    }
                    break;
                case 3:
                    this.gameObject.transform.position += Vector3.right * speed * Time.deltaTime;

                    if (!hasRotated)
                    {
                        this.gameObject.transform.Rotate(Vector3.forward * 270);
                        hasRotated = true;
                    }
                    break;
                case 4:
                    this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;

                    if (!hasRotated)
                    {
                        this.gameObject.transform.Rotate(Vector3.forward * -90);
                        hasRotated = true;
                    }
                    break;
                case 5:
                    this.gameObject.transform.position += Vector3.left * speed * Time.deltaTime;

                    if (!hasRotated)
                    {
                        this.gameObject.transform.Rotate(Vector3.forward * -90);
                        hasRotated = true;
                    }
                    break;
                case 6:
                    this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;

                    if (!hasRotated)
                    {
                        this.gameObject.transform.Rotate(Vector3.forward * 90);
                        hasRotated = true;
                    }
                    break;
                default:
                    break;
            }
        }

        if(health <= 0)
        {
            Game_Manager.Instance.money += moneyGivenOnDeath;
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region Collision Methods

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            coll.gameObject.GetComponent<Water_Controller>().health -= 10;
            coll.gameObject.GetComponent<Water_Controller>().updateSprite();
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Bullet")
        {
            health -= coll.gameObject.GetComponent<Bullet>().damage;
            Destroy(coll.gameObject);
        }
    }

    #endregion
}
