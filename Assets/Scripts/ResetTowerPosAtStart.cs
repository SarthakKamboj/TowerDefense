using UnityEngine;

public class ResetTowerPosAtStart : MonoBehaviour
{

    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] new Collider collider;

    RaycastHit groundHit;

    void Start()
    {
        Ray ray = new Ray();
        ray.direction = Vector3.down;
        ray.origin = transform.position;
        // float towerYExtent = transform.Find("GFX").GetComponent<Renderer>().bounds.extents.y;
        float towerYExtent = collider.bounds.extents.y;
        // float towerYExtent = 0;
        if (Physics.Raycast(ray, out groundHit, Mathf.Infinity, groundLayerMask))
        {
            // Debug.Log("ground Hit point: " + groundHit.point);
            // Vector3 prevPos = transform.position;
            transform.position = groundHit.point + Vector3.up * towerYExtent;
            // Debug.Log("prev pos: " + prevPos + " newPos: " + transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        // if (groundHit.point != null)
        // {
        // Gizmos.DrawWireSphere(groundHit.point, 0.2f);
        // }
        Gizmos.DrawWireSphere(Vector3.zero, 0.2f);

        // Gizmos.DrawLine(collider.bounds.center, collider.bounds.center - Vector3.up * collider.bounds.extents.y);
    }

}
