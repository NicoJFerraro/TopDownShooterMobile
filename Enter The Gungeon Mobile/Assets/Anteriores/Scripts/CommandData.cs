using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandData
{
    public Console.TemplateMethod commmand;
    public string name;
    public string description;

    public override string ToString()
    {
        return "[" + name + "=>" + description + "]"; 
    }
}

