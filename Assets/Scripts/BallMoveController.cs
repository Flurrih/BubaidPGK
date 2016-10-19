using UnityEngine;
using System.Collections;

public class BallMoveController : MonoBehaviour {

    public float pullSpeed;

    public float holdRadius = 1.0f;
    public float moveRadius = 2.5f;
    public float moveSpeed = 5;

    private float horizontal2;
    private float vertical2;
    private LineRenderer line;
    private Rigidbody rb;

    public GameObject player;

    public int playerNumber = 0;

    Vector3 targetPos;

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

        //if((player.transform.position - transform.position).magnitude > moveRadius)
        //{
        //    movePoint = Vector3.ClampMagnitude((player.transform.position - transform.position), moveRadius);
        //    //rb.transform.position = Vector3.Lerp(transform.position, movePoint, Time.fixedDeltaTime * 3);
        //    rb.MovePosition(player.transform.position -  movePoint);
        //    //Debug.Log(movePoint);
        //}
        //else
        //{
        //    movePoint = new Vector3(transform.position.x + horizontal2 * moveSpeed, transform.position.y, transform.position.z + vertical2 * moveSpeed);
        //    //rb.transform.position = Vector3.Lerp(transform.position, movePoint, Time.fixedDeltaTime);
        //    rb.MovePosition(movePoint);
        //}


        targetPos.x += horizontal2 * moveSpeed;
        targetPos.z += vertical2 * moveSpeed;

        targetPos = Vector3.ClampMagnitude(targetPos - player.transform.position, moveRadius) + player.transform.position;

        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, moveSpeed));
    }

    public void PullBallToPlayer()
    {
        //if ((player.transform.position - transform.position).magnitude < holdRadius)
        //{
        //    StickToPlayer();
        //}
        //else
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, pullSpeed * Time.deltaTime);
    }

    public void HoldBall()
    {
        Debug.Log((player.transform.position - transform.position).magnitude);
        if ((player.transform.position - transform.position).magnitude < holdRadius)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z + 1.0f);
    }
}
