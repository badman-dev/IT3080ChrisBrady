using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSphere : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    bool isFollowing = false;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + offset, 0.05f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 0.05f);
        }
    }

    public void StartFollow()
    {
        isFollowing = true;
    }

    public void StopFollow()
    {
        isFollowing = false;
    }
}
