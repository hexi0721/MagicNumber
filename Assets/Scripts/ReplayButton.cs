using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
{

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => { SceneManager.LoadScene("MainScene"); });

        gameObject.SetActive(false);
    }


}
