using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    #region Variables

    public GameObject water;
    public float speed = 5f;
    public float startScale;
    public Vector3 updatePosition;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        startScale = water.transform.localScale.y;
        transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
	}

    #endregion

    #region Fixed Update

    // Update is called once per frame
    void FixedUpdate ()
    {
        water.GetComponent<Image>().fillAmount = GameManager.Instance.waterLevel / 100f;
    }

    #endregion
}
