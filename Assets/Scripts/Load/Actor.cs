using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    //El contenedor individual que contendrá el nombre del objeto y su ubicación.
    public ActorData data = new ActorData();
}

[Serializable]
public class ActorData
{
    public string name;
    public Vector3 pos;
}