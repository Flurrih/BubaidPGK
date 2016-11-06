using UnityEngine;
using System.Collections;

public class SphereCollider : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        

    }
	
	// Update is called once per frame
	void Update () {
        /*Collider[] colliders = Physics.OverlapSphere(transform.position, 5);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(1000, transform.position, 5, 3.0F);
        }*/
    }
}
