using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCodeBlock : MonoBehaviour
{
    [SerializeField] protected TMPro.TMP_Text label;

    public abstract void Evaluate<T>(T input, out string output);
}
