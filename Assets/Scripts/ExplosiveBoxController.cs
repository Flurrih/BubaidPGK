using UnityEngine;
using System.Collections;

public class ExplosiveBoxController : MonoBehaviour {

    public GameObject sphere;
    public GameObject fragments;
    
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            Instantiate(sphere, transform.position, transform.rotation);
            Instantiate(fragments, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
