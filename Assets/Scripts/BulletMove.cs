using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField] float force = 15f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

}
