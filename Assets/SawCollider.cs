using UnityEngine;
using System.Collections;

public class SawCollider : MonoBehaviour {

    float timerTrigger = 0.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timerTrigger += Time.deltaTime;
	}

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            if (timerTrigger >= 2.0f)
            {
                col.GetComponent<PlayerController>().GotHit(10);
                timerTrigger = 0.0f;
            }
        }
    }
}
