using UnityEngine;
using System.Collections;

public class BallAI : MonoBehaviour {

    GameObject targetPlayer; //the enemy's target
    float moveSpeed = 3; //move speed
    float rotationSpeed = 3; //speed of turning


    Transform myTransform; //current transform data of this enemy

    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }


    void Start()
    {

        StartCoroutine(Follow());
    }


    void Update()
    {
    }

    IEnumerator Follow()
    {
        while(Vector3.Distance(myTransform.position, targetPlayer.transform.position) > 1.5f && targetPlayer != null)
        {
            //rotate to look at the player
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(targetPlayer.gameObject.transform.position - myTransform.position), rotationSpeed * Time.deltaTime);


            //move towards the player
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            yield return null;
        }

    }

    public void SetTarget(GameObject target)
    {
        targetPlayer = target;
    }
}
