using UnityEngine;

public class MouseSelector : MonoBehaviour
{

    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] LayerMask towerLayerMask;

    bool moveEnabled = false;

    Transform selectedTower;
    float selectedTowerYExtent;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit selectedOut;
        if (!moveEnabled && Input.GetMouseButton(0) && Physics.Raycast(ray, out selectedOut, Mathf.Infinity, towerLayerMask))
        {
            selectedTower = selectedOut.collider.transform;
            // selectedTowerYExtent = selectedTower.Find("GFX").GetComponent<Renderer>().bounds.extents.y;
            Collider towerCollider = selectedTower.GetComponent<Collider>();
            selectedTowerYExtent = towerCollider.bounds.extents.y;
            // selectedTowerYExtent = 0f;
            moveEnabled = true;
        }

        if (!Input.GetMouseButton(0))
        {
            moveEnabled = false;
        }

        RaycastHit groundHit;
        if (moveEnabled && Physics.Raycast(ray, out groundHit, Mathf.Infinity, groundLayerMask))
        {
            selectedTower.position = groundHit.point + Vector3.up * selectedTowerYExtent;
        }
    }
}
