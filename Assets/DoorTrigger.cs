using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

    GameObject[] players;
    GameObject ballAI;
    public static Object AI;
    

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            ballAI = (GameObject)Instantiate(AI);
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                if (player != col.gameObject)
                    ballAI.GetComponent<BallAI>().SetTarget(player);
            }
        }

    }
	// Use this for initialization
	void Start () {
	    AI = Resources.Load("BallAI", typeof(GameObject));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
