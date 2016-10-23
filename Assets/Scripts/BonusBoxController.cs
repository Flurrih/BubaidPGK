using UnityEngine;
using System.Collections;

public class BonusBoxController : MonoBehaviour {

    private int durability;

	// Use this for initialization
	void Start ()
    {
        durability = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GotHit(Collider other)
    {
        durability -= 25;
        //Debug.Log(durability);
        if(durability <= 0)
        {
            //Destroy(transform.parent.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    public int GetDurability()
    {
        return durability;
    }
}
