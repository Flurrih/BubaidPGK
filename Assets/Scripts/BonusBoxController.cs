using UnityEngine;
using System.Collections;

public class BonusBoxController : MonoBehaviour {

    private int durability;
    public GameObject[] bonuses;
    public GameObject fragments;


    // Use this for initialization
    void Start ()
    {
        durability = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GotHit();
        }

        if (other.gameObject.CompareTag("ExplosiveWave"))
        {
            Debug.Log("yes");
            GotHit();
        }
    }

    public void GotHit()
    {
        durability -= 25;
        if(durability <= 0)
        {
            Instantiate(bonuses[Random.Range(0, bonuses.Length)], transform.position, transform.rotation);
            Instantiate(fragments, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public int GetDurability()
    {
        return durability;
    }

    public void DecreaseDurability(int value)
    {
        durability -= value;
        if (durability <= 0)
        {
            Instantiate(bonuses[Random.Range(0, bonuses.Length)], transform.position, transform.rotation);
            Instantiate(fragments, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
