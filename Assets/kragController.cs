using UnityEngine;
using System.Collections;

public class kragController : MonoBehaviour {

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private double claimTimeValue;

    private bool isPlayer1Claiming = false;
    private bool isPlayer2Claiming = false;
    private double claimTime;
    private bool kragClaimed = false;
    private double claimedCooldown = 25.0;

	// Use this for initialization
	void Start ()
    {
        claimTime = claimTimeValue;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Claiming();
        Cooldown();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(player1))
        {
            isPlayer1Claiming = true;
        }

        if (other.gameObject.Equals(player2))
        {
            isPlayer2Claiming = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(player1))
        {
            isPlayer1Claiming = false;
            claimTime = 10.0;
        }

        if (other.gameObject.Equals(player2))
        {
            isPlayer1Claiming = false;
            claimTime = 10.0;
        }
    }

    void Claiming()
    {
        if(isPlayer1Claiming)
        {
            if(!isPlayer2Claiming && !kragClaimed)
            {
                if(claimTime > 0)
                    claimTime -= Time.deltaTime;
               Debug.Log(claimTime);
            }
            

            if(claimTime <= 0)
            {
                isPlayer1Claiming = false;
                kragClaimed = true;
                Debug.Log("winner1");
            }
        }
        

        if (isPlayer2Claiming)
        {
            if (!isPlayer1Claiming && !kragClaimed)
            {
                if (claimTime > 0)
                    claimTime -= Time.deltaTime;
                Debug.Log(claimTime);
            }

            if (claimTime <= 0)
            {
                isPlayer2Claiming = false;
                kragClaimed = true;
                Debug.Log("winner2");
            }
        }  
    }

    void Cooldown()
    {
        if(kragClaimed)
        {
            if(claimedCooldown > 0)
            {
                claimedCooldown -= Time.deltaTime;
                Debug.Log(claimedCooldown);
            }
            else if(claimedCooldown <= 0)
            {
                kragClaimed = false;
                claimedCooldown = 25.0;
                claimTime = claimTimeValue;
            }
        }
    }
}
