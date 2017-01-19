using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public enum PlayerHoldState
    {
        Free,
        HoldingBall,
        HoldingDoor
    }

    public PlayerHoldState hold { get; set; }

    GameObject djoint;
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
    private bool isDashingCooldown = false;
    private bool isSmashing = false;
    private bool isDead = false;
    public float dashCooldown = 2.0f;
    public float smashCooldown = 10.0f;
    private GameObject kickTrigger;
    Collider ball;
    [SerializeField]
    Camera cam;
    [SerializeField]
    ParticleSystem bloodParticle, dashParticle;
    private Material playerMaterial;

    //Effects
    private int invertMovement = 1;
    private bool isInviolability = false;
    public bool isBallReleased { get; private set; }
    public bool isDoorHolding { get; private set; }


    // Input
    private float horizontal;
    private float vertical;
    // Chain
    public GameObject joint;
    private GameObject jointCopy;

    public GameObject playersBall;
    public GameObject playersChain;

    void Start()
    {
        cam = Camera.main;
        hold = PlayerHoldState.HoldingBall;
        rb = GetComponent<Rigidbody>();
        kickTrigger = transform.FindChild("CubePivot").gameObject;
        isDoorHolding = false;

        if (kickTrigger.GetComponent<KickTriggerController>().GetCollider() != null)
            //if(kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag == "Ball")
            ball = kickTrigger.GetComponent<KickTriggerController>().GetCollider();

        StartCoroutine(Dash());
        StartCoroutine(Skills());
        StartCoroutine(ReleaseButton());
        playerMaterial = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {

        ball = kickTrigger.GetComponent<KickTriggerController>().GetCollider();

        FireButton();
        playerMovement(invertMovement);
        Jump();


        if (Input.GetButton(InputManager.gameInput.getPlayerInput(playerNumber).Reset.ToString()))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    void playerMovement(int invert)
    {
        horizontal = (invert) * Input.GetAxis(InputManager.gameInput.getPlayerInput(playerNumber).AxisHorizontal1.AxisName);
        vertical = (invert) * Input.GetAxis(InputManager.gameInput.getPlayerInput(playerNumber).AxisVertical1.AxisName);
        if (!isDashing && !isJumping)
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
        if (Input.GetButton(InputManager.gameInput.getPlayerInput(playerNumber).Jump.ToString()) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    IEnumerator Dash()
    {

        while (true)
        {
            if (Input.GetButton(InputManager.gameInput.getPlayerInput(playerNumber).Dash.ToString()))
            {
                dashParticle.Play();
                isDashing = true;
                isDashingCooldown = true;
                rb.velocity = Vector3.zero;
                rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * dashForce, ForceMode.Impulse);
                yield return new WaitForSeconds(dashCooldown / 16);
                isDashing = false;
                dashParticle.Stop();
                yield return new WaitForSeconds(dashCooldown * 15 / 16);
                isDashingCooldown = false;
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
                if (Input.GetButton(InputManager.gameInput.getPlayerInput(playerNumber).Skill.ToString()))
                {
                    if (playersBall.tag == "Ball")
                    {
                        isSmashing = true;
                        
                        playersBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        playersBall.GetComponent<Rigidbody>().AddForce((transform.up + transform.forward).normalized * smashForce);
                        rb.AddForce((-transform.up + -transform.forward) * smashForce);
                        yield return new WaitForSeconds(0.1f);
                        playersBall.GetComponent<BallMoveController>().State = BallMoveController.BallState.Smashed;
                    }
                    yield return new WaitForSeconds(smashCooldown);
                    isSmashing = false;
                }
            }
            yield return null;
        }
    }

    void FireButton()
    {
        if (Input.GetButton(InputManager.gameInput.getPlayerInput(playerNumber).Kick.ToString()))
        {
            if (ball != null)
            {
                if(ball.tag == "Ball")
                    playersBall.GetComponent<BallMoveController>().KickBall();
            }
        }
        else
        {
            kickTrigger.transform.rotation = Quaternion.identity;
        }
    }

    IEnumerator ReleaseButton()
    {
        while (true)
        {
            if (Input.GetButton(InputManager.gameInput.getPlayerInput(playerNumber).Release.ToString()))
            {
                if (!isBallReleased)
                {
                    jointCopy = joint;

                    isBallReleased = true;
                    Destroy(joint.GetComponent<ConfigurableJoint>());
                    playersChain.transform.parent = transform.parent;
                    hold = PlayerHoldState.Free;
                }
                else if(isDoorHolding)
                {
                    //isDoorHolding = false;
                    //Destroy(joint.GetComponent<ConfigurableJoint>());
                    ////playersChain.transform.parent = transform.parent;
                    //hold = PlayerHoldState.Free;
                }
                else if (kickTrigger.GetComponent<KickTriggerController>().GetCollider() != null)
                {
                    Debug.Log(kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag.ToString());
                    if(kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag == "Ball" || kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag == "Chain Holder")
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
                        joint.GetComponent<ConfigurableJoint>().projectionDistance = 0.01f;
                        joint.GetComponent<ConfigurableJoint>().projectionAngle = 180;
                        joint.GetComponent<ConfigurableJoint>().projectionMode = JointProjectionMode.PositionAndRotation;
                        playersChain.transform.parent = transform;
                        hold = PlayerHoldState.HoldingBall;
                    }
                    if (kickTrigger.GetComponent<KickTriggerController>().GetCollider().tag == "Chain Holder" && isBallReleased == true && isDoorHolding == false)
                    {
                        //Debug.Log("sdaffsdafdssa");
                        //djoint = kickTrigger.GetComponent<KickTriggerController>().GetCollider().gameObject;
                        //isDoorHolding = false;
                        //djoint.AddComponent<ConfigurableJoint>();
                        //djoint.transform.position = rb.position;
                        //djoint.GetComponent<ConfigurableJoint>().connectedBody = rb;
                        //djoint.GetComponent<ConfigurableJoint>().connectedAnchor = rb.position;
                        //djoint.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
                        //djoint.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
                        //djoint.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
                        //djoint.GetComponent<ConfigurableJoint>().angularXMotion = ConfigurableJointMotion.Free;
                        //djoint.GetComponent<ConfigurableJoint>().angularYMotion = ConfigurableJointMotion.Locked;
                        //djoint.GetComponent<ConfigurableJoint>().angularZMotion = ConfigurableJointMotion.Free;
                        //djoint.GetComponent<ConfigurableJoint>().projectionDistance = 0.01f;
                        //djoint.GetComponent<ConfigurableJoint>().projectionAngle = 180;
                        //djoint.GetComponent<ConfigurableJoint>().projectionMode = JointProjectionMode.PositionAndRotation;
                        //djoint.GetComponent<ConfigurableJoint>().breakForce = 600;
                        //playersChain.transform.parent = transform;
                        //hold = PlayerHoldState.HoldingDoor;
                    }

                }
                yield return new WaitForSeconds(0.2f);
            }
            yield return null;
        }
    }

    public void GotHit(int dmg)
    {
        if (isInviolability == false)
        {
            //Blood particle
            //bloodParticle.Clear();
            //bloodParticle.time = 0;
            //bloodParticle.Play();

            playerHealth -= dmg;
        }

        if (playerHealth <= 0)
            isDead = true;
            //Destroy(transform.parent.gameObject);

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

    public int getInvert()
    {
        return invertMovement;
    }

    public void SetInviolability(bool value)
    {
        isInviolability = value;
    }

    public bool IsInviolability()
    {
        return isInviolability;
    }

    // Collider functions
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
            isJumping = false;
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public bool IsSmashing()
    {
        return isSmashing;
    }

    public bool IsDashingCooldown()
    {
        return isDashingCooldown;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
