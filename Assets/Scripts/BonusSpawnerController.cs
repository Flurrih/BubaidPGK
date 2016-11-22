using UnityEngine;
using System.Collections;

public class BonusSpawnerController : MonoBehaviour {

    public GameObject[] bonuses;
    BonusSpawnerState spawnerState = BonusSpawnerState.Free;
    private float actionTime = 0.0f;
    public float spawnTime;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnBonus(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnerState = BonusSpawnerState.Free;
        }
    }

    void SpawnBonus()
    {
        if(spawnerState == BonusSpawnerState.Free)
        {
            actionTime += Time.deltaTime;
            if(actionTime >= spawnTime)
            {
                Instantiate(bonuses[Random.Range(0, bonuses.Length)], new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
                spawnerState = BonusSpawnerState.Spawned;
                actionTime = 0.0f;
            }
            
        }
        
    }

    enum BonusSpawnerState
    {
        Free,
        Spawned
    }
}
