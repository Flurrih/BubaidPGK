using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SmashIconController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image smashActive;

    [SerializeField]
    private float lerpSpeed;

    private bool isBonus = true;

    // Use this for initialization
    void Start()
    {
        smashActive.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShowSmash();
    }

    void ShowSmash()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerController>().IsSmashing() == true)
            {
                if (isBonus)
                {
                    smashActive.fillAmount = 0;
                    isBonus = false;
                }

                //smashActive.fillAmount = Mathf.Lerp(smashActive.fillAmount, 1, Time.deltaTime * lerpSpeed);
                smashActive.fillAmount += Time.deltaTime * 0.2f;
            }

            if (player.GetComponent<PlayerController>().IsSmashing() == false)
            {
                smashActive.fillAmount = 1;
                isBonus = true;
            }
        }

    }
}
