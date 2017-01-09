using UnityEngine;
using System.Collections;

public class SlowingDownBoxController : MonoBehaviour
{

    public GameObject sphere;
    public GameObject fragments;
    private RaycastHit hit;
    private GameObject cylinder;
    private float shorten = 3.5f;

    void Start()
    {
        CreateCylinder();
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 2);
        shorten -= Time.deltaTime * 0.8f;
        cylinder.transform.localScale = new Vector3(shorten, 0.1f, shorten);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Instantiate(sphere, transform.position, transform.rotation);
            Instantiate(fragments, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(cylinder);
        }
    }

    void CreateCylinder()
    {
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit) && hit.transform.tag == "Player")
        {
            cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - 0.7f, hit.transform.position.z);
            cylinder.transform.localScale = new Vector3(3.5f, 0.1f, 3.5f);
            //cylinder.GetComponent<Renderer>().material = Resources.Load("Inviolability Bonus Material") as Material;
            Rigidbody rb = cylinder.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.detectCollisions = false;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
}
