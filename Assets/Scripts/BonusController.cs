using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {

    private float bonusTimeLeft = 10;
    private bool isBonus = false;
    public GameObject player;
    private Collider collider;

    // Use this for initialization
    void Start ()
    {

    }

    void FixedUpdate()
    {
        SpeedBonus();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBonus = true;
            collider = other;
            MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
        }
    }

    void SpeedBonus()
    {
        if (isBonus)
        {
            
            if (bonusTimeLeft > 0)
            {
                // speed = 20;
                collider.GetComponent<PlayerController>().SetSpeed(20);
                bonusTimeLeft -= Time.deltaTime;
                //Debug.Log(player.GetComponent<PlayerController>().GetSpeed());
                Debug.Log(bonusTimeLeft);
            }
            else
            {
                // speed = 10;
                bonusTimeLeft = 10;
                collider.GetComponent<PlayerController>().SetSpeed(10);
                isBonus = false;
                Destroy(this.gameObject);
                return;
            }
        }
    }


}
