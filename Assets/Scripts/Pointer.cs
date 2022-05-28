using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        SetAimPosition();
        FollowAim();
    }

    private void SetAimPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        plane.Raycast(ray, out float distance);

        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;
    }

    private void FollowAim()
    {
        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
