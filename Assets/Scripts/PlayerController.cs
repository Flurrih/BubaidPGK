using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public int playerNumber = 0;
    public float speed = 20;
    public float kickForce = 50;

    private int invertMovement = 1;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    private bool isInviolability = false;

    private int playerHealth = 100;
    private GameObject leg;
    //
    Collider ball;
    //
    

    public GameObject playersBall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leg = transform.FindChild("CubePivot").gameObject;
        ball = leg.GetComponent<KickTriggerController>().GetCollider();
    }

	void FixedUpdate ()
    {
        ball = leg.GetComponent<KickTriggerController>().GetCollider();
        FireButton();
        PullButton();
        playerMovement(invertMovement);
        
    }

    void playerMovement(int invert)
    {
        horizontal = (invert)*Input.GetAxis(playerNumber + "Horizontal");
        vertical = (invert)*Input.GetAxis(playerNumber + "Vertical");
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);

        if (rb.velocity != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(rb.velocity);
            //transform.FindChild("Ball").rotation = Quaternion.Inverse(rb.rotation);
        }
        //rb.AddForce(horizontal*speed,0, vertical*speed);
    }

    /*
     * Ball kick must be recoded.
     * It's player controller not ball's - u can't move ball here
     */
    void FireButton()
    {
        if (Input.GetButton(playerNumber + "Fire1"))
        {
            if (ball != null)
            {
                playersBall.GetComponent<BallMoveController>().KickBall();
            }
        }
        else
        {
            leg.transform.rotation = Quaternion.identity;
        }
    }

    void PullButton()
    {
        if(Input.GetButton(playerNumber + "Pull"))
        {
            playersBall.GetComponent<BallMoveController>().PullBallToPlayer();
        }

        if(Input.GetButton(playerNumber + "Hold"))
        {
            playersBall.GetComponent<BallMoveController>().HoldBall();
        }
    }

    public void GotHit(int dmg)
    {
        if(isInviolability == false)
        {
            //Blood particle
            GetComponentInChildren<ParticleSystem>().Clear();
            GetComponentInChildren<ParticleSystem>().time = 0;
            GetComponentInChildren<ParticleSystem>().Play();

            playerHealth -= dmg;
        } 

        if (playerHealth <= 0)
            Destroy(transform.parent.gameObject);

    }

    public int GetHealth()
    {
        return playerHealth;
    }

    public void SetHealth(int value)
    {
        playerHealth += value;
        if (playerHealth <= 0)
            Destroy(transform.parent.gameObject);

        if(playerHealth > 100)
        {
            playerHealth = 100;
        }
    }

    public void SetSpeed(int value)
    {
        speed = value;
    }

    public float GetSpeed()
    {
        return speed;
    }  

    public void SetMovement(int value)
    {
        invertMovement = value;
    }

    public void SetInviolability(bool value)
    {
        isInviolability = value;
    }
}
