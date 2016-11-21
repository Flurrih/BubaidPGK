using UnityEngine;
using System.Collections;

public class CollumnController : MonoBehaviour {
    bool isActive;
	// Use this for initialization
	void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        isActive = true;
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void Deactivate()
    {
        isActive = false;
        GetComponent<Renderer>().material.color = Color.grey;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ball")
        {
                Activate();
        }
    }
    public bool GetActive()
    {
        return isActive;
    }
}
