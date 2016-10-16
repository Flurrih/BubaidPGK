using UnityEngine;
using System.Collections;

public class BallTriggerController : MonoBehaviour {
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
            other.GetComponent<PlayerController>().GotHit();
        }
    }
}
