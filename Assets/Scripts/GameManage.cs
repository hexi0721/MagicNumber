using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public Camera Cam;

    public List<RectTransform> Images;
    public List<GameObject> Sliders;
    
    [SerializeField] int width ;
    [SerializeField] bool direction;
    
    float _offset;
    public static int index;


    private void Start()
    {
        width = 1080;
        index = 0;
        _offset = 0;
        direction = true; // T = right F = left;
        for (int i = 0;i < Images.Count; i++)
        {
            Images[i].anchoredPosition = new Vector2(width * i, 0);
        }
        

    }

    private void Update()
    {
        

        for (int i = 0; i < Sliders.Count; i++)
        {
            if (i == index)
            {
                Sliders[i].gameObject.SetActive(true);
            }
            else
            {
                Sliders[i].gameObject.SetActive(false);
            }
        }


        RaycastHit2D hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero , Mathf.Infinity);

        if(!hit)
        {
            MouseButton1();
            MouseButton1Up();
        }



    }


    void MouseButton1()
    {
        if (Input.GetMouseButton(0))
        {

            float mouseX = Input.GetAxis("Mouse X");
            if (mouseX < 0f && index != 5) // 往右
            {


                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i].Translate(Vector2.right * mouseX * Time.deltaTime);
                }



                direction = true;


            }
            else if (mouseX > 0f && index != 0) // 往左
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i].Translate(Vector2.right * mouseX * Time.deltaTime);
                }

                direction = false;

            }


        }
    }

    void MouseButton1Up()
    {

        if (Input.GetMouseButtonUp(0))
        {

            _offset = Images[index].anchoredPosition.x;

            if (direction == true && index != 5) // 往右
            {


                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i].anchoredPosition = new Vector2(Images[i].anchoredPosition.x - width - _offset, 0);
                }

                index += 1;
            }
            else if (direction == false && index != 0) // 往左
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i].anchoredPosition = new Vector2(Images[i].anchoredPosition.x + width - _offset, 0);

                }

                index -= 1;
            }



        }

    }

}
