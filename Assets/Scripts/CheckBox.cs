using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {  });
    }



}
