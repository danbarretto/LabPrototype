using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment : MonoBehaviour
{
    public List<Action> actions;
    public Interactable parentInteractable;
    

    private void Awake() {
        actions = new List<Action>();
    }
}
