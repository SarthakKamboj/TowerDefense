using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPathEnd : MonoBehaviour
{

    [SerializeField] new Collider collider;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Transform doorTransform;

    void Start()
    {
        Transform pathNodesParent = GameObject.Find("Path Nodes").transform;
        Transform prev = transform;
        Transform last = transform;
        foreach (Transform path in pathNodesParent)
        {
            prev = last;
            last = path;
        }
        RaycastHit groundHit;
        Ray ray = new Ray();
        ray.direction = Vector3.down;
        ray.origin = last.position;
        float yExtent = collider.bounds.extents.y;
        Vector3 transformOffset = RemoveY(doorTransform.position - transform.position);
        if (Physics.Raycast(ray, out groundHit, Mathf.Infinity, groundLayerMask))
        {
            transform.position = (groundHit.point + transformOffset) + Vector3.up * yExtent;
        }
    }

    Vector3 RemoveY(Vector3 vec)
    {
        return Vector3.Scale(vec, new Vector3(1f, 0f, 1f));
    }
}
