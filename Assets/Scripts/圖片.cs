using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 圖片 : MonoBehaviour
{

    [SerializeField] int index;
    [SerializeField] Button CheckBox;

    public Manager manager;

    private void Start()
    {

        char lastChar = transform.name[transform.name.Length - 1];
        index = (int)char.GetNumericValue(lastChar);
        manager = new Manager(index, true);

        CheckBox.onClick.AddListener(() => { });
    }

    private void Update()
    {
        
        




    }


}
