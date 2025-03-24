using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 教學父件 : MonoBehaviour , IPointerClickHandler
{
    
    int choosePath , index , firstlogin;
    Image 教學動畫進行時禁止其他UI動作;
    Animator animator;
    [SerializeField] List<Transform> child;

    [SerializeField] Button hintButton;
    

    public void SetUp(int index , int choosePath , Image 教學動畫進行時禁止其他UI動作 , int firstlogin)
    {
        this.index = index;
        this.choosePath = choosePath;
        this.教學動畫進行時禁止其他UI動作 = 教學動畫進行時禁止其他UI動作;
        this.firstlogin = firstlogin;
    }
    
    public void 動畫出現()
    {
        index = 4;
        animator.SetInteger("Path", 2);
        教學動畫進行時禁止其他UI動作.gameObject.SetActive(true);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Path", choosePath);

        child = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            child.Add(transform.GetChild(i));
        }

        if (firstlogin == 1)
        {
            教學動畫進行時禁止其他UI動作.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }


        Debug.Log(hintButton.GetComponent<RectTransform>().position);
        Debug.Log(GetComponent<RectTransform>().position);

    }

    public void AnimatorEndEvent()
    {
        PlayerPrefs.SetInt("firstLogin" , 1);
        教學動畫進行時禁止其他UI動作.gameObject.SetActive(false);
        gameObject.SetActive(false);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        child[index].gameObject.SetActive(false);
        index -= 1;

        if (index < 1)
        {
            index = 1;
            choosePath = 1;
            animator.SetInteger("Path", choosePath); // 執行消失動畫
        }

        child[index].gameObject.SetActive(true);

    }
}
