using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Item")]
public class Item : ScriptableObject {

    new public string name;
    public GameObject model;
    public int score;
    
    public bool isSafe, isContainer;
    public Material fillContainerMaterial;

}