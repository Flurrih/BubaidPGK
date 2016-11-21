using UnityEngine;
using System.Collections;

public class ExplosiveWaveController : MonoBehaviour {

    private float startScale = 1;
    private double explosionTimeLeft = 3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (explosionTimeLeft > 0)
        {
            transform.localScale = new Vector3(startScale += Time.deltaTime * 1, startScale += Time.deltaTime * 1, startScale += Time.deltaTime * 1);
            explosionTimeLeft -= Time.deltaTime;
        }
        else if (explosionTimeLeft <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GotHit(20);
        }

        if (other.gameObject.CompareTag("Bonus Box"))
        {
            other.GetComponent<BonusBoxController>().DecreaseDurability(25);
        }
    }
}
