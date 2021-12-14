using UnityEngine;

public class ResetTowerPosAtStart : MonoBehaviour
{

    [SerializeField] LayerMask groundLayerMask;

    void Start()
    {
        RaycastHit groundHit;
        Ray ray = new Ray();
        ray.direction = Vector3.down;
        ray.origin = transform.position;
        float towerYExtent = transform.Find("GFX").GetComponent<Renderer>().bounds.extents.y;
        if (Physics.Raycast(ray, out groundHit, Mathf.Infinity, groundLayerMask))
        {
            transform.position = groundHit.point + Vector3.up * towerYExtent;
        }
    }

}
