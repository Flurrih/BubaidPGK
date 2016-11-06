using UnityEngine;
using System.Collections;

public class GravityBonusController : MonoBehaviour {

    private double explosionTimeLeft = 0.3;
    private float bonusTimeLeft = 8;
    private bool isBonus = false;
    private Collider tmpCollider;
    private GameObject[] players;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GravityBonus();
        InitializeExplosion();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tmpCollider = other;
            isBonus = true;
            MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            //Destroy(this.gameObject);
        }
    }

    void GravityBonus()
    {
        if (isBonus)
        {

            if (bonusTimeLeft > 0)
            {
                foreach(GameObject player in players)
                {
                    if(player.GetComponent<PlayerController>().playerNumber != tmpCollider.GetComponent<PlayerController>().playerNumber)
                    {
                        player.GetComponent<PlayerController>().SetMovement(-1);
                        player.GetComponent<PlayerController>().playersBall.GetComponent<BallMoveController>().SetMovement(-1);
                    }
                }

                bonusTimeLeft -= Time.deltaTime;
            }
            else
            {
                foreach (GameObject player in players)
                {
                    if (player.GetComponent<PlayerController>().playerNumber != tmpCollider.GetComponent<PlayerController>().playerNumber)
                    {
                        player.GetComponent<PlayerController>().SetMovement(1);
                        player.GetComponent<PlayerController>().playersBall.GetComponent<BallMoveController>().SetMovement(1);
                    }
                }

                bonusTimeLeft = 8;
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
