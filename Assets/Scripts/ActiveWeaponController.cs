using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActiveWeaponController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image ball;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeActiveWeapon();
	}

    void ChangeActiveWeapon()
    {
        if (player != null && ball != null)
        {
            if (player.GetComponent<PlayerController>().isBallReleased == true)
            {
                ball.GetComponent<Image>().enabled = false;
            }
            else if (player.GetComponent<PlayerController>().isBallReleased == false)
            {
                ball.GetComponent<Image>().enabled = true;
            }
        }
        
    }
}
