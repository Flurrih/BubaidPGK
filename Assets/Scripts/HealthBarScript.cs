using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image healthContent;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float lerpSpeed;


    //public float MaxHealthValue { get; set; }

    /*public float HealthValue
    {
        set
        {
            fillAmount = MapHealth(value, 0, MaxHealthValue, 0, 1);
        }
    }*/

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if (player != null)
        {
            fillAmount = MapHealth(player.GetComponent<PlayerController>().GetHealth(), 0, 100, 0, 1);
            if (healthContent.fillAmount > fillAmount)
            {
                    healthContent.fillAmount -= 0.01f;
            }
                
        }
        else
        {
            if(healthContent != null)
                healthContent.fillAmount = MapHealth(0, 0, 100, 0, 1);
        }
    }

    private float MapHealth(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
