using UnityEngine;
using System.Collections;

public class SlowingDownSphereController : MonoBehaviour
{

    private double explosionTimeLeft = 0.3;
    private bool isBonus = false;
    private GameObject slowingDownPlayer;

    [SerializeField]
    private double bonusTime;

    // Use this for initialization
    void Start()
    {
        MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
        render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        InitializeExplosion();
        SlowDownPlayer();
    }

    void InitializeExplosion()
    {
        if (explosionTimeLeft > 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 10);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(50, transform.position, 5, 3.0F);

                if (hit.gameObject.CompareTag("Player") && hit.gameObject != null)
                {
                    isBonus = true;
                    slowingDownPlayer = hit.gameObject;
                    slowingDownPlayer.GetComponent<PlayerController>().SetSpeed(5);   
                }
            }

            explosionTimeLeft -= Time.deltaTime;
        }
        /*else if (explosionTimeLeft <= 0)
        {
            Destroy(gameObject);
        }*/
    }

    void SlowDownPlayer()
    {
        if(isBonus)
        {
            if(bonusTime > 0)
            {
                bonusTime -= Time.deltaTime;
                Debug.Log(bonusTime);
            }
            else if(bonusTime <= 0)
            {
                if(slowingDownPlayer.GetComponent<PlayerController>().GetSpeed() == 5)
                    slowingDownPlayer.GetComponent<PlayerController>().SetSpeed(10);
            }
        }
    }
}
