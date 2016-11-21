using UnityEngine;
using System.Collections;

public class SlowBallBonusController : MonoBehaviour {

    private double explosionTimeLeft = 0.3;
    private float bonusTimeLeft = 10;
    private bool isBonus = false;
    private Collider tmpCollider;
    private GameObject[] players;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SlowBonus();
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

    void SlowBonus()
    {
        if (isBonus)
        {

            if (bonusTimeLeft > 0)
            {
                foreach (GameObject player in players)
                {
                    if (player.GetComponent<PlayerController>().playerNumber != tmpCollider.GetComponent<PlayerController>().playerNumber)
                    {
                        player.GetComponent<PlayerController>().SetSpeed(4);
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
                        player.GetComponent<PlayerController>().SetSpeed(10);
                    }
                }

                bonusTimeLeft = 10;
                isBonus = false;
                Destroy(gameObject);
                return;
            }
        }
    }

}
