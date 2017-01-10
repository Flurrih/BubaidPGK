using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeybindController : MonoBehaviour {

    enum State
    {
        Free,
        WaitingForKey
    }

    [SerializeField]
    private Text jumpValue1, jumpValue2,
        dashValue1, dashValue2,
        kickValue1, kickValue2,
        releaseValue1, releaseValue2,
        skillValue1, skillValue2,
        plh1, plh2,
        plv1, plv2,
        blh1, blh2,
        blv1, blv2;

    private KeyCode changedValue;
    private State state;
	
	void Start () {
        Init();
        state = State.Free;
    }

    void Init()
    {
        jumpValue1.text = InputManager.gameInput.player1.Jump.ToString();
        jumpValue2.text = InputManager.gameInput.player2.Jump.ToString();
        dashValue1.text = InputManager.gameInput.player1.Dash.ToString();
        dashValue2.text = InputManager.gameInput.player2.Dash.ToString();
        kickValue1.text = InputManager.gameInput.player1.Kick.ToString();
        kickValue2.text = InputManager.gameInput.player2.Kick.ToString();
        releaseValue1.text = InputManager.gameInput.player1.Release.ToString();
        releaseValue2.text = InputManager.gameInput.player2.Release.ToString();
        skillValue1.text = InputManager.gameInput.player1.Skill.ToString();
        skillValue2.text = InputManager.gameInput.player2.Skill.ToString();
        plh1.text = InputManager.gameInput.player1.AxisHorizontal1.AxisName;
        plh2.text = InputManager.gameInput.player2.AxisHorizontal1.AxisName;
        plv1.text = InputManager.gameInput.player1.AxisVertical1.AxisName;
        plv2.text = InputManager.gameInput.player2.AxisVertical1.AxisName;
        blh1.text = InputManager.gameInput.player1.AxisHorizontal2.AxisName;
        blh2.text = InputManager.gameInput.player2.AxisHorizontal2.AxisName;
        blv1.text = InputManager.gameInput.player1.AxisVertical2.AxisName;
        blv2.text = InputManager.gameInput.player2.AxisVertical2.AxisName;
    }

    public void OnClick(Text button)
    {
        if (state == State.Free)
        {
            button.fontStyle = FontStyle.Italic;
            state = State.WaitingForKey;
            StartCoroutine(Keybind(button));
        }
    }

    IEnumerator Keybind(Text button)
    {
        while (true)
        {
            changedValue = KeyCode.ScrollLock;
            if (button.rectTransform.parent.name.Contains("1"))
            {
                if(button.rectTransform.parent.name.Contains("Jump") || button.rectTransform.parent.name.Contains("Dash") || button.rectTransform.parent.name.Contains("Skill") || button.rectTransform.parent.name.Contains("Release") || button.rectTransform.parent.name.Contains("Kick"))
                {
                    changedValue = InputManager.getJoystick1Button();
                }
                else
                {
                    changedValue = KeyCode.ScrollLock;
                }
            }
            if (button.rectTransform.parent.name.Contains("2"))
            {
                if (button.rectTransform.parent.name.Contains("Jump") || button.rectTransform.parent.name.Contains("Dash") || button.rectTransform.parent.name.Contains("Skill") || button.rectTransform.parent.name.Contains("Release") || button.rectTransform.parent.name.Contains("Kick"))
                {
                    changedValue = InputManager.getJoystick2Button();
                }
                else
                {
                    changedValue = KeyCode.ScrollLock;
                }
            }
            if (changedValue != KeyCode.ScrollLock)
            {
                if (button == jumpValue1)
                    InputManager.gameInput.player1.Jump = changedValue;
                if (button == jumpValue2)
                    InputManager.gameInput.player2.Jump = changedValue;

                if (button == dashValue1)
                    InputManager.gameInput.player1.Dash = changedValue;
                if (button == dashValue2)
                    InputManager.gameInput.player2.Dash = changedValue;

                if (button == kickValue1)
                    InputManager.gameInput.player1.Kick = changedValue;
                if (button == kickValue2)
                    InputManager.gameInput.player2.Kick = changedValue;

                if (button == releaseValue1)
                    InputManager.gameInput.player1.Release = changedValue;
                if (button == releaseValue2)
                    InputManager.gameInput.player2.Release = changedValue;

                if (button == skillValue1)
                    InputManager.gameInput.player1.Skill = changedValue;
                if (button == skillValue2)
                    InputManager.gameInput.player2.Skill = changedValue;

                GameInput.Save(InputManager.gameInput, "GameInput.xml");
                Init();
                state = State.Free;
                button.fontStyle = FontStyle.Normal;
                StopAllCoroutines();
            }
            yield return null;
        }
    }
}
