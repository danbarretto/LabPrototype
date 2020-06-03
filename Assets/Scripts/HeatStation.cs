using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeatStation : Station {

    public Image timer;
    public bool expPlaced = false;
    public float totalTime = 0f;
    public override void Interact() {
        if (!expPlaced) {
            Experiment exp = player.GetComponentInChildren<Experiment>();
            expPlaced = true;
            totalTime = 0f;
            if (exp) {
                foreach (Action act in exp.actions) {
                    if (!act.canHeat)return;
                    totalTime += act.heatTime;
                }
            }
            exp.transform.parent = transform;
            exp.PlaceExperiment(new Vector3(
                transform.position.x + 1,
                transform.position.y + 1,
                transform.position.z - 1
            ));
            StartCoroutine(HeatUp(totalTime, exp));
            player.GetComponent<PlayerController>().child = null;
        } else if (expPlaced && !player.GetComponent<PlayerController>().child) {
            Experiment exp = GetComponentInChildren<Experiment>();
            exp.PlaceExperiment(player.GetComponent<PlayerController>().hands.position);
            exp.transform.SetParent(player);
            StopAllCoroutines();
            if (timer.fillAmount >= 1f) {
                base.Interact();
            }
            timer.fillAmount = 0f;
            player.GetComponent<PlayerController>().child = exp.parentInteractable;
            expPlaced = false;

        }
    }

    public IEnumerator HeatUp(float heatTime, Experiment exp) {
        float t = 0f;
        if (exp.timeHeated == 0f)
            timer.fillAmount = 0;
        else {
            timer.fillAmount = exp.timeHeated / heatTime;
            t = exp.timeHeated;
        }
        expPlaced = true;
        while (t < heatTime) {
            t += Time.deltaTime;
            exp.timeHeated += Time.deltaTime;
            timer.fillAmount = t / heatTime;
            yield return null;
        }

    }

}