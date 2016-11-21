using UnityEngine;
using System.Collections;

public class GameModeController : MonoBehaviour {

    public GameObject[] collumns;
    public GameObject modeObject;
    float modeTimer = 0.0f;
    public float modeLength;

    enum ModeState { Activated, Deactivated, None};

    ModeState state;

    void Start()
    {
        state = ModeState.Deactivated;
    }
	
	// Update is called once per frame
	void Update () {

        if(SawModeIsActive() && state == ModeState.Deactivated)
        {
            modeObject.GetComponent<SawMode>().SetAction();
            state = ModeState.Activated;
        }

        if(state == ModeState.Activated)
        {
            modeTimer += Time.deltaTime;

            if(modeTimer >= modeLength)
            {
                foreach (GameObject x in collumns)
                {
                    x.GetComponent<CollumnController>().Deactivate();
                    modeObject.GetComponent<SawMode>().SetAction();
                    state = ModeState.Deactivated;
                }
                modeTimer = 0.0f;
            }
        }


    }


    bool SawModeIsActive()
    {
        foreach (GameObject x in collumns)
        {
            if (x.GetComponent<CollumnController>().GetActive() == false)
                return false;
        }
        return true;
    }
}
