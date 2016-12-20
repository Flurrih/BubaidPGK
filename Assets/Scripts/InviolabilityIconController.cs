using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InviolabilityIconController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Image inviolabilityActive;

    [SerializeField]
    private float lerpSpeed;

    private bool isBonus = true;
    private bool isPostionLocked = false;

    // Use this for initialization
    void Start()
    {
        inviolabilityActive.fillAmount = 0;
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
            if (player.GetComponent<PlayerController>().IsInviolability() == true)
            {
                if (isBonus)
                {
                    inviolabilityActive.fillAmount = 1;
                    isBonus = false;
                }

                
                
                if (player.GetComponent<PlayerController>().GetSpeed() == 20 && player.GetComponent<PlayerController>().getInvert() == -1 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 212f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 212f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().GetSpeed() == 5 && player.GetComponent<PlayerController>().getInvert() == -1 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 212f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 212f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().GetSpeed() == 20 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 241f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 241f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().GetSpeed() == 5 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 241f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 241f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().getInvert() == -1 && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 241f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 241f);
                    }
                    
                    isPostionLocked = true;
                }
                else if (player.GetComponent<PlayerController>().IsInviolability() == true && isPostionLocked == false)
                {
                    if (gameObject.CompareTag("PlayerInterface2"))
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(780.8f, 270f);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(24.89f, 270f);
                    }
                    
                    isPostionLocked = true;
                }
                /*else if(player.GetComponent<PlayerController>().GetSpeed() == 10 && isPostionLocked == true)
                {
                    isPostionLocked = false;
                    Debug.Log("yup");
                }
                else if(player.GetComponent<PlayerController>().getInvert() == 1 && isPostionLocked == true)
                {
                    isPostionLocked = false;
                }*/

                inviolabilityActive.fillAmount -= Time.deltaTime * 0.16f;
            }

            if (player.GetComponent<PlayerController>().IsInviolability() == false)
            {
                inviolabilityActive.fillAmount = 0;
                isBonus = true;
                gameObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-24.89f, 70.9f);
                isPostionLocked = false;
            }

 
        }

    }
}
