using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Scriptable Objects/Action")]
public class Action : ScriptableObject {

    public new string name;
    public float actionTime;
    public List<Item> items;

}