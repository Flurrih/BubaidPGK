using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

    public GameObject otherPortal;
    public GameObject playerDest, ballDest;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //col.transform.position = otherPortal.GetComponent<PortalController>().playerDest.transform.position;
            //col.GetComponent<PlayerController>().playersBall.transform.position = otherPortal.GetComponent<PortalController>().ballDest.transform.position;
            col.transform.parent.position = otherPortal.GetComponent<PortalController>().playerDest.transform.position;
        }

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
