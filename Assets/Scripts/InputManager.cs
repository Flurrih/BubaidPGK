using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private enum ButtonState
    {
        Pressed,
        Released
    }
    public string A1, A2, A3, A4, R1, R2, R3, R4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                Debug.Log(vKey.ToString());
            }
        }

    }


}
