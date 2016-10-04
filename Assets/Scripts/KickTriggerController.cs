using UnityEngine;
using System.Collections;

public class KickTriggerController : MonoBehaviour {

    Collider collider;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            collider = other;
        }
    }

    void OnTriggerExit(Collider other)
    {
        collider = null;
    }

    public Collider GetCollider()
    {
        return collider;
    }
}
