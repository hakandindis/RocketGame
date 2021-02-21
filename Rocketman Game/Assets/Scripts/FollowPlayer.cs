using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraoffset;

    [Range(0.01f, 1.0f)]
    public float Smoothfactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraoffset = transform.position - PlayerTransform.position;

    }

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraoffset;

        transform.position = Vector3.Slerp(transform.position, newPos, Smoothfactor);

    }
}
