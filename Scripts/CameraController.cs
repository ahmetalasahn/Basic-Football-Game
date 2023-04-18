using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform pTransform;
    public Vector3 offset;
    void Update()
    {
        this.transform.position = pTransform.position + offset;
    }
}
