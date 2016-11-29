using UnityEngine;
using System.Collections;

public class ExplosiveWaveController : MonoBehaviour
{
    public GameObject explosionEffect;
    private float effect_x = 5;
    private float effect_y = 5;
    private float effect_z = 5;

    private bool raycasting = true;
    private double explosionTimeLeft = 1;
    private double pullTimeLeft = 4;
    private bool isExplosion = false;
    private int playerOneDamageCounter = 0;
    private int playerTwoDamageCounter = 0;
    Quaternion spreadAngle;
    Vector3 castingVector;
    int iterator = 0;


    // Use this for initialization
    void Start()
    {
        //explosionEffect.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        // MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
        // render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        InitializeExplosion();
    }

    void InitializeExplosion()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position;
        Vector3 noAngle = transform.forward;

        if(pullTimeLeft > 0)
        {
            explosionEffect.transform.localScale = new Vector3(effect_x-=0.01f, effect_y -= 0.01f, effect_z -= 0.01f);

            Collider[] particles = Physics.OverlapSphere(transform.position, 25);

            foreach (Collider particle in particles)
            {
                if (particle.gameObject.CompareTag("BoxParticle"))
                    particle.transform.GetComponent<Rigidbody>().AddForce(-10 * (particle.transform.position - transform.position), ForceMode.Acceleration);
            }

            pullTimeLeft -= Time.deltaTime;
        }
        else if(pullTimeLeft <= 0)
        {
            Collider[] blocks = Physics.OverlapSphere(transform.position, 5);

            foreach(Collider block in blocks)
            {
                Rigidbody rb = block.GetComponent<Rigidbody>();

                if(block.gameObject.CompareTag("BoxParticle"))
                    rb.AddExplosionForce(150, transform.position, 5, 3.0F);
            }
            
            isExplosion = true;
            explosionEffect.transform.localScale = new Vector3(effect_x += 1.2f, effect_y += 1.2f, effect_z += 1.2f);
        }


        if (explosionTimeLeft > 0 && isExplosion == true)
        {
            
            if(raycasting)
            {
                for (int i = 0; i < 360; i++)
                {
                    spreadAngle = Quaternion.AngleAxis(i, new Vector3(0, 1, 0));
                    castingVector = spreadAngle * noAngle;

                    if (Physics.Raycast(p1, castingVector, out hit, 100) && hit.transform.tag == "Player")
                    {
                        Debug.Log(hit.distance);
                        Debug.DrawRay(p1, castingVector, Color.green);
                        if (hit.transform.GetComponent<PlayerController>().playerNumber == 1 && playerOneDamageCounter == 0)
                        {
                            hit.transform.GetComponent<PlayerController>().GotHit(20);
                            playerOneDamageCounter = 1;
                        }

                        if (hit.transform.GetComponent<PlayerController>().playerNumber == 2 && playerTwoDamageCounter == 0)
                        {
                            hit.transform.GetComponent<PlayerController>().GotHit(20);
                            playerTwoDamageCounter = 1;
                        }

                    }
                }

                raycasting = false;
            }
            


            explosionTimeLeft -= Time.deltaTime;
        }
        else if (explosionTimeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
