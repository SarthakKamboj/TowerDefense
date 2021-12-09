using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowPath : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 2f;

    [SerializeField] TMP_Text enemyPassedText;

    static int numReachedEnd = 0;

    List<Transform> pathNodes = new List<Transform>();
    int pathNodeIdx = 0;

    Vector3 dir;
    Quaternion destQuat;
    float timeSinceLastRot;

    void Start()
    {
        enemyPassedText = GameObject.Find("Enemies Reached").GetComponent<TMP_Text>();
        Transform pathNodesParent = GameObject.Find("Path Nodes").transform;

        foreach (Transform pathNode in pathNodesParent)
        {
            pathNodes.Add(pathNode);
        }

        if (pathNodes.Count > 0)
        {
            transform.position = RemoveYFromVec3(pathNodes[0].position) + new Vector3(0f, transform.position.y, 0f);
            SetDestination(pathNodes[0]);
        }

    }

    void Update()
    {

        if (pathNodeIdx >= pathNodes.Count) return;

        timeSinceLastRot += Time.deltaTime * rotationSpeed;
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, destQuat, timeSinceLastRot);

        if (Vector3.Distance(RemoveYFromVec3(pathNodes[pathNodeIdx].position), RemoveYFromVec3(transform.position)) < 0.1f)
        {
            pathNodeIdx += 1;
            if (pathNodeIdx < pathNodes.Count)
            {
                SetDestination(pathNodes[pathNodeIdx]);
            }
            else
            {
                ReachedEnd();
            }
        }
    }

    Vector3 RemoveYFromVec3(Vector3 vec)
    {
        return Vector3.Scale(vec, new Vector3(1f, 0f, 1f));
    }

    Vector3 CalcDir(Vector3 dest)
    {
        return RemoveYFromVec3((dest - transform.position).normalized);
    }

    void SetDestination(Transform dest)
    {
        dir = CalcDir(dest.position);
        destQuat = Quaternion.LookRotation(dest.position - transform.position, Vector3.up);
        Vector3 rot = destQuat.eulerAngles;
        rot.x = 0f;
        destQuat.eulerAngles = rot;
        timeSinceLastRot = 0f;
    }

    void ReachedEnd()
    {
        numReachedEnd += 1;
        enemyPassedText.text = "Enemies Reached: " + numReachedEnd;
        Destroy(gameObject);
    }
}
