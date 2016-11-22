using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public enum PlayerHoldState
    {
        Free,
        HoldingBall
    }

    public PlayerHoldState hold { get; set; }

    // General
    private Rigidbody rb;
    public int playerNumber = 0;
    public float speed = 20;
    public float kickForce = 5000;
    public float jumpForce = 250;
    public float dashForce = 250;
    public float smashForce = 500;
    private int playerHealth = 100;
    private bool isJumping = true;
    private bool isDashing = false;
    public float dashCooldown = 2.0f;
    public float smashCooldown = 10.0f;
    private GameObject kickTrigger;
    Collider ball;
    [SerializeField]
    Camera cam;
    private Material playerMaterial;

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
        hold = PlayerHoldState.HoldingBall;
        rb = GetComponent<Rigidbody>();
        kickTrigger = transform.FindChild("CubePivot").gameObject;

        if (kickTrigger.GetComponent<KickTriggerController>().GetCollider() != null)
            // if(kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag == "Ball")
            ball = kickTrigger.GetComponent<KickTriggerController>().GetCollider();

        StartCoroutine(Dash());
        StartCoroutine(Skills());
        playerMaterial = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {

        ball = kickTrigger.GetComponent<KickTriggerController>().GetCollider();

        FireButton();
        ReleaseButton();
        playerMovement(invertMovement);
        Jump();


        if (Input.GetAxis("Reset") > 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            Application.LoadLevel("arena_design_v2");
        }
    }

    void playerMovement(int invert)
    {
        horizontal = (invert) * Input.GetAxis(playerNumber + "Horizontal");
        vertical = (invert) * Input.GetAxis(playerNumber + "Vertical");
        if (!isJumping & !isDashing)
        {
            rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
            Transform temp = cam.transform;
            temp.rotation = Quaternion.Euler( new Vector3(0,temp.rotation.eulerAngles.y, 0));
            Vector3 moveDirection = temp.TransformDirection(rb.velocity);
            rb.velocity = moveDirection;
        }

        if (rb.velocity != new Vector3(0, rb.velocity.y, 0))
        {
            rb.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z));
            //transform.FindChild("Ball").rotation = Quaternion.Inverse(rb.rotation);
        }
        //rb.AddForce(horizontal*speed,0, vertical*speed);
    }

    void Jump()
    {
        if (Input.GetButton(playerNumber + "Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    IEnumerator Dash()
    {

        while (true)
        {
            if (Input.GetButton(playerNumber + "Dash"))
            {
                isDashing = true;
                rb.velocity = Vector3.zero;
                rb.AddForce(new Vector3(rb.transform.forward.x, 0, rb.transform.forward.z) * dashForce, ForceMode.Impulse);
                yield return new WaitForSeconds(dashCooldown / 4);
                isDashing = false;
                yield return new WaitForSeconds(dashCooldown * 3 / 4);
            }
            
            yield return null;
        }
    }

    IEnumerator Skills()
    {
        while (true)
        {
            if (hold != PlayerHoldState.Free)
            {
                if (Input.GetButton(playerNumber + "Skill"))
                {
                    if (playersBall.tag == "Ball")
                    {
                       
                        playersBall.GetComponent<BallMoveController>().State = BallMoveController.BallState.Smashed;
                        playersBall.GetComponent<Rigidbody>().AddForce(Vector3.up * smashForce);
                        rb.AddForce(-Vector3.up * smashForce);
                    }
                    yield return new WaitForSeconds(smashCooldown);
                }
            }

            yield return null;
        }
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
        if (Input.GetButtonUp(playerNumber + "Release"))
        {
            if (!isBallReleased)
            {
                jointCopy = joint;

                isBallReleased = true;
                Destroy(joint.GetComponent<ConfigurableJoint>());
                hold = PlayerHoldState.Free;
            }
            else if (kickTrigger.GetComponent<KickTriggerController>().GetCollider() != null)
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
                hold = PlayerHoldState.HoldingBall;
            }
        }
    }

    public void GotHit(int dmg)
    {
        if (isInviolability == false)
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

        if (playerHealth > 100)
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

    public Material GetPlayerMaterial()
    {
        return playerMaterial;
    }

    public void SetMovement(int value)
    {
        invertMovement = value;
    }

    public void SetInviolability(bool value)
    {
        isInviolability = value;
    }

    // Collider functions
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        if (collisionInfo.collider.tag == "Untagged")
            isJumping = false;
    }

}
