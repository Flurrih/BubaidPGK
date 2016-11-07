using UnityEngine;
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
                    rb.AddExplosionForce(600, transform.position, 5, 3.0F);

                if(hit.gameObject.CompareTag("Player") && PlayerDamageCounter == 0)
                {
                    hit.GetComponent<PlayerController>().GotHit();   //SetHealth(-20);
                    PlayerDamageCounter = 1;
                }

                if(hit.gameObject.CompareTag("Bonus Box") && boxDamageCounter == 0)
                {
                    hit.GetComponent<BonusBoxController>().DecreaseDurability(25);
                    boxDamageCounter = 1;
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
