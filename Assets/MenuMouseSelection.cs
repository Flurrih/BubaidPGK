using UnityEngine;
using System.Collections;

public class MenuMouseSelection : MonoBehaviour {

    public MenuController menu;
    public MenuController.MenuSelected selected;

	void OnMouseEnter()
    {
        
    }

    void OnMouseDown()
    {
        if (menu.selected == MenuController.MenuSelected.Play)
        {
            if (selected == MenuController.MenuSelected.Settings)
            {
                menu.GetComponent<Animator>().SetTrigger("Left");
            }
            if (selected == MenuController.MenuSelected.Exit)
            {
                menu.GetComponent<Animator>().SetTrigger("Right");
            }
        }

        if (menu.selected == MenuController.MenuSelected.Settings)
        {
            if (selected == MenuController.MenuSelected.Play)
            {
                menu.GetComponent<Animator>().SetTrigger("Right");
            }
        }

        if (menu.selected == MenuController.MenuSelected.Exit)
        {
            if (selected == MenuController.MenuSelected.Play)
            {
                menu.GetComponent<Animator>().SetTrigger("Left");
            }
        }

        if (menu.selected == MenuController.MenuSelected.Play && selected == menu.selected)
        {
            Debug.Log("Play");
            UnityEngine.SceneManagement.SceneManager.LoadScene("viking_arena");
        }
        if (menu.selected == MenuController.MenuSelected.Exit && selected == menu.selected)
        {
            Debug.Log("Exit");
            Application.Quit();
        }
        if (menu.selected == MenuController.MenuSelected.Settings && selected == menu.selected)
        {
            Debug.Log("Settings");
            menu.settings.SetActive(true);
        }
    }
}
