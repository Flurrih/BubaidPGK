using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	void Update () {
        transform.position = GameObject.Find("Player").transform.position;
	}
}
