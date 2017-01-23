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



    public enum MenuSelected
    {
        Play,
        Settings,
        Exit
    }

    public GameObject settings;

    public MenuSelected selected;

    private Animator animator;
    private AnimatorStateInfo animatorState;

    private bool settingsEntered;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MenuMove());
        settingsEntered = settings.activeSelf;
    }

    void Update()
    {

        if (Input.GetButton("Submit"))
        {
            Debug.Log("Submit");
        }
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        settingsEntered = settings.activeSelf;
        if (!settingsEntered)
        {
            if (!animator.isActiveAndEnabled)
            {
                animator.enabled = true;
                animator.Play(Const.SettingsAnim);
                StartCoroutine(MenuMove());
            }
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

            if (Input.GetButton(InputManager.gameInput.player1.Jump.ToString()) || Input.GetButton(InputManager.gameInput.player2.Jump.ToString()) || Input.GetButton("Submit"))
            {

                if (selected == MenuSelected.Play)
                {
                    Debug.Log("Play");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("viking_arena");
                }
                if (selected == MenuSelected.Exit)
                {
                    Debug.Log("Exit");
                    Application.Quit();
                }
                if (selected == MenuSelected.Settings)
                {
                    Debug.Log("Settings");
                    settings.SetActive(true);
                }
            }
        } else
        {
            StopCoroutine(MenuMove());
            animator.Stop();
            animator.enabled = false;
        }
        
    }

    IEnumerator MenuMove()
    {
        while(true)
        {
            if (Input.GetAxis(InputManager.gameInput.player1.AxisHorizontal1.AxisName) >= 0.75f || 
                Input.GetAxis(InputManager.gameInput.player2.AxisHorizontal1.AxisName) >= 0.75f ||
                Input.GetAxisRaw("Horizontal") > 0)
            {
                if (!animatorState.IsName(Const.ExitAnim))
                {
                    animator.SetTrigger(Const.Right);
                    yield return new WaitForSeconds(0.5f);
                }
            }

            if (Input.GetAxis(InputManager.gameInput.player1.AxisHorizontal1.AxisName) <= -0.75f ||
                Input.GetAxis(InputManager.gameInput.player2.AxisHorizontal1.AxisName) <= -0.75f ||
                Input.GetAxisRaw("Horizontal") < -0)
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
