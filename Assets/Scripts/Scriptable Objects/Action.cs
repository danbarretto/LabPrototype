using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Scriptable Objects/Action")]
public class Action : ScriptableObject {

    public new string name;
    public bool canHeat;
    
    public float heatTime;
    public List<Item> items;

}