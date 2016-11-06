using UnityEngine;
using System.Collections;

public class ExplosiveBoxesBonusController : MonoBehaviour {

    public GameObject explosiveBox;
    private double explosionTimeLeft = 0.3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InitializeExplosion();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CreateExplosiveBoxes());
            MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            GetComponent<Collider>().enabled = false;
        }
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
                    rb.AddExplosionForce(500, transform.position, 5, 3.0F);
            }

            explosionTimeLeft -= Time.deltaTime;
        }
    }

    IEnumerator CreateExplosiveBoxes()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(explosiveBox, new Vector3(Random.Range(-13, 19), 20, Random.Range(-8, 10)), transform.rotation);
            yield return new WaitForSeconds(2);
        }

        Destroy(gameObject);
    }
}
