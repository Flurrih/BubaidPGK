using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpIconController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image jumpActive;

    [SerializeField]
    private float lerpSpeed;

    private bool isBonus = true;

    // Use this for initialization
    void Start ()
    {
        jumpActive.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShowJump();
	}

    void ShowJump()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerController>().IsJumping() == true)
            {
                if (isBonus)
                {
                    jumpActive.fillAmount = 0;
                    isBonus = false;
                }

                jumpActive.fillAmount = Mathf.Lerp(jumpActive.fillAmount, 1, Time.deltaTime * lerpSpeed);
            }

            if (player.GetComponent<PlayerController>().IsJumping() == false)
            {
                jumpActive.fillAmount = 1;
                isBonus = true;
            }
        }
        
    }
}
