using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Formula", menuName = "Scriptable Objects/Formula")]
public class Formula : ScriptableObject {

    public new string name;
    public int score;
    [Range(0f, 120f)]
    public float maxWaitTime;

    [SerializeField]
    public List<Action> actions;

    public GameObject panel;

}