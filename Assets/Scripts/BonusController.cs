using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.parent = null;
    }

    void LateUpdate()
    {
        transform.parent = null;
    }


}
