using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed = 1f;
    public GameObject[] fullPath;
    public int pathCount = 0;
    public int health = 100;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector3.Distance(this.gameObject.transform.position, fullPath[pathCount].gameObject.transform.position) < .08)
        {
            pathCount++;
        }

        switch(pathCount)
        {
            case 0:
                this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
                break;
            case 1:
                this.gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
                break;
            case 2:
                this.gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
                break;
            case 3:
                this.gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
                break;
            case 4:
                this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
                break;
            case 5:
                this.gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
                break;
            case 6:
                this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
                break;
            default:
                break;
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            coll.gameObject.GetComponent<Health>().health -= 10;
            coll.gameObject.GetComponent<Health>().updateSprite();
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Bullet")
        {
            health -= 10;
            Destroy(coll.gameObject);
        }
    }
}
