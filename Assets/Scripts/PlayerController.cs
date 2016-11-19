using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // General
    private Rigidbody rb;
    public int playerNumber = 0;
    public float speed = 20;
    public float kickForce = 50;
    private int playerHealth = 100;
    private GameObject kickTrigger;
    Collider ball;

    //Effects
    private int invertMovement = 1;
    private bool isInviolability = false;
    public bool isBallReleased { get; private set; }

    
    // Input
    private float horizontal;
    private float vertical;
    // Chain
    public GameObject joint;
    private GameObject jointCopy;

    public GameObject playersBall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        kickTrigger = transform.FindChild("CubePivot").gameObject;

        if(kickTrigger.GetComponent<KickTriggerController>().GetCollider() != null)
           // if(kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag == "Ball")
                ball = kickTrigger.GetComponent<KickTriggerController>().GetCollider();


    }

	void FixedUpdate ()
    {
        ball = kickTrigger.GetComponent<KickTriggerController>().GetCollider();
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
            kickTrigger.transform.rotation = Quaternion.identity;
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
            else if(kickTrigger.GetComponent<KickTriggerController>().GetCollider() != null)
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
