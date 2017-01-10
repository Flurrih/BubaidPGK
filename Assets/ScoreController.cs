using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public GameObject player1, player2;
    int player1Score=0, player2Score=0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();

        if (PlayerPrefs.HasKey("player1Score"))
            player1Score = PlayerPrefs.GetInt("player1Score");
        if (PlayerPrefs.HasKey("player2Score"))
            player2Score = PlayerPrefs.GetInt("player2Score");
    }
	
	// Update is called once per frame
	void Update () {


        if (player1.GetComponentInChildren<PlayerController>().IsDead())
        {
            player2Score++;
            PlayerPrefs.SetInt("player2Score", player2Score);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        if (player2.GetComponentInChildren<PlayerController>().IsDead())
        {
            player1Score++;
            PlayerPrefs.SetInt("player1Score", player1Score);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        score.text = player2Score + " : " + player1Score;
        Debug.Log(player2Score + " : " + player1Score);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
