using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    Transform[] childs;
    GameObject randomObject;
    // Start is called before the first frame update
    void Start()
    {

        childs = getFirstChildren(gameObject.transform);
        InvokeRepeating("TileFalls", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TileFalls()
    {
        randomObject = (childs[Random.Range(0, childs.Length)]).gameObject;
        randomObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private Transform[] getFirstChildren(Transform parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Transform[] firstChildren = new Transform[parent.childCount];
        int index = 0;
        foreach (Transform child in children)
        {
            if (child.parent == parent)
            {
                firstChildren[index] = child;
                index++;
            }
        }
        return firstChildren;
    }
}
