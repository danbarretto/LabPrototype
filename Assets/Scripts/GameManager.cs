using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager instace;
    private void Awake() {
        if(instace != null){
            Debug.LogWarning("More than one instance of GameManager found!");
            return;
        }
        instace = this;

    }
    #endregion

    public string Fire1_P1, Fire2_P1, Horizontal_P1, Vertical_P1;
    public string Fire1_P2, Fire2_P2, Horizontal_P2, Vertical_P2;


    public int score = 0;
    /*public string Fire1_P3, Fire2_P3, Horizontal_P3, Vertical_P3;
    public string Fire1_P4, Fire2_P4, Horizontal_P4, Vertical_P4;*/


    public List<Formula> toDoFormulas;
    public GameObject formulaPanel;
    public Canvas canvas;
    private void Start() {
        var panel = Instantiate(formulaPanel);
        panel.GetComponent<FormulaController>().formula = toDoFormulas[0];
        panel.transform.SetParent(canvas.transform,false);
        toDoFormulas[0].panel = panel;
    }

}