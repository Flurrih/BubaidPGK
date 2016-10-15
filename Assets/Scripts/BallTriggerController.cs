using UnityEngine;
using System.Collections;

public class BallTriggerController : MonoBehaviour {
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().GetHit();
        }
    }
}
