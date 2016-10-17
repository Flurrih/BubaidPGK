using UnityEngine;
using System.Collections;

public class BallTriggerController : MonoBehaviour {

    bool canTrigger;
    float timerTrigger;
    void Start()
    {
        canTrigger = true;
    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
            if(timerTrigger >= 2.0f)
            {
                other.GetComponent<PlayerController>().GotHit();
                timerTrigger = 0.0f;
            }

        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
            canTrigger = true;
        }
        timerTrigger = 0.0f;
    }*/

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
           if(timerTrigger >= 2.0f)
            {
                other.GetComponent<PlayerController>().GotHit();
                timerTrigger = 0.0f;

               
            }
        }
    }

    void Update()
    {
        timerTrigger += Time.deltaTime;
    }
    
}
