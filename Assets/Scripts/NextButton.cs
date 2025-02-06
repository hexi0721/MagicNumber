using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    
    public GameObject toggles;
    public GameObject HowToPlay;
    public GameObject wrongMsg;

    [HideInInspector] public TMP_Text NumberText;

    private void Start()
    {
        NumberText = GameObject.Find("Answer").GetComponent<TMP_Text>();
        NumberText.gameObject.SetActive(false);
    }

}
