using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public int playerNumber = 0;
    public float speed = 20;
    public float kickForce = 50;

    private float horizontal;
    private float vertical;
    private Rigidbody rb;

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
        playerMovement();
	}

    void playerMovement()
    {
        horizontal = Input.GetAxis(playerNumber + "Horizontal");
        vertical = Input.GetAxis(playerNumber + "Vertical");
        rb.velocity = new Vector3(horizontal * speed, 0, vertical * speed);
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
                ball.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up / 4).normalized * kickForce);
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
    }

    public void GotHit()
    {
        //Blood particle
        GetComponentInChildren<ParticleSystem>().Clear();
        GetComponentInChildren<ParticleSystem>().time = 0;
        GetComponentInChildren<ParticleSystem>().Play();

        playerHealth -= 25;
        if (playerHealth <= 0)
            Destroy(transform.parent.gameObject);

    }

    public int GetHealth()
    {
        return playerHealth;
    }
}
