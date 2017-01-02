using UnityEngine;
using System.Collections;

public class BallMoveController : MonoBehaviour {

    public enum BallState
    {
        Normal,
        PreSmash,
        Smashed,
        Grounded
    }

    public BallState State { get; set; }

    public float pullSpeed;

    public float holdRadius = 1.0f;
    public float moveRadius = 2.5f;
    public float moveSpeed = 5;

    //input
    private float horizontal2;
    private float vertical2;
    
    private Rigidbody rb;

    private int invertMovement = 1;

    public GameObject player;

    public int playerNumber = 0;
    public Collider skillCollider;

    private bool released = false;

    Vector3 targetPos;

    Vector3 tempSize;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = rb.transform.position;
        tempSize = GetComponent<BoxCollider>().size;
    }

    void FixedUpdate()
    {
        released = player.GetComponent<PlayerController>().isBallReleased;
        horizontal2 = invertMovement*Input.GetAxis(InputManager.gameInput.getPlayerInput(playerNumber).AxisHorizontal2.AxisName);
        vertical2 = invertMovement*Input.GetAxis(InputManager.gameInput.getPlayerInput(playerNumber).AxisVertical2.AxisName);

        if (State == BallState.Smashed)
        {
            GetComponent<BoxCollider>().size = new Vector3(tempSize.x * 3, tempSize.y, tempSize.z * 3);
        }

        if(State == BallState.Grounded)
        {
            GetComponent<BoxCollider>().size = new Vector3(tempSize.x, tempSize.y, tempSize.z);
        }

        //Vector3 movePoint;


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
        //if(horizontal2 != 0|| vertical2 != 0)
        //{
        //    targetPos.x += horizontal2 * moveSpeed;
        //    targetPos.z += vertical2 * moveSpeed;
        //}


        //targetPos = Vector3.ClampMagnitude(targetPos - player.transform.position, moveRadius) + player.transform.position;

        //rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, moveSpeed));
        if (State == BallState.Normal)
        {
            if (!released)
                rb.AddForce(new Vector3(horizontal2 * moveSpeed, 0, vertical2 * moveSpeed), ForceMode.VelocityChange);
        }

        if(State == BallState.PreSmash)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(-8,0,0), Time.deltaTime * 25);
            if(skillCollider.bounds.Contains(transform.position))
            {
                State = BallState.Smashed;
            }
        }
    }


    public void HoldBall()
    {
        /*
        Debug.Log((player.transform.position - transform.position).magnitude);
        if ((player.transform.position - transform.position).magnitude < holdRadius)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z + 1.0f);
            */
    }

    public void KickBall()
    {
    //targetPos = player.transform.forward * player.GetComponent<PlayerController>().kickForce;
    //targetPos = new Vector3(player.transform.forward.x * player.GetComponent<PlayerController>().kickForce, transform.position.y, player.transform.forward.y * player.GetComponent<PlayerController>().kickForce);
    //rb.velocity = targetPos;
    rb.AddForce((player.transform.forward + Vector3.up * 0.1f) * player.GetComponent<PlayerController>().kickForce);
        //rb.AddForce(player.transform.forward * player.GetComponent<PlayerController>().kickForce * Time.deltaTime);
        //Vector3 kickEndPosition = player.transform.position + player.transform.forward * player.GetComponent<PlayerController>().kickForce;
        //rb.MovePosition(
        //    Vector3.MoveTowards(
        //        rb.transform.position, 
        //        kickEndPosition ,
        //        5.0f
        //        ));
        //targetPos = transform.position;
    }

    public void SetMovement(int value)
    {
        invertMovement = value;
    }


}
