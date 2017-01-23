using UnityEngine;
using System.Collections;

public class BallFallDown : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FellDown()
    {
        player.GetComponent<PlayerController>().GotHit(100);
    }
}
