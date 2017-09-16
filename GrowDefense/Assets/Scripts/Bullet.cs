using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables

    public bool move = false;
    public GameObject target;
    public int damage = 10;
    public float speed = .2f;

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
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else if (move)
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
        }
	}

    #endregion
}
