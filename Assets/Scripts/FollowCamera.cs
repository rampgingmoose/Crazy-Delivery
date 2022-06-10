using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject playerCar;
    [SerializeField] float zOffset = -10f;
    private void LateUpdate()
    {
        transform.position = playerCar.transform.position + new Vector3(0,0,zOffset);
    }
}
