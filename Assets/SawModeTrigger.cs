using UnityEngine;
using System.Collections;

public class SawModeTrigger : MonoBehaviour {

    public GameObject gameModeObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ball")
        {
            Debug.Log("x");
            gameModeObject.GetComponent<SawMode>().SetAction();
        }
    }
}
