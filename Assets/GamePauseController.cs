﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GamePauseController : MonoBehaviour {
    enum ButtonState { Pressed, Released}
    enum MenuState { Open, Closed, None}
    enum Stop { On, Off}
    Stop stopState;
    MenuState menuState;
    ButtonState buttonState;
    int x;

    [SerializeField]
    GameObject pause;

    enum ButtonHandled { Yes, No}
    ButtonHandled buttonHandled;

	// Use this for initialization
	void Start () {
        buttonHandled = ButtonHandled.No;
        menuState = MenuState.Closed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(InputManager.gameInput.getPlayerInput(1).Reset.ToString()) && buttonHandled == ButtonHandled.No)
        {
            if(menuState == MenuState.Closed && buttonHandled == ButtonHandled.No)
            {
                menuState = MenuState.Open;
                buttonHandled = ButtonHandled.Yes;
            }
            if (menuState == MenuState.Open && buttonHandled == ButtonHandled.No)
            {
                menuState = MenuState.Closed;
                buttonHandled = ButtonHandled.Yes;
            }

            Debug.Log("Pressed");
            buttonHandled = ButtonHandled.Yes;
        }
        if (!Input.GetButton(InputManager.gameInput.getPlayerInput(1).Reset.ToString()))
        {
            Debug.Log("Released");
            buttonHandled = ButtonHandled.No;
        }

        if (menuState == MenuState.Open)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
        if (menuState == MenuState.Closed)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }

    public void OnContinue()
    {
        menuState = MenuState.Closed;
    }

    public void OnExit()
    {
        menuState = MenuState.Closed;
        SceneManager.LoadSceneAsync("Menu");
    }
}


