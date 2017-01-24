using UnityEngine;
using System.Collections;

public class MenuAudioController : MonoBehaviour {

    AudioSource audioSource;
    bool gameOver;
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 2.22f;
        audioSource.Play();
        gameOver = false;
	}

    void Update()
    {
        if (!gameObject)
        {
            if (audioSource.time >= 147.81f)
            {
                audioSource.time = 14.76f;
            }
        }
    }

    public void GameOverSound()
    {
        gameOver = true;
        audioSource.loop = false;
        audioSource.time = 153.30f;
    }
}
