using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    private static class Const {
        public const string PlayAnim = "menu_play_idle";
        public const string SettingsAnim = "menu_settings_idle";
        public const string ExitAnim = "menu_exit_idle";
        public const string Right = "Right";
        public const string Left = "Left";
    }


    private enum MenuSelected
    {
        Play,
        Settings,
        Exit
    }

    private MenuSelected selected;

    private Animator animator;
    private AnimatorStateInfo animatorState;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MenuMove());
    }

    void Update()
    {
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName(Const.PlayAnim))
        {
            selected = MenuSelected.Play;
        }
        else if (animatorState.IsName(Const.SettingsAnim))
        {
            selected = MenuSelected.Settings;
        }
        else if (animatorState.IsName(Const.ExitAnim))
        {
            selected = MenuSelected.Exit;
        }

        if (Input.GetButton(InputManager.gameInput.player1.Jump.ToString()) || Input.GetButton(InputManager.gameInput.player2.Jump.ToString()))
        {
            
            if(selected == MenuSelected.Play)
            {
                Debug.Log("Play");
                UnityEngine.SceneManagement.SceneManager.LoadScene("viking_arena");
            }
            if(selected == MenuSelected.Exit)
            {
                Debug.Log("Exit");
                Application.Quit();
            }
            if(selected == MenuSelected.Settings)
            {
                Debug.Log("Settings");
            }
        }
    }

    IEnumerator MenuMove()
    {
        while(true)
        {
            if (Input.GetAxis(InputManager.gameInput.player1.AxisHorizontal1.AxisName) >= 0.75f || Input.GetAxis(InputManager.gameInput.player2.AxisHorizontal1.AxisName) >= 0.75f)
            {
                if (!animatorState.IsName(Const.ExitAnim))
                {
                    animator.SetTrigger(Const.Right);
                    yield return new WaitForSeconds(0.5f);
                }
            }

            if (Input.GetAxis(InputManager.gameInput.player1.AxisHorizontal1.AxisName) <= -0.75f || Input.GetAxis(InputManager.gameInput.player2.AxisHorizontal1.AxisName) <= -0.75f)
            {
                if (!animatorState.IsName(Const.SettingsAnim))
                {
                    animator.SetTrigger(Const.Left);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            yield return null;
        }
    }
	    
}
