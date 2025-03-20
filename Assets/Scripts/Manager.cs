using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{

    public int index { get; private set; }
    public bool checkBoxisOn { get; set; }

    public Manager(int index, bool checkBoxisOn)
    {
        this.index = index;
        this.checkBoxisOn = checkBoxisOn;
    }




}
