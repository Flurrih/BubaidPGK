using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    public GameObject player1, player2;
    int player1Score=0, player2Score=0;
    Text score;
    public GameObject winnerText;
    float t;
    public MenuAudioController menuAudio;
    void Start()
    {
        score = GetComponent<Text>();

        if (PlayerPrefs.HasKey("player1Score"))
            player1Score = PlayerPrefs.GetInt("player1Score");
        if (PlayerPrefs.HasKey("player2Score"))
            player2Score = PlayerPrefs.GetInt("player2Score");
        winnerText.SetActive(false);
        t = 2.5f;
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

        if (player2Score >= 3 || player1Score >= 3)
        {
            if (player1Score >= 3)
            {
                winnerText.GetComponentInChildren<Text>().text = "Player 1 won!";
            }
            if (player2Score >= 3)
            {
                winnerText.GetComponentInChildren<Text>().text = "Player 2 won!";
            }
            winnerText.SetActive(true);
            
            t -= Time.deltaTime;

            if(t < 0)
            {
                player2Score = 0;
                player1Score = 0;
                PlayerPrefs.SetInt("player1Score", 0);
                PlayerPrefs.SetInt("player2Score", 0);
                SceneManager.LoadSceneAsync("Menu");
            }

        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
