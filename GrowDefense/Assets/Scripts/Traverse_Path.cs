using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traverse_Path : MonoBehaviour
{
    GameObject currentNode;
    GameObject[] fullPath;
    int pathCount = 0;

    // Use this for initialization
    void Start ()
    {
        fullPath = GameObject.FindGameObjectsWithTag("Path");
        currentNode = fullPath[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(pathCount + 1 < fullPath.Length)
        {
            currentNode = fullPath[pathCount];
        }

        transform.position = Vector3.MoveTowards(this.gameObject.transform.position, currentNode.transform.position, 1f * Time.deltaTime);
	}

    public GameObject FindClosestNode()
    {
        GameObject[] fullPath;
        fullPath = GameObject.FindGameObjectsWithTag("Path");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject path in fullPath)
        {
            Vector3 diff = path.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = path;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Path")
        {
            pathCount++;
        }
    }
}
