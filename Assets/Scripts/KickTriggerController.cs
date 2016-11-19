using UnityEngine;
using System.Collections;

public class KickTriggerController : MonoBehaviour {

    Collider col;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            col = other;
        }
        
        if(other.tag == "Chain Holder")
        {
            col = other;
        }

    }

    void OnTriggerExit(Collider other)
    {
        col = null;
    }

    public Collider GetCollider()
    {
        return col;
    }
}
