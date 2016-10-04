using UnityEngine;
using System.Collections;

public class BallRotationController : MonoBehaviour {

    public float rotationSpeed = 2;

    private float horizontal2;
    private float vertical2;
	
	void Update () {
        horizontal2 = Input.GetAxis("Horizontal 2nd");
        vertical2 = Input.GetAxis("Vertical 2nd");
        Vector3 rotation = new Vector3(horizontal2, 0, vertical2);
        if (rotation != Vector3.zero)
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * rotationSpeed);
    }
}
