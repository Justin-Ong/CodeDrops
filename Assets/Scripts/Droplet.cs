using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public enum Type
    {
        Int,
        Float,
        String,
        Bool
    }

    private class DropletState
    {
        Type myType;

        int intValue { get; set; }
        float floatValue { get; set; }
        string stringValue { get; set; }
        bool boolValue { get; set; }

        public void SetType(Type type)
        {
            myType = type;
        }

        public string GetValue()
        {
            if (myType == Type.Int)
            {
                return intValue.ToString();
            }
            else if (myType == Type.Float)
            {
                return floatValue.ToString();
            }
            else if (myType == Type.String)
            {
                return stringValue;
            }
            else
            {
                return boolValue.ToString();
            }
        }

        public void UpdateValue(string input)
        {
            if (myType == Type.Int)
            {
                intValue = int.Parse(input);
            }
            else if (myType == Type.Float)
            {
                floatValue = float.Parse(input);
            }
            else if (myType == Type.String)
            {
                stringValue = input;
            }
            else
            {
                boolValue = bool.Parse(input);
            }
        }
    }

    [SerializeField] TMPro.TMP_Text label;
    DropletState state;

    private void Awake()
    {
        state = new DropletState();
        state.SetType(Type.Int);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AbstractCodeBlock codeBlock = collision.gameObject.GetComponent<AbstractCodeBlock>();
        UpdateDropletState(codeBlock);
    }

    private void UpdateDropletState(AbstractCodeBlock codeBlock)
    {
        codeBlock.Evaluate(state.GetValue(), out string result);
        state.UpdateValue(result);
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        label.text = state.GetValue();
    }
}
