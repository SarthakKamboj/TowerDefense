using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPathEnd : MonoBehaviour
{

    void Start()
    {
        Transform pathNodesParent = GameObject.Find("Path Nodes").transform;
        Transform prev = transform;
        foreach (Transform path in pathNodesParent)
        {
            prev = path;
        }
        transform.position = prev.position;
    }

}
