﻿using UnityEngine;
using System.Collections;
using System.IO;

public class InputManager : MonoBehaviour {

    public static GameInput gameInput { get; private set; }

	void Update () {

        //getJoystick1Button();

        //getJoystick2Button();

        //getJoystick1Axis();

        //getJoystick2Axis();

    }

    public static KeyCode getJoystick1Button()
    {
        if (Input.GetButton("Joystick1Button0"))
        {
            return KeyCode.Joystick1Button0;

        }

        if (Input.GetButton("Joystick1Button1"))
        {
            return KeyCode.Joystick1Button1;

        }

        if (Input.GetButton("Joystick1Button2"))
        {
            return KeyCode.Joystick1Button2;

        }

        if (Input.GetButton("Joystick1Button3"))
        {
            return KeyCode.Joystick1Button3;

        }

        if (Input.GetButton("Joystick1Button4"))
        {
            return KeyCode.Joystick1Button4;

        }

        if (Input.GetButton("Joystick1Button5"))
        {
            return KeyCode.Joystick1Button5;

        }

        if (Input.GetButton("Joystick1Button6"))
        {
            return KeyCode.Joystick1Button6;

        }

        if (Input.GetButton("Joystick1Button7"))
        {
            return KeyCode.Joystick1Button7;

        }

        if (Input.GetButton("Joystick1Button8"))
        {
            return KeyCode.Joystick1Button8;

        }

        if (Input.GetButton("Joystick1Button9"))
        {
            return KeyCode.Joystick1Button9;

        }

        if (Input.GetButton("Joystick1Button10"))
        {
            return KeyCode.Joystick1Button10;

        }

        if (Input.GetButton("Joystick1Button11"))
        {
            return KeyCode.Joystick1Button11;
        }
        return KeyCode.ScrollLock;
    }

    public static KeyCode getJoystick2Button()
    {
        if (Input.GetButton("Joystick2Button0"))
        {
            
            return KeyCode.Joystick2Button0;
        }

        if (Input.GetButton("Joystick2Button1"))
        {
            
            return KeyCode.Joystick2Button1;
        }

        if (Input.GetButton("Joystick2Button2"))
        {
            
            return KeyCode.Joystick2Button2;
        }

        if (Input.GetButton("Joystick2Button3"))
        {
            
            return KeyCode.Joystick2Button3;
        }

        if (Input.GetButton("Joystick2Button4"))
        {
            return KeyCode.Joystick2Button4;
        }

        if (Input.GetButton("Joystick2Button5"))
        {
            return KeyCode.Joystick2Button5;
        }

        if (Input.GetButton("Joystick2Button6"))
        {
            return KeyCode.Joystick2Button6;
        }

        if (Input.GetButton("Joystick2Button7"))
        {
            return KeyCode.Joystick2Button7;
        }

        if (Input.GetButton("Joystick2Button8"))
        {
            return KeyCode.Joystick2Button8;
        }

        if (Input.GetButton("Joystick2Button9"))
        {
            return KeyCode.Joystick2Button9;
        }

        if (Input.GetButton("Joystick2Button10"))
        {
            return KeyCode.Joystick2Button10;
        }

        if (Input.GetButton("Joystick2Button11"))
        {
            return KeyCode.Joystick2Button11;
        }
        return KeyCode.ScrollLock;
    }

    public static GameInput.Axis getJoystick1Axis()
    {
        float x = 0.0f;

        GameInput.Axis axis = new GameInput.Axis();
        axis.AxisName = null;

        x = Input.GetAxis("Joystick1AxisX");

        if(x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis X:" + x);
            
            axis.AxisName = "Joystick1AxisX";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1AxisY");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis Y:" + x);
            axis.AxisName = "Joystick1AxisY";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis3");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 3:" + x);
            axis.AxisName = "Joystick1Axis3";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis4");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 4:" + x);
            axis.AxisName = "Joystick1Axis4";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis5");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 5:" + x);
            axis.AxisName = "Joystick1Axis5";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis6");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 6:" + x);
            axis.AxisName = "Joystick1Axis6";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis7");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 7:" + x);
            axis.AxisName = "Joystick1Axis7";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis8");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 8:" + x);
            axis.AxisName = "Joystick1Axis8";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis9");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 9:" + x);
            axis.AxisName = "Joystick1Axis9";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick1Axis10");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 1 Axis 10:" + x);
            axis.AxisName = "Joystick1Axis10";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }
        return axis;
    }

    public static GameInput.Axis getJoystick2Axis()
    {
        float x = 0.0f;

        GameInput.Axis axis = new GameInput.Axis();
        axis.AxisName = null;

        x = Input.GetAxis("Joystick2AxisX");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis X:" + x);
            axis.AxisName = "Joystick2AxisX";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2AxisY");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis Y:" + x);
            axis.AxisName = "Joystick2AxisY";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis3");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 3:" + x);
            axis.AxisName = "Joystick2Axis3";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis4");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 4:" + x);
            axis.AxisName = "Joystick2Axis4";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis5");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 5:" + x);
            axis.AxisName = "Joystick2Axis5";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis6");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 6:" + x);
            axis.AxisName = "Joystick2Axis6";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis7");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 7:" + x);
            axis.AxisName = "Joystick2Axis7";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis8");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 8:" + x);
            axis.AxisName = "Joystick2Axis8";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis9");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 9:" + x);
            axis.AxisName = "Joystick2Axis9";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }

        x = Input.GetAxis("Joystick2Axis10");

        if (x >= 0.75f || (x <= -0.5f && x >= -0.9f))
        {
            Debug.Log("Joystick 2 Axis 10:" + x);
            axis.AxisName = "Joystick2Axis10";
            if (x < 0)
                axis.AxisName = axis.AxisName + "Invert";
            return axis;
        }
        return axis;
    }

    void Awake()
    {
        gameInput = new GameInput();
        if (!File.Exists("GameInput.xml"))
        {
            #region player1Region
            GameInput.Axis player1AxisVertical1 = new GameInput.Axis();

            player1AxisVertical1.AxisName = "Joystick1AxisY";
            player1AxisVertical1.value = Input.GetAxis(player1AxisVertical1.AxisName);

            GameInput.Axis player1AxisHorizontal1 = new GameInput.Axis();

            player1AxisHorizontal1.AxisName = "Joystick1AxisX";
            player1AxisHorizontal1.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

            GameInput.Axis player1AxisVertical2 = new GameInput.Axis();

            player1AxisVertical2.AxisName = "Joystick1Axis4";
            player1AxisVertical2.value = Input.GetAxis(player1AxisVertical1.AxisName);

            GameInput.Axis player1AxisHorizontal2 = new GameInput.Axis();

            player1AxisHorizontal2.AxisName = "Joystick1Axis3";
            player1AxisHorizontal2.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

            GameInput.PlayerInput player1 = new GameInput.PlayerInput(
                1,
                KeyCode.Joystick1Button0,
                KeyCode.Joystick1Button1,
                KeyCode.Joystick1Button7,
                KeyCode.Joystick1Button6,
                KeyCode.Joystick1Button2,
                KeyCode.Joystick1Button9,
                player1AxisVertical1,
                player1AxisHorizontal1,
                player1AxisVertical2,
                player1AxisHorizontal2
                );

            #endregion

            #region player2Region
            GameInput.Axis player2AxisVertical1 = new GameInput.Axis();

            player2AxisVertical1.AxisName = "Joystick2AxisY";
            player2AxisVertical1.value = Input.GetAxis(player1AxisVertical1.AxisName);

            GameInput.Axis player2AxisHorizontal1 = new GameInput.Axis();

            player2AxisHorizontal1.AxisName = "Joystick2AxisX";
            player2AxisHorizontal1.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

            GameInput.Axis player2AxisVertical2 = new GameInput.Axis();

            player2AxisVertical2.AxisName = "Joystick1Axis6";
            player2AxisVertical2.value = Input.GetAxis(player1AxisVertical1.AxisName);

            GameInput.Axis player2AxisHorizontal2 = new GameInput.Axis();

            player2AxisHorizontal2.AxisName = "Joystick1Axis3";
            player2AxisHorizontal2.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

            GameInput.PlayerInput player2 = new GameInput.PlayerInput(
                2,
                KeyCode.Joystick2Button1,
                KeyCode.Joystick2Button0,
                KeyCode.Joystick2Button7,
                KeyCode.Joystick2Button5,
                KeyCode.Joystick2Button2,
                KeyCode.Joystick2Button9,
                player2AxisVertical1,
                player2AxisHorizontal1,
                player2AxisVertical2,
                player2AxisHorizontal2
                );

            #endregion

            gameInput.player1 = player1;
            gameInput.player2 = player2;

            GameInput.Save(gameInput, "GameInput.xml");
        }
        gameInput = GameInput.LoadDefault();
        
    }

    


}
