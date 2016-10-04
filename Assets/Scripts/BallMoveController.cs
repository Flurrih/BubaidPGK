using UnityEngine;
using System.Collections;

public class BallMoveController : MonoBehaviour {

    public float moveRadius = 2.5f;
    public float moveSpeed = 5;

    private float horizontal2;
    private float vertical2;

    void Update()
    {
        horizontal2 = Input.GetAxis("Horizontal 2nd");
        vertical2 = Input.GetAxis("Vertical 2nd");
        Vector3 movePoint = new Vector3(transform.localPosition.x + horizontal2 * moveSpeed, transform.localPosition.y, transform.localPosition.z + vertical2 * moveSpeed);
        transform.localPosition = Vector3.ClampMagnitude(Vector3.Lerp(transform.localPosition, movePoint, Time.deltaTime), moveRadius); 
    }
}
