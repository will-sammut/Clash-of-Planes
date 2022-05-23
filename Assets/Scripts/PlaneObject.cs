using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlaneType
{
    Normal,
    Jet,
    Cargo,
    Commercial
}

[CreateAssetMenu(fileName = "Plane", menuName = "Scriptable Objects/Plane")]
public class PlaneObject : ScriptableObject
{
    public PlaneType type;
    public Sprite sprite;
    public float speed;
    public float size;
    //public string description;
}
