using UnityEngine;
using System.Collections;

public class ExplosiveBoxController : MonoBehaviour {

    public GameObject sphere;
    public GameObject fragments;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
