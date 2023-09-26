using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Boxes : ScriptableObject
{
    public GameObject BoxType;
    public int HP;
    public bool LevelBox;
}
