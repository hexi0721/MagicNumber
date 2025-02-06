using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public void DisableAll() // on the NextButton GameObject
    {

        // 如果不在 1 ~ 63 之間

        if(GameManage.number < 1 || GameManage.number > 63)
        {
            GetComponent<NextButton>().wrongMsg.SetActive(true);
            return;
        }


        //

        GetComponent<NextButton>().toggles.SetActive(false);
        GetComponent<NextButton>().HowToPlay.SetActive(false);

        TMP_Text m_NumberText = GetComponent<NextButton>().NumberText;
        m_NumberText.gameObject.SetActive(true);
        m_NumberText.text = "您心中所想數字是" + GameManage.number;

        TMP_Text ButtonText = transform.GetChild(0).GetComponent<TMP_Text>();
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
