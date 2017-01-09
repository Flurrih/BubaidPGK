using UnityEngine;
using System.Collections;

public class SlowingDownBoxesBonusController : MonoBehaviour
{

    public GameObject slowingDownBox;
    private double explosionTimeLeft = 0.3;
    private GameObject[] players;
    private GameObject focusedPlayer;
    private float x;
    private float z;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //InitializeExplosion();
        if(focusedPlayer != null)
        {
            x = focusedPlayer.transform.position.x;
            z = focusedPlayer.transform.position.z;
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            players = GameObject.FindGameObjectsWithTag("Player");

            foreach (var player in players)
            {
                if (player != other.gameObject)
                {
                    focusedPlayer = player;
                }
            }

            x = focusedPlayer.transform.position.x;
            z = focusedPlayer.transform.position.z;

            StartCoroutine(CreateSlowingDownBoxes());
           
            MeshRenderer render = this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            GetComponent<Collider>().enabled = false;
            

            
        }
    }

    IEnumerator CreateSlowingDownBoxes()
    {
        

        for (int i = 0; i < 5; i++)
        {
            Instantiate(slowingDownBox, new Vector3(x, 20, z), transform.rotation);
            
            yield return new WaitForSeconds(2);
        }

        Destroy(gameObject);
    }
}
