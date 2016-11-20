using UnityEngine;
using System.Collections;

public class SawAnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = transform.localScale;
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * 10.0f);
    }
}
