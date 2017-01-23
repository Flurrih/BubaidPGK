using UnityEngine;
using System.Collections;

public class BallRespawn : MonoBehaviour {
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            col.gameObject.GetComponent<BallFallDown>().FellDown();
        }
    }
}
