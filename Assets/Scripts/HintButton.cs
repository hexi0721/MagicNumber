using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{

    [SerializeField] GameObject HowToPlayImage;
    [SerializeField] bool ShowOrHide;

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HowToPlayHint);

        ShowOrHide = false; // show = true , hide = false
    }


    public void HowToPlayHint()
    {
        ShowOrHide = !ShowOrHide;
        HowToPlayImage.SetActive(ShowOrHide);

    }

}
