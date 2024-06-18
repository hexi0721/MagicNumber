using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    
    public GameObject Images;
    public GameObject Sliders;
    public GameObject HowToPlay;
    
    public TMP_Text NumberText;

    float _alpha;
    public bool _confirm;
    


    private void Start()
    {
        _confirm = false;
        _alpha = 0;
    }

    private void Update()
    {
        if(_confirm && _alpha < 255f)
        {
            _alpha += 2f * Time.deltaTime;
            NumberText.color = new Color(NumberText.color.r, NumberText.color.b, NumberText.color.g, _alpha);
        }
        
    }

    


}
