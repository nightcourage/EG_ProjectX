using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;

    public Transform RopeStart;
    public RopeState CurrentRopeState;

    private SpringJoint SpringJoint;
    private float _ropeLength;

    public RopeRenderer RopeRenderer;

    private void Shot()
    {
        _ropeLength = 1f;
        
        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }
        
        Hook.gameObject.SetActive(true);
        
        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _ropeLength = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _ropeLength;

            CurrentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }

        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 20f)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroySpring();
        }

        if (CurrentRopeState == RopeState.Active || CurrentRopeState == RopeState.Fly)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _ropeLength);
        }
    }
}
