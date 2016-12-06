using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public static GameInput gameInput { get; private set; }

	void Update () {

        //getJoystick1Button();

        //getJoystick2Button();

        //getJoystick1Axis();

        //getJoystick2Axis();

    }

    void getJoystick1Button()
    {
        if (Input.GetButton("Joystick1Button0"))
        {
            Debug.Log("Joystic 1 button 0 pressed");
        }

        if (Input.GetButton("Joystick1Button1"))
        {
            Debug.Log("Joystic 1 button 1 pressed");
        }

        if (Input.GetButton("Joystick1Button2"))
        {
            Debug.Log("Joystic 1 button 2 pressed");
        }

        if (Input.GetButton("Joystick1Button3"))
        {
            Debug.Log("Joystic 1 button 3 pressed");
        }

        if (Input.GetButton("Joystick1Button4"))
        {
            Debug.Log("Joystic 1 button 4 pressed");
        }

        if (Input.GetButton("Joystick1Button5"))
        {
            Debug.Log("Joystic 1 button 5 pressed");
        }

        if (Input.GetButton("Joystick1Button6"))
        {
            Debug.Log("Joystic 1 button 6 pressed");
        }

        if (Input.GetButton("Joystick1Button7"))
        {
            Debug.Log("Joystic 1 button 7 pressed");
        }

        if (Input.GetButton("Joystick1Button8"))
        {
            Debug.Log("Joystic 1 button 8 pressed");
        }

        if (Input.GetButton("Joystick1Button9"))
        {
            Debug.Log("Joystic 1 button 9 pressed");
        }

        if (Input.GetButton("Joystick1Button10"))
        {
            Debug.Log("Joystic 1 button 10 pressed");
        }

        if (Input.GetButton("Joystick1Button11"))
        {
            Debug.Log("Joystic 1 button 11 pressed");
        }
    }

    void getJoystick2Button()
    {
        if (Input.GetButton("Joystick2Button0"))
        {
            Debug.Log("Joystic 2 button 0 pressed");
        }

        if (Input.GetButton("Joystick2Button1"))
        {
            Debug.Log("Joystic 2 button 1 pressed");
        }

        if (Input.GetButton("Joystick2Button2"))
        {
            Debug.Log("Joystic 2 button 2 pressed");
        }

        if (Input.GetButton("Joystick2Button3"))
        {
            Debug.Log("Joystic 2 button 3 pressed");
        }

        if (Input.GetButton("Joystick2Button4"))
        {
            Debug.Log("Joystic 2 button 4 pressed");
        }

        if (Input.GetButton("Joystick2Button5"))
        {
            Debug.Log("Joystic 2 button 5 pressed");
        }

        if (Input.GetButton("Joystick2Button6"))
        {
            Debug.Log("Joystic 2 button 6 pressed");
        }

        if (Input.GetButton("Joystick2Button7"))
        {
            Debug.Log("Joystic 2 button 7 pressed");
        }

        if (Input.GetButton("Joystick2Button8"))
        {
            Debug.Log("Joystic 2 button 8 pressed");
        }

        if (Input.GetButton("Joystick2Button9"))
        {
            Debug.Log("Joystic 2 button 9 pressed");
        }

        if (Input.GetButton("Joystick2Button10"))
        {
            Debug.Log("Joystic 2 button 10 pressed");
        }

        if (Input.GetButton("Joystick2Button11"))
        {
            Debug.Log("Joystic 2 button 11 pressed");
        }
    }

    void getJoystick1Axis()
    {
        float x = 0.0f;

        x = Input.GetAxis("Joystick1AxisX");

        if(x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis X:" + x);
        }

        x = Input.GetAxis("Joystick1AxisY");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis Y:" + x);
        }

        x = Input.GetAxis("Joystick1Axis3");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 3:" + x);
        }

        x = Input.GetAxis("Joystick1Axis4");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 4:" + x);
        }

        x = Input.GetAxis("Joystick1Axis5");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 5:" + x);
        }

        x = Input.GetAxis("Joystick1Axis6");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 6:" + x);
        }

        x = Input.GetAxis("Joystick1Axis7");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 7:" + x);
        }

        x = Input.GetAxis("Joystick1Axis8");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 8:" + x);
        }

        x = Input.GetAxis("Joystick1Axis9");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 9:" + x);
        }

        x = Input.GetAxis("Joystick1Axis10");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 1 Axis 10:" + x);
        }

    }

    void getJoystick2Axis()
    {
        float x = 0.0f;

        x = Input.GetAxis("Joystick2AxisX");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis X:" + x);
        }

        x = Input.GetAxis("Joystick2AxisY");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis Y:" + x);
        }

        x = Input.GetAxis("Joystick2Axis3");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 3:" + x);
        }

        x = Input.GetAxis("Joystick2Axis4");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 4:" + x);
        }

        x = Input.GetAxis("Joystick2Axis5");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 5:" + x);
        }

        x = Input.GetAxis("Joystick2Axis6");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 6:" + x);
        }

        x = Input.GetAxis("Joystick2Axis7");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 7:" + x);
        }

        x = Input.GetAxis("Joystick2Axis8");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 8:" + x);
        }

        x = Input.GetAxis("Joystick2Axis9");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 9:" + x);
        }

        x = Input.GetAxis("Joystick2Axis10");

        if (x != 0.0f)
        {
            Debug.Log("Joystick 2 Axis 10:" + x);
        }

    }

    void Awake()
    {
        #region player1Region
        //GameInput.Axis player1AxisVertical1 = new GameInput.Axis();

        //player1AxisVertical1.AxisName = "Joystick1AxisY";
        //player1AxisVertical1.value = Input.GetAxis(player1AxisVertical1.AxisName);

        //GameInput.Axis player1AxisHorizontal1 = new GameInput.Axis();

        //player1AxisHorizontal1.AxisName = "Joystick1AxisX";
        //player1AxisHorizontal1.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

        //GameInput.Axis player1AxisVertical2 = new GameInput.Axis();

        //player1AxisVertical2.AxisName = "Joystick1Axis4";
        //player1AxisVertical2.value = Input.GetAxis(player1AxisVertical1.AxisName);

        //GameInput.Axis player1AxisHorizontal2 = new GameInput.Axis();

        //player1AxisHorizontal2.AxisName = "Joystick1Axis3";
        //player1AxisHorizontal2.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

        //GameInput.PlayerInput player1 = new GameInput.PlayerInput(
        //    1,
        //    KeyCode.Joystick1Button0,
        //    KeyCode.Joystick1Button1,
        //    KeyCode.Joystick1Button7,
        //    KeyCode.Joystick1Button6,
        //    KeyCode.Joystick1Button2,
        //    player1AxisVertical1,
        //    player1AxisHorizontal1,
        //    player1AxisVertical2,
        //    player1AxisHorizontal2
        //    );

        #endregion

        #region player2Region
        //GameInput.Axis player2AxisVertical1 = new GameInput.Axis();

        //player2AxisVertical1.AxisName = "Joystick2AxisY";
        //player2AxisVertical1.value = Input.GetAxis(player1AxisVertical1.AxisName);

        //GameInput.Axis player2AxisHorizontal1 = new GameInput.Axis();

        //player2AxisHorizontal1.AxisName = "Joystick2AxisX";
        //player2AxisHorizontal1.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

        //GameInput.Axis player2AxisVertical2 = new GameInput.Axis();

        //player2AxisVertical2.AxisName = "Joystick1Axis6";
        //player2AxisVertical2.value = Input.GetAxis(player1AxisVertical1.AxisName);

        //GameInput.Axis player2AxisHorizontal2 = new GameInput.Axis();

        //player2AxisHorizontal2.AxisName = "Joystick1Axis3";
        //player2AxisHorizontal2.value = Input.GetAxis(player1AxisHorizontal1.AxisName);

        //GameInput.PlayerInput player2 = new GameInput.PlayerInput(
        //    2,
        //    KeyCode.Joystick2Button1,
        //    KeyCode.Joystick2Button0,
        //    KeyCode.Joystick2Button7,
        //    KeyCode.Joystick2Button5,
        //    KeyCode.Joystick2Button2,
        //    player2AxisVertical1,
        //    player2AxisHorizontal1,
        //    player2AxisVertical2,
        //    player2AxisHorizontal2
        //    );

        #endregion

        gameInput = GameInput.LoadDefault();
    }

    


}
