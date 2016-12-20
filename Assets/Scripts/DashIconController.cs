using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashIconController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image dashActive;

    [SerializeField]
    private float lerpSpeed;

    private bool isBonus = true;

    // Use this for initialization
    void Start()
    {
        dashActive.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShowDash();
    }

    void ShowDash()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerController>().IsDashingCooldown() == true)
            {
                if (isBonus)
                {
                    dashActive.fillAmount = 0;
                    isBonus = false;
                }

                //dashActive.fillAmount = Mathf.Lerp(dashActive.fillAmount, 1, Time.deltaTime * lerpSpeed);
                dashActive.fillAmount += Time.deltaTime * 0.5f;
            }

            if (player.GetComponent<PlayerController>().IsDashingCooldown() == false)
            {
                dashActive.fillAmount = 1;
                isBonus = true;
            }
        }

    }
}
