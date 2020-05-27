using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeatStation : Station {

    public Image timer;
    public bool expPlaced = false;
    public override void Interact() {
        if (!expPlaced) {
            Experiment exp = player.GetComponentInChildren<Experiment>();

            float totalTime = 0f;
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
            StartCoroutine(HeatUp(totalTime));
            player.GetComponent<PlayerController>().child = null;
        } else {
            Experiment exp = GetComponentInChildren<Experiment>();
                exp.transform.parent = player;
                exp.PlaceExperiment((player.forward * .8f) + player.position);
            if (timer.fillAmount == 1f) {
                base.Interact();
            }
            player.GetComponent<PlayerController>().child = exp.parentInteractable;
            expPlaced=false;
        }
    }

    public IEnumerator HeatUp(float heatTime) {
        float t = 0f;
        expPlaced = true;
        while (t < heatTime) {
            t += Time.deltaTime;
            timer.fillAmount = t / heatTime;
            yield return null;
        }
        
    }

}