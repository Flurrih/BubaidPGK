﻿using UnityEngine;
using System.Collections;

public class ExplosiveSphereController : MonoBehaviour {

    private double explosionTimeLeft = 0.3;
    private int PlayerDamageCounter = 0;
    private int boxDamageCounter = 0;

    // Use this for initialization
    void Start ()
    {
        MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
        render.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        InitializeExplosion();
	}

    void InitializeExplosion()
    {
        if (explosionTimeLeft > 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(50, transform.position, 5, 3.0F);

                if(hit.gameObject.CompareTag("Player") && PlayerDamageCounter == 0 && hit.gameObject != null)
                {
                    hit.GetComponent<PlayerController>().GotHit(20);   //SetHealth(-20);
                    PlayerDamageCounter = 1;
                }
            }

            explosionTimeLeft -= Time.deltaTime;
        }
        else if(explosionTimeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
