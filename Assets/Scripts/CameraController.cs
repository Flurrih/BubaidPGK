using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject[] players;

    private Vector3 targetPoint;
	
	void Update () {

        float x=0, z=0;
        int i = 0;

        foreach (GameObject player in players)
        {
            if (player != null)
            {
                x = x + player.transform.position.x;
                z = z + player.transform.position.z;
                i++;
            }
        }

        targetPoint = new Vector3(x / i, 0, z / i);

        transform.LookAt(targetPoint);
    }
}
