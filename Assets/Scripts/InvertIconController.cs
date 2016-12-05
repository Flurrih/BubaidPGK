using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InvertIconController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image invertActive;

    [SerializeField]
    private float lerpSpeed;

    private bool isBonus = true;
    private bool isPostionLocked = false;

    // Use this for initialization
    void Start()
    {
        invertActive.fillAmount = 0;
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
            if (player.GetComponent<PlayerController>().getInvert() == -1)
            {
                if (isBonus)
                {
                    invertActive.fillAmount = 1;
                    isBonus = false;
                }


                
                if (player.GetComponent<PlayerController>().GetSpeed() == 20 && player.GetComponent<PlayerController>().IsInviolability() == true && isPostionLocked == false)
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
                else if (player.GetComponent<PlayerController>().GetSpeed() == 5 && player.GetComponent<PlayerController>().IsInviolability() == true && isPostionLocked == false)
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
                else if (player.GetComponent<PlayerController>().GetSpeed() == 20 && isPostionLocked == false)
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
                else if (player.GetComponent<PlayerController>().getInvert() == -1 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {

                    }
                    else
                    {

                    }
                    gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 70.9f);
                    isPostionLocked = true;
                }

                invertActive.fillAmount = Mathf.Lerp(invertActive.fillAmount, 0, Time.deltaTime * lerpSpeed);
            }

            if (player.GetComponent<PlayerController>().getInvert() == 1)
            {
                invertActive.fillAmount = 0;
                isBonus = true;
                gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-24.89f, 70.9f);
                isPostionLocked = false;
            }
        }

    }
}
