using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValueBlock : AbstractCodeBlock
{
    [SerializeField] Droplet.Type myType;
    [SerializeField] int intValue;
    [SerializeField] float floatValue;
    [SerializeField] string stringValue;
    [SerializeField] bool boolValue;

    private void Awake()
    {
        if (myType == Droplet.Type.Int)
        {
            label.text += intValue.ToString();
        }
        else if (myType == Droplet.Type.Float)
        {
            label.text += floatValue.ToString();
        }
        else if (myType == Droplet.Type.String)
        {
            label.text += stringValue;
        }
        else
        {
            label.text += boolValue.ToString();
        }
    }

    public override void Evaluate<T>(T input, out string output)
    {
        if (myType == Droplet.Type.Int)
        {
            output = intValue.ToString();
        }
        else if (myType == Droplet.Type.Float)
        {
            output = floatValue.ToString();
        }
        else if (myType == Droplet.Type.String)
        {
            output = stringValue;
        }
        else
        {
            output = boolValue.ToString();
        }
    }
}
