using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public void DisableAll()
    {


        GetComponent<NextButton>().Images.SetActive(false);
        GetComponent<NextButton>().Sliders.SetActive(false);
        GetComponent<NextButton>().HowToPlay.SetActive(false);

        GetComponent<NextButton>()._confirm = true;

        

        TMP_Text ButtonText = this.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        ButtonText.text = "再試一次";

        Button button = GetComponent<Button>();
        button.onClick.RemoveListener(DisableAll);
        button.onClick.AddListener(() => Init());

    }

    public void Init()
    {
        SceneManager.LoadScene(0);
    }


    public void HowToPlayHint()
    {
        GetComponent<HintButton>().ShowOrHide = !GetComponent<HintButton>().ShowOrHide;

        if(GetComponent<HintButton>().ShowOrHide)
        {
            GetComponent<HintButton>().HowToPlayImage.SetActive(true);
        }
        else
        {
            GetComponent<HintButton>().HowToPlayImage.SetActive(false);
        }
        
    }
}
