using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class 教學父件 : MonoBehaviour , IPointerClickHandler
{
    
    int childCount , firstlogin;
    Image 教學動畫進行時禁止其他UI動作;

    [SerializeField] List<Transform> child;

    [SerializeField] Button hintButton;
    [SerializeField] float speed = 10f;


    public void SetUp(int childCount, Image 教學動畫進行時禁止其他UI動作 , int firstlogin)
    {
        this.childCount = childCount;
        this.教學動畫進行時禁止其他UI動作 = 教學動畫進行時禁止其他UI動作;
        this.firstlogin = firstlogin;
    }
    
    public void 動畫出現(int childCount)
    {
        this.childCount = childCount;

        教學動畫進行時禁止其他UI動作.gameObject.SetActive(true);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        GetComponent<RectTransform>().localPosition = Vector3.zero;
        /*
        GetComponent<RectTransform>().localScale = Vector3.one;

        Color color = GetComponent<Image>().color;
        color.a = 0.4f;
        GetComponent<Image>().color = color;
        */

    }
    
    private void Start()
    {


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

        
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        child[childCount].gameObject.SetActive(false);
        childCount -= 1;

        if (childCount < 1)
        {
            childCount = 1;
            child[childCount - 1].gameObject.SetActive(false);

            StartCoroutine(消失動畫());
        }

        child[childCount].gameObject.SetActive(true);

    }

    private IEnumerator 消失動畫()
    {

        RectTransform rectTransform = GetComponent<RectTransform>();
        float width = rectTransform.rect.width;
        float posX = rectTransform.localPosition.x;


        while (posX > -width) 
        {

            posX = rectTransform.localPosition.x - speed * Time.deltaTime;
            rectTransform.localPosition = new Vector3(posX , rectTransform.localPosition.y);

            if (posX <= -width)
            {
                posX = -width;
                rectTransform.localPosition = new Vector3(posX, rectTransform.localPosition.y);
            }


            yield return null;
        }


        AnimatorEndEvent();
    }

    private void AnimatorEndEvent()
    {
        PlayerPrefs.SetInt("firstLogin", 1);
        
        教學動畫進行時禁止其他UI動作.gameObject.SetActive(false);
        gameObject.SetActive(false);

    }


}
