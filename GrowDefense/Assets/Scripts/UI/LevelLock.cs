using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public Sprite unlocked;
    public int lockNumber = 0;
    public bool isLock = false;

	// Update is called once per frame
	void Update ()
    {
        if (isLock)
        {
            switch (lockNumber)
            {
                case 2:
                    if (!GameManager.Instance.level2Locked)
                    {
                        GetComponent<Image>().sprite = unlocked;
                    }
                    break;
                case 3:
                    if (!GameManager.Instance.level3Locked)
                    {
                        GetComponent<Image>().sprite = unlocked;
                    }
                    break;
                case 4:
                    if (!GameManager.Instance.level4Locked)
                    {
                        GetComponent<Image>().sprite = unlocked;
                    }
                    break;
                case 5:
                    if (!GameManager.Instance.level5Locked)
                    {
                        GetComponent<Image>().sprite = unlocked;
                    }
                    break;
                case 6:
                    if (!GameManager.Instance.level6Locked)
                    {
                        GetComponent<Image>().sprite = unlocked;
                    }
                    break;
            }
        }
        else
        {
            switch (lockNumber)
            {
                case 2:
                    if (!GameManager.Instance.level2Locked)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case 3:
                    if (!GameManager.Instance.level3Locked)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    if (!GameManager.Instance.level4Locked)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case 5:
                    if (!GameManager.Instance.level5Locked)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case 6:
                    if (!GameManager.Instance.level6Locked)
                    {
                        gameObject.SetActive(false);
                    }
                    break;
            }
        }
	}
}
