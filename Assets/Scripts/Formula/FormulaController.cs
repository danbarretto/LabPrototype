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
    }


    private void Update() {
        if(timeLeft > 0f){
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }else{
            Debug.Log("Acabou!!!");
        }
    }

}