﻿using UnityEngine;
using System.Collections;

public class BallMoveController : MonoBehaviour {

    public float moveRadius = 2.5f;
    public float moveSpeed = 5;

    private float horizontal2;
    private float vertical2;
    private LineRenderer line;

    public GameObject player;

    void Start()
    {
        line = transform.GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        horizontal2 = Input.GetAxis("Horizontal 2nd");
        vertical2 = Input.GetAxis("Vertical 2nd");

        Vector3 movePoint;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, player.transform.position);

        if((player.transform.position - transform.position).magnitude > moveRadius)
        {
            movePoint = player.transform.position + transform.position.normalized * moveRadius;
            transform.position = Vector3.Lerp(transform.position, movePoint, Time.fixedDeltaTime * 2);
            Debug.Log(movePoint);
        }
        else
        {
            movePoint = new Vector3(transform.position.x + horizontal2 * moveSpeed, transform.position.y, transform.position.z + vertical2 * moveSpeed);
            transform.position = Vector3.Lerp(transform.position, movePoint, Time.fixedDeltaTime);
        }
        
    }
}
