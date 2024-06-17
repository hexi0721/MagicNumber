using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    public List<RectTransform> Image;
    public float speed;
    [SerializeField] int width , index ;
    [SerializeField] bool direction;
    [SerializeField] Vector2 mousePositionO , mousePositon;

    private void Start()
    {
        width = 1080;
        index = 0 ;
        direction = true; // T = right F = left;
        for (int i = 0;i < Image.Count; i++)
        {
            Image[i].anchoredPosition = new Vector2(width * i, 0);
        }

        mousePositionO = Vector2.zero;
        mousePositon = Vector2.zero;


    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            mousePositionO = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) 
        {
            mousePositon = Input.mousePosition;

            float PositionX = Mathf.Abs(mousePositon.x - mousePositionO.x);
            float s01 = Input.GetAxis("Mouse X");
            if (mousePositon.x < mousePositionO.x && s01 < 0f) // ©¹¥k
            {
                

                for (int i = 0; i < Image.Count; i++)
                {
                    Image[i].anchoredPosition = Vector2.Lerp(Image[i].anchoredPosition , new Vector2(Image[i].anchoredPosition.x - PositionX, 0) , speed*Time.deltaTime);
                    

                }


                    
                direction = true;

                
            }
            else if (mousePositon.x > mousePositionO.x && s01 > 0f) // ©¹¥ª
            {
                for (int i = 0; i < Image.Count; i++)
                {
                    Image[i].anchoredPosition = Vector2.Lerp(Image[i].anchoredPosition, new Vector2(Image[i].anchoredPosition.x + PositionX, 0), speed * Time.deltaTime);
                    

                }

                direction = false;
                
            }

        
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            if(direction == true && index != 5)
            {
                for (int i = 0; i < Image.Count; i++)
                {
                    Image[i].anchoredPosition = new Vector2(Image[i].anchoredPosition.x - width, 0);
                    

                }

                index += 1;
            }
            else if (direction == false && index != 0)
            {
                for (int i = 0; i < Image.Count; i++)
                {
                    Image[i].anchoredPosition = new Vector2(Image[i].anchoredPosition.x + width, 0);
                    
                }

                index -= 1;
            }
            


        }



    }
}
