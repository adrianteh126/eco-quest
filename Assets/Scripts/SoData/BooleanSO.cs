using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BooleanSO : ScriptableObject {
    [SerializeField]
    private bool _value;
    public bool Value {
        get { return _value; }
        set { _value = value; }
    }
}
