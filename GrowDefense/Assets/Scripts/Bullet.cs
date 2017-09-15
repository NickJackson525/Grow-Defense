using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool move = false;
    public GameObject target;
    GameObject testEnemyExist;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        testEnemyExist = GameObject.FindGameObjectWithTag("Enemy");

        if ((testEnemyExist == null) || (target == null))
        {
            Destroy(this.gameObject);
        }

        if (move || (target != null))
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, target.transform.position, .2f);
        }
	}
}
