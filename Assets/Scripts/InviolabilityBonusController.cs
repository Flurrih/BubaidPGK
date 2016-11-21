using UnityEngine;
using System.Collections;

public class InviolabilityBonusController : MonoBehaviour {

    private double explosionTimeLeft = 0.3;
    private float bonusTimeLeft = 6;
    private bool isBonus = false;
    private Collider tmpCollider;
    private GameObject[] players;
    private Material inviolabilityMat;
    private Material playerMat;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        inviolabilityMat = Resources.Load("Inviolability Bonus Material", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        InviolabilityBonus();
        InitializeExplosion();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMat = other.GetComponent<Renderer>().material;
            tmpCollider = other;
            isBonus = true;
            MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            //Destroy(this.gameObject);
        }
    }

    void InviolabilityBonus()
    {
        if (isBonus)
        {

            if (bonusTimeLeft > 0)
            {
                tmpCollider.GetComponent<MeshRenderer>().material = inviolabilityMat;
                tmpCollider.GetComponent<PlayerController>().SetInviolability(true);
                Debug.Log(bonusTimeLeft);
                bonusTimeLeft -= Time.deltaTime;
            }
            else
            {
                tmpCollider.GetComponent<MeshRenderer>().material = playerMat;
                tmpCollider.GetComponent<PlayerController>().SetInviolability(false);
                bonusTimeLeft = 6;
                isBonus = false;
                Destroy(gameObject);
                return;
            }
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
}
