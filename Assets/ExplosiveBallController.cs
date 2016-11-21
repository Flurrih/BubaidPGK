using UnityEngine;
using System.Collections;

public class ExplosiveBallController : MonoBehaviour {

    private double timeToExplosion = 4;
    private double explosionTimeLeft = 3;
    private int PlayerDamageCounter = 0;
    private int boxDamageCounter = 0;

    public GameObject explosiveWave;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InitializeExplosion();
    }



    void InitializeExplosion()
    {
        timeToExplosion -= Time.deltaTime;

        if (timeToExplosion <= 0)
        {
            MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            //Instantiate(explosiveWave, transform.position, transform.rotation);

            if (explosionTimeLeft > 0)
            {
                //Collider[] colliders = Physics.OverlapSphere(transform.position, startScale += Time.deltaTime*(float)0.2);

                
               

                /*foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(50, transform.position, 5, 3.0F);

                    if (hit.gameObject.CompareTag("Player") && PlayerDamageCounter == 0)
                    {
                        hit.GetComponent<PlayerController>().GotHit(20);   //SetHealth(-20);
                        PlayerDamageCounter = 1;
                    }

                    if (hit.gameObject.CompareTag("Bonus Box") && boxDamageCounter == 0)
                    {
                        hit.GetComponent<BonusBoxController>().DecreaseDurability(25);
                        boxDamageCounter = 1;
                    }
                }*/

                explosionTimeLeft -= Time.deltaTime;
            }
            else if (explosionTimeLeft <= 0)
            {
                Destroy(gameObject);
            }
            
        }
        
    }
}
