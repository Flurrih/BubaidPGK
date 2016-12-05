using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlowIconController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image slowActive;

    [SerializeField]
    private float lerpSpeed;

    private bool isBonus = true;
    private bool isPostionLocked = false;

    // Use this for initialization
    void Start()
    {
        slowActive.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerController>().GetSpeed() == 5)
            {
                if (isBonus)
                {
                    slowActive.fillAmount = 1;
                    isBonus = false;
                }

                
                
                if (player.GetComponent<PlayerController>().IsInviolability() == true && player.GetComponent<PlayerController>().getInvert() == -1 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 128.2f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 128.2f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().getInvert() == -1 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 99.6f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 99.6f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().IsInviolability() == true && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 99.6f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 99.6f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().GetSpeed() == 5 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 70.9f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 70.9f);
                    }
                    
                    isPostionLocked = true;
                }

                slowActive.fillAmount = Mathf.Lerp(slowActive.fillAmount, 0, Time.deltaTime * lerpSpeed);
            }

            if (player.GetComponent<PlayerController>().GetSpeed() == 10)
            {
                slowActive.fillAmount = 0;
                isBonus = true;
                gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-24.89f, 70.9f);
                isPostionLocked = false;
            }
        }

    }
}
