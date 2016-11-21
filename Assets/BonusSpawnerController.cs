using UnityEngine;
using System.Collections;

public class BonusSpawnerController : MonoBehaviour {

    public GameObject[] bonuses;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("SpawnBonus", 1.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void SpawnBonus()
    {
        Instantiate(bonuses[Random.Range(0, bonuses.Length)], transform.position, transform.rotation);
    }
}
