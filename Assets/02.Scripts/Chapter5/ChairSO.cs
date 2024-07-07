using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chair Data", menuName = "Scriptable Object/Chair Data", order = int.MaxValue)]
public class ChairSO : ScriptableObject
{
    [SerializeField]
    private string chairName;
    public string ChairName { get { return chairName; } }
}
