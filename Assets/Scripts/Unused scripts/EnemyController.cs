using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private int healthPoints = 100;

    private GameObject gObj;

    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void GetHit()
    {
        Debug.Log(healthPoints);
        healthPoints -= 25;
        if (healthPoints <= 0)
            Destroy(this.gameObject);

    }
}
