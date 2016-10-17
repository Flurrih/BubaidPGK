using UnityEngine;
using System.Collections;

public class HealthTextRotation : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // var rotationAngle = Quaternion.LookRotation(Camera.main.transform.position - transform.position); // we get the angle has to be rotated
        //transform.localRotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * 5); // we rotate the rotationAngle 
       // transform.position = GetComponentInParent<PlayerController>().transform.position;
        transform.position = new Vector3(GetComponentInParent<PlayerController>().transform.position.x -1, GetComponentInParent<PlayerController>().transform.position.y + 3, GetComponentInParent<PlayerController>().transform.position.z);
        transform.LookAt(-Camera.main.transform.position);
        GetComponent<TextMesh>().text = GetComponentInParent<PlayerController>().GetHealth().ToString();
    }


}
