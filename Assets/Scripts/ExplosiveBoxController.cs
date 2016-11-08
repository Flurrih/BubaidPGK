using UnityEngine;
using System.Collections;

public class ExplosiveBoxController : MonoBehaviour {

    public GameObject sphere;
    public GameObject fragments;
    
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 2);

        if(transform.position.y < 1.7)
        {
            Instantiate(sphere, transform.position, transform.rotation);
            Instantiate(fragments, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
