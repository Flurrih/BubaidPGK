using UnityEngine;
using System.Collections;

public class InvertMovementBonusController : MonoBehaviour
{

    private double explosionTimeLeft = 0.3;
    private float bonusTimeLeft = 8;
    private bool isBonus = false;
    private Collider tmpCollider;
    private GameObject[] players;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvertBonus();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tmpCollider = other;
            isBonus = true;
            MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            //Destroy(this.gameObject);
        }
    }

    void InvertBonus()
    {
        if (isBonus)
        {

            if (bonusTimeLeft > 0)
            {
                foreach (GameObject player in players)
                {
                    if (player.GetComponent<PlayerController>().playerNumber != tmpCollider.GetComponent<PlayerController>().playerNumber)
                    {
                        player.GetComponent<PlayerController>().SetMovement(-1);
                        player.GetComponent<PlayerController>().playersBall.GetComponent<BallMoveController>().SetMovement(-1);
                    }
                }

                bonusTimeLeft -= Time.deltaTime;
            }
            else
            {
                foreach (GameObject player in players)
                {
                    if (player.GetComponent<PlayerController>().playerNumber != tmpCollider.GetComponent<PlayerController>().playerNumber)
                    {
                        player.GetComponent<PlayerController>().SetMovement(1);
                        player.GetComponent<PlayerController>().playersBall.GetComponent<BallMoveController>().SetMovement(1);
                    }
                }

                bonusTimeLeft = 8;
                isBonus = false;
                Destroy(gameObject);
                return;
            }
        }
    }

   
}
