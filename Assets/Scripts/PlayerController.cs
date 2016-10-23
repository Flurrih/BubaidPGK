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
    private float bonusTimeLeft = 10;
    private bool isBonus = false;

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
        SpeedBonus();
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bonus Box"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Bonus"))
        {
            other.gameObject.SetActive(false);
            isBonus = true;
            // Destroy(other.transform.parent.gameObject);
        }
        else if (other.gameObject.CompareTag("Debuff"))
        {
            playerHealth -= 25;
            other.gameObject.SetActive(false);
        }
    }

    void SpeedBonus()
    {
        if (isBonus)
        {
            if (bonusTimeLeft > 0)
            {
                speed = 20;
                bonusTimeLeft -= Time.deltaTime;
                Debug.Log(bonusTimeLeft);
            }
            else
            {
                speed = 10;
                bonusTimeLeft = 10;
                isBonus = false;
                return;
            }
        }
    }
}
