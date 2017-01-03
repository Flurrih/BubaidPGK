using UnityEngine;
using System.Collections;

public class chainscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ConfigurableJoint>().projectionDistance = 0.01f;
        GetComponent<ConfigurableJoint>().projectionAngle = 180;
        GetComponent<ConfigurableJoint>().projectionMode= JointProjectionMode.PositionAndRotation;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
