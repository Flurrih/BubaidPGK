using UnityEngine;
using System.Collections;

public class SawMode : MonoBehaviour {

    public GameObject[] mapElements;
    public GameObject[] sawWalls;
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
    
    void Start()
    {
        state = EventType.None;
        gMode = GameMode.Regular;
    }

	void Update () {
        if(state == EventType.StartActiv)
        {
            HideSaws();
            Activate();
            gMode = GameMode.Busy;
        }
        if(state == EventType.EndActiv)
        {
            state = EventType.None;
            gMode = GameMode.Regular;
            changeModeTimer = 50.0f;
        }
        if(state == EventType.StartDeactiv)
        {
            Deactivate();
            gMode = GameMode.Busy;
        }
        if(state == EventType.EndDeactiv)
        {
            state = EventType.None;
            gMode = GameMode.Saw;
            changeModeTimer = 50.0f;
            ShowSaws();
        }
        if(state == EventType.None)
        {
            changeModeTimer = 50.0f;
        }
	}

    public void Activate()
    {
        foreach (GameObject x in mapElements)
        {
            if(changeModeTimer >= 0)
            {
                float newPos = x.transform.position.y + 0.02f;
                x.transform.position = new Vector3(x.transform.position.x, newPos, x.transform.position.z);
                changeModeTimer -= Time.deltaTime;
            }

        }
        if (changeModeTimer < 0)
            state = EventType.EndActiv;
    }

    public void Deactivate()
    {
        foreach (GameObject x in mapElements)
        {
            if (changeModeTimer >= 0)
            {
                float newPos = x.transform.position.y - 0.02f;
                x.transform.position = new Vector3(x.transform.position.x, newPos, x.transform.position.z);
                changeModeTimer -= Time.deltaTime;
            }
        }
        if (changeModeTimer < 0)
            state = EventType.EndDeactiv;
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
        foreach (GameObject x in sawWalls)
        {
            x.SetActive(true);
        }
    }
    public void HideSaws()
    {
        foreach (GameObject x in sawWalls)
        {
            x.SetActive(false);
        }
    }
}
