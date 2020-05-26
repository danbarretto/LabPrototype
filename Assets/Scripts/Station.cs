using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : Interactable {

    public Action stationAction;

    override public void Interact() {
        List<Action> actions = player.GetComponentInChildren<Experiment>().actions;
        if (actions != null && stationAction && !actions.Contains(stationAction))
            actions.Add(stationAction);
    }

}