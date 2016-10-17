using UnityEngine;
using System.Collections;

public class BallMoveController : MonoBehaviour {

    public float moveRadius = 2.5f;
    public float moveSpeed = 5;

    private float horizontal2;
    private float vertical2;
    private LineRenderer line;
    private Rigidbody rb;

    public GameObject player;

    public int playerNumber = 0;

    void Start()
    {
        line = transform.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontal2 = Input.GetAxis(playerNumber + "Horizontal 2nd");
        vertical2 = Input.GetAxis(playerNumber + "Vertical 2nd");

        Vector3 movePoint;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, player.transform.position);

        if((player.transform.position - transform.position).magnitude > moveRadius)
        {
            movePoint = Vector3.ClampMagnitude((player.transform.position - transform.position), moveRadius);
            //rb.transform.position = Vector3.Lerp(transform.position, movePoint, Time.fixedDeltaTime * 3);
            rb.MovePosition(player.transform.position -  movePoint);
            //Debug.Log(movePoint);
        }
        else
        {
            movePoint = new Vector3(transform.position.x + horizontal2 * moveSpeed, transform.position.y, transform.position.z + vertical2 * moveSpeed);
            //rb.transform.position = Vector3.Lerp(transform.position, movePoint, Time.fixedDeltaTime);
            rb.MovePosition(movePoint);
        }
        
    }
}
