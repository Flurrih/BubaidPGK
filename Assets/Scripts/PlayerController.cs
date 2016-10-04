using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 20;
    public float kickForce = 50;

    private float horizontal;
    private float vertical;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate ()
    {
        GameObject leg = transform.FindChild("CubePivot").gameObject;
        if (Input.GetButton("Fire1"))
        {
            Collider ball = leg.GetComponent<KickTriggerController>().GetCollider();
            if (ball != null)
            {
                ball.GetComponent<Rigidbody>().AddForce(transform.forward * kickForce);
            }
        }
        else
        {
            leg.transform.rotation = Quaternion.identity;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontal * speed, 0, vertical * speed);
        if (rb.velocity != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(rb.velocity);
            transform.FindChild("Ball").rotation = Quaternion.Inverse(rb.rotation);
        }
        //rb.AddForce(horizontal*speed,0, vertical*speed);
	}
}
