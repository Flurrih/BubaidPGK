using UnityEngine;
using System.Collections;

public class BallTriggerController : MonoBehaviour {
    
    float timerTrigger;
    float groudedTime;

    public float groundedLimit = 2;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
            if (GetComponent<BallMoveController>().State == BallMoveController.BallState.Normal)
            {
                if (timerTrigger >= 2.0f)
                {
                    other.GetComponent<PlayerController>().GotHit(25);
                    timerTrigger = 0.0f;
                }
            }

            if(GetComponent<BallMoveController>().State == BallMoveController.BallState.Smashed)
            {
                if (timerTrigger >= 2.0f)
                {
                    other.GetComponent<PlayerController>().GotHit(40);
                    timerTrigger = 0.0f;
                }
            }
        }

        
    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
           if(timerTrigger >= 2.0f)
            {
                other.GetComponent<PlayerController>().GotHit(5);
                timerTrigger = 0.0f;
            }
        }

        if (other.tag == "Ground" && GetComponent<BallMoveController>().State == BallMoveController.BallState.Smashed)
        {
            GetComponent<Rigidbody>().mass = 1000;
            GetComponent<BallMoveController>().State = BallMoveController.BallState.Grounded;
        }
    }

    void Update()
    {
        if(GetComponent<BallMoveController>().State == BallMoveController.BallState.Normal)
            timerTrigger += Time.deltaTime;

        if (GetComponent<BallMoveController>().State == BallMoveController.BallState.Grounded) {
            groudedTime += Time.deltaTime;

            if (groudedTime >= groundedLimit)
            {
                GetComponent<Rigidbody>().mass = 5;
                GetComponent<BallMoveController>().State = BallMoveController.BallState.Normal;
                groudedTime = 0.0f;
            }
        }
    }
    
}
