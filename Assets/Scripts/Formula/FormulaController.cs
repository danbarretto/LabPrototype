using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormulaController : MonoBehaviour {

    public Image timerBar;
    public float maxTime;
    public float timeLeft;
    public Formula formula;
    
    [SerializeField]
    private Text formulaName;

    private void Start() {
        maxTime = formula.maxWaitTime;
        timeLeft = maxTime;
        formulaName.text = formula.name;
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown() {
        while(timeLeft > 0f){
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            yield return null;
        }
        Destroy(gameObject);
    }

}