using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public GameObject water;

    // Update is called once per frame
    void Update ()
    {
        water.GetComponent<Image>().fillAmount = GameManager.Instance.waterLevel / 100f;
    }
}
