using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {

    private float bonusTimeLeft = 10;
    private double explosionTimeLeft = 0.3;
    private bool isBonus = false;
    private bool isSpeedNotSet = true;
    private Collider col;
    [SerializeField]
    private int speed;

    // Use this for initialization
    void Start ()
    {

    }

    void FixedUpdate()
    {
        SpeedBonus();
        //InitializeExplosion();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBonus = true;
            col = other;
            MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
        }
    }

    void SpeedBonus()
    {
        if (isBonus)
        {
            
            if (bonusTimeLeft > 0)
            {
                // speed = 20;
                if(isSpeedNotSet)
                {
                    col.GetComponent<PlayerController>().SetSpeed(speed);
                    isSpeedNotSet = false;
                }
                
                bonusTimeLeft -= Time.deltaTime;
                //Debug.Log(player.GetComponent<PlayerController>().GetSpeed());
                Debug.Log(bonusTimeLeft);
            }
            else
            {
                // speed = 10;
                if(col.GetComponent<PlayerController>().GetSpeed() == speed)
                    col.GetComponent<PlayerController>().SetSpeed(10);


                bonusTimeLeft = 10;              
                isBonus = false;
                Destroy(this.gameObject);
                return;
            }
        }
    }

    /*void InitializeExplosion()
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
    }*/


}
