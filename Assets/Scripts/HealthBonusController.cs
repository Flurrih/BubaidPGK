using UnityEngine;
using System.Collections;

public class HealthBonusController : MonoBehaviour {

    private double explosionTimeLeft = 0.3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetHealth(25);
            //Debug.Log(player.GetComponent<PlayerController>().GetHealth());
            Destroy(this.gameObject);
        }
    }

    
}
