using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeliverStation : Station {

    public Text scoreText;
    private Formula formulaFound;
    public override void Interact() {
        if (HasEqualFormula()) {
            GameManager.instace.score += formulaFound.score;
            scoreText.text =  "Score: "+ GameManager.instace.score;
            Destroy(formulaFound.panel);
            GameManager.instace.toDoFormulas.Remove(formulaFound);
            Destroy(player.GetComponent<PlayerController>().child.transform.parent);
        }
    }

    private bool HasEqualFormula() {
        Experiment exp = player.GetComponentInChildren<Experiment>();
        if (exp) {
            foreach (Formula f in GameManager.instace.toDoFormulas) {
                var cnt = new Dictionary<Action, int>();
                foreach (Action a in exp.actions) {
                    if (cnt.ContainsKey(a)) {
                        cnt[a]++;
                    } else {
                        cnt.Add(a, 1);
                    }
                }

                foreach (Action a2 in f.actions) {
                    if (cnt.ContainsKey(a2)) {
                        cnt[a2]--;
                    } else {
                        continue;
                    }
                }
                int count = 0;
                foreach (var c in cnt) {
                    if (c.Value == 0) {
                        count++;
                    }
                }

                if (count == cnt.Count) {
                    formulaFound = f;
                    return true;
                }
            }
        }
        return false;

    }

    private void Start() {
        scoreText.text = "Score: 0";
    }
}