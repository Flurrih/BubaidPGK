using UnityEngine;
using System.Collections;

public class BallTriggerController : MonoBehaviour {
    
    float timerTrigger;
    float groudedTime;
    public ParticleSystem particle;
    public ParticleSystem particleGround;

    public float groundedLimit = 2;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
            if (GetComponent<BallMoveController>().State == BallMoveController.BallState.Normal)
            {
                if (timerTrigger >= 2.0f)
                {
                    other.GetComponent<PlayerController>().GotHit(25);
                    timerTrigger = 0.0f;
                }
            }

            if(GetComponent<BallMoveController>().State == BallMoveController.BallState.Smashed)
            {
                if (timerTrigger >= 2.0f)
                {
                    other.GetComponent<PlayerController>().GotHit(40);
                    timerTrigger = 0.0f;
                }
            }
        }

        
    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && this.GetComponent<BallMoveController>().playerNumber != other.GetComponent<PlayerController>().playerNumber)
        {
           if(timerTrigger >= 2.0f)
            {
                other.GetComponent<PlayerController>().GotHit(5);
                timerTrigger = 0.0f;
            }
        }

        if (other.tag == "Ground" && GetComponent<BallMoveController>().State == BallMoveController.BallState.Smashed)
        {
            GetComponent<BallMoveController>().State = BallMoveController.BallState.Grounded;
            //particle.startColor = other.gameObject.GetComponent<Renderer>().material.color;
            Color groundColor = avgColor(other.gameObject.GetComponent<Renderer>().material.GetTexture("_MainTex") as Texture2D);
            groundColor = new Color(groundColor.r - 0.4f, groundColor.g - 0.4f, groundColor.b - 0.4f);
            particleGround.startColor = groundColor;
            particle.startColor = groundColor;
            particle.Play();
            particleGround.Play();
        }
    }

    void Update()
    {
        if(GetComponent<BallMoveController>().State == BallMoveController.BallState.Normal)
            timerTrigger += Time.deltaTime;

        if (GetComponent<BallMoveController>().State == BallMoveController.BallState.Grounded) {
            groudedTime += Time.deltaTime;

            if (groudedTime >= groundedLimit)
            {
                GetComponent<BallMoveController>().State = BallMoveController.BallState.Normal;
                groudedTime = 0.0f;
            }
        }
    }

    private Color avgColor(Texture2D texture)
    {
        Color[] textureColors = texture.GetPixels();
        float r = 0, g = 0, b = 0;

        for (int i = 0; i < textureColors.Length; i++)
        {
            r += textureColors[i].r;
            g += textureColors[i].g;
            b += textureColors[i].b;
        }
            return new Color(r / textureColors.Length, g / textureColors.Length, b / textureColors.Length);
    }
    
}
