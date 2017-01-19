using UnityEngine;
using System.Collections;

public class MenuAudioController : MonoBehaviour {

    AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 2.22f;
        audioSource.Play();
	
	}

    void Update()
    {
        if(audioSource.time >= 147.81f)
        {
            audioSource.time = 14.76f;
        }
    }
}
