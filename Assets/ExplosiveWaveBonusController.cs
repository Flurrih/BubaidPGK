using UnityEngine;
using System.Collections;

public class ExplosiveWaveBonusController : MonoBehaviour {

    public GameObject wave;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(wave, new Vector3(-1.0f, 1.0f, 9.6f), transform.rotation);
            Destroy(gameObject);
        }
    }
}
