using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DebugForeGround : MonoBehaviour
{

    [SerializeField] Button ����pref;
    [SerializeField] Text fpsText;

    private void Start()
    {
        ����pref.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteKey("firstLogin");
            Debug.Log("�w����firstLogin");
        });


    }

    private void Update()
    {

        float fps = 1.0f / Time.deltaTime;

        if (fpsText != null)
        {
            fpsText.text = $"FPS : {Mathf.RoundToInt(fps)}";
        }
    }

}
