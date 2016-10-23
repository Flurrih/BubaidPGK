using UnityEngine;
using System.Collections;

public class DurabilityTextController : MonoBehaviour {

    public GameObject obj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // var rotationAngle = Quaternion.LookRotation(Camera.main.transform.position - transform.position); // we get the angle has to be rotated
        //transform.localRotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * 5); // we rotate the rotationAngle 
        // transform.position = GetComponentInParent<PlayerController>().transform.position;
        transform.position = new Vector3(GetComponentInParent<BonusBoxController>().transform.position.x - 1, GetComponentInParent<BonusBoxController>().transform.position.y + 3, GetComponentInParent<BonusBoxController>().transform.position.z + 1);
        //transform.LookAt(-Camera.main.transform.position);
        GetComponent<TextMesh>().text = GetComponentInParent<BonusBoxController>().GetDurability().ToString();
    }
}
