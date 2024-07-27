using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] float cameraMoveSpeed = 5f;

    void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * cameraMoveSpeed);
        transform.position = smoothedPosition;
    }
}
