using UnityEngine;
using System.Collections;

public class SawMode : MonoBehaviour {

    //public GameObject[] mapElements;
    //public GameObject[] sawWalls;
    public enum EventType
    {
        StartActiv,
        EndActiv,
        StartDeactiv,
        EndDeactiv,
        None
    }
    public enum GameMode
    {
        Regular,
        Saw,
        Busy
    }
    EventType state;
    GameMode gMode;
    float changeModeTimer = 3.0f;

    public GameObject platforms, sawWalls;
    
    
    void Start()
    {
        state = EventType.None;
        gMode = GameMode.Regular;

        platforms.GetComponent<Animator>().Stop();
        sawWalls.GetComponent<Animator>().Stop();
        sawWalls.SetActive(false);
    }

	void Update () {
        if(state == EventType.StartActiv)
        {
            Activate();
            gMode = GameMode.Busy;
        }
        if(state == EventType.EndActiv)
        {
            if (platforms.GetComponent<Animation>().isPlaying == false)
            {
                state = EventType.None;
                gMode = GameMode.Regular;
                sawWalls.SetActive(false);
            }
        }
        if(state == EventType.StartDeactiv)
        {
            Deactivate();
            gMode = GameMode.Busy;
        }
        if(state == EventType.EndDeactiv)
        {
            
            if (platforms.GetComponent<Animation>().isPlaying == false)
            {
                state = EventType.None;
                gMode = GameMode.Saw;
            }
        }
        if(state == EventType.None)
        {
            changeModeTimer = 50.0f;
        }
	}

    public void Activate()
    {
        //foreach (GameObject x in mapElements)
        // {
        //if(changeModeTimer >= 0)
        //{
        //    float newPos = x.transform.position.y + 0.02f;
        //    x.transform.position = new Vector3(x.transform.position.x, newPos, x.transform.position.z);
        //    changeModeTimer -= Time.deltaTime;
        //}
        //}
        if (gMode != GameMode.Busy)
        {
            HideSaws();
            platforms.GetComponent<Animation>().Play("PlatformAnimationUp");
            gMode = GameMode.Busy;
            state = EventType.EndActiv;
        }

        //if (changeModeTimer < 0)
        //    state = EventType.EndActiv;
    }

    public void Deactivate()
    {
        //foreach (GameObject x in mapElements)
        //{
        //    if (changeModeTimer >= 0)
        //    {
        //        float newPos = x.transform.position.y - 0.02f;
        //        x.transform.position = new Vector3(x.transform.position.x, newPos, x.transform.position.z);
        //        changeModeTimer -= Time.deltaTime;
        //    }
        //}
        if (gMode != GameMode.Busy)
        {
            ShowSaws();
            platforms.GetComponent<Animation>().Play("PlatformAnimation");
            gMode = GameMode.Busy;
            state = EventType.EndDeactiv;
        }
        //if (changeModeTimer < 0)
        //    state = EventType.EndDeactiv;
    }

    public void SetAction()
    {
        if (gMode == GameMode.Regular)
            state = EventType.StartDeactiv;
        else if (gMode == GameMode.Saw)
            state = EventType.StartActiv;
    }

    public void ShowSaws()
    {
        sawWalls.SetActive(true);
        sawWalls.GetComponent<Animation>().Play("SawWallsAnimUp");
    }
    public void HideSaws()
    {
        sawWalls.GetComponent<Animation>().Play("SawWallsAnim");
    }
}
