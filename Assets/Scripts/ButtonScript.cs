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

        // �p�G���b 1 ~ 63 ����

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
        m_NumberText.text = "�z�ߤ��ҷQ�Ʀr�O" + GameManage.number;

        TMP_Text ButtonText = transform.GetChild(0).GetComponent<TMP_Text>();
        ButtonText.text = "�A�դ@��";

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
