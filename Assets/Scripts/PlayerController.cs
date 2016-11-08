using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public int playerNumber = 0;
    public float speed = 20;
    public float kickForce = 50;
    public GameObject joint;
    private GameObject jointCopy;

    private int invertMovement = 1;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    private bool isInviolability = false;
    public bool isBallReleased { get; private set; }

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
        if(leg.GetComponent<KickTriggerController>().GetCollider() != null)
            if(leg.GetComponent<KickTriggerController>().GetCollider().tag == "Ball")
                ball = leg.GetComponent<KickTriggerController>().GetCollider();


    }

	void FixedUpdate ()
    {
        ball = leg.GetComponent<KickTriggerController>().GetCollider();
        FireButton();
        ReleaseButton();
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

    void ReleaseButton()
    {
        if(Input.GetButtonUp(playerNumber + "Release"))
        {
            if (!isBallReleased)
            {
                jointCopy = joint;

                isBallReleased = true;
                Destroy(joint.GetComponent<ConfigurableJoint>());
            }
            else if(leg.GetComponent<KickTriggerController>().GetCollider() != null)
            {
                isBallReleased = false;
                joint.AddComponent<ConfigurableJoint>();
                joint.transform.position = rb.position;
                joint.GetComponent<ConfigurableJoint>().connectedBody = rb;
                joint.GetComponent<ConfigurableJoint>().connectedAnchor = rb.position;
                joint.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
                joint.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
                joint.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
                joint.GetComponent<ConfigurableJoint>().angularXMotion = ConfigurableJointMotion.Free;
                joint.GetComponent<ConfigurableJoint>().angularYMotion = ConfigurableJointMotion.Locked;
                joint.GetComponent<ConfigurableJoint>().angularZMotion = ConfigurableJointMotion.Free;
                joint.GetComponent<ConfigurableJoint>().projectionDistance = 0.1f;
                joint.GetComponent<ConfigurableJoint>().projectionAngle = 180;
                joint.GetComponent<ConfigurableJoint>().projectionMode = JointProjectionMode.PositionAndRotation;
            }
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
