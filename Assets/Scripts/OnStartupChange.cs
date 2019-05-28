using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartupChange : MonoBehaviour {

    public startupStates startupState = startupStates.none;

	void Awake () {
        switch (startupState)
        {
            case startupStates.none:
                break;
            case startupStates.deactive:
                gameObject.SetActive(false);
                break;
            case startupStates.destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public enum startupStates
    {
        none,
        deactive,
        destroy,          
    };
}
