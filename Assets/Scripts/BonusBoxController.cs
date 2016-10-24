using UnityEngine;
using System.Collections;

public class BonusBoxController : MonoBehaviour {

    private int durability;

    public GameObject box;
    public GameObject bonus;
    public Material bonusMaterial;
    public GameObject[] bonuses;


    // Use this for initialization
    void Start ()
    {
        durability = 50;
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.AddComponent<Rigidbody>();
        //sphere.GetComponent<Rigidbody>().isKinematic = true;
        //sphere.GetComponent<Renderer>().material = bonusMaterial;
        //sphere.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, (box.transform.position.z));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // other.transform.DetachChildren();
            // other.gameObject.SetActive(false);
            //other.gameObject.GetComponent<BonusBoxController>().GotHit(other);
            //box.GetComponent<BonusBoxController>().GotHit();
            // Destroy(other.transform.parent.gameObject);
            GotHit();
        }
    }

    public void GotHit()
    {
        durability -= 25;
        //Debug.Log(durability);
        if(durability <= 0)
        {
            Instantiate(bonuses[Random.Range(0, 2)], box.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //other.gameObject.SetActive(false);
        }
    }

    public int GetDurability()
    {
        return durability;
    }
}
