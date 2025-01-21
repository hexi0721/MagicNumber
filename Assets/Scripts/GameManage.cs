using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManage : MonoBehaviour 
{
    public List<GameObject> toggle;

    public static int index;
    public static float number;

    private void Start()
    {

        index = 0;
        number = 0;

    }

    private void Update()
    {
        

        for (int i = 0; i < toggle.Count; i++)
        {
            if (i == index)
            {
                toggle[i].gameObject.SetActive(true);
            }
            else
            {
                toggle[i].gameObject.SetActive(false);
            }
        }

    }


}
