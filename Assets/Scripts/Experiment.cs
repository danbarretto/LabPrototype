using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment : MonoBehaviour {
    public List<Action> actions;
    public Interactable parentInteractable;

    public float timeHeated;
    public bool isHeated;

    private void Awake() {
        actions = new List<Action>();
    }

    public void PlaceExperiment(Vector3 finalPos) {
        StartCoroutine(PlaceCoroutine(finalPos));
    }

    private IEnumerator PlaceCoroutine(Vector3 finalPos) {
        float moveDuration = 0.5f;
        float t = 0f;
        while (t < moveDuration) {
            t += Time.deltaTime;
            parentInteractable.transform.position = Vector3.Slerp(parentInteractable.transform.position, finalPos, t / moveDuration);
            yield return null;
        }
    }
}