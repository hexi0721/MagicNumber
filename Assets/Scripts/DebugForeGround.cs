using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DebugForeGround : MonoBehaviour
{

    [SerializeField] Button 消除pref;
    [SerializeField] Text fpsText;

    private void Start()
    {
        消除pref.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteKey("firstLogin");
            Debug.Log("已消除firstLogin");
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
