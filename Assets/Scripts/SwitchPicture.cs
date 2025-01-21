using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Image;

public class SwitchPicture : MonoBehaviour , IPointerDownHandler, IPointerUpHandler , IDragHandler
{

    [SerializeField] float origin ;

    Vector2 startPos , lastPointerPosition; // 記錄上一次的滑鼠或觸控位置

    [SerializeField] int width;
    [SerializeField] bool _action;

    private void Start()
    {
        origin = GetComponent<RectTransform>().anchoredPosition.x;
        width = 1080;

    }

    void Update()
    {
        
        if (_action)
        {
            if(origin > 3000f)
            {
                origin -= width;
            }
            else if (origin < -3000f)
            {
                origin += width;
            }


            GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Lerp(GetComponent<RectTransform>().anchoredPosition.x, origin, 8 * Time.deltaTime), 0);
            if(Mathf.Abs(GetComponent<RectTransform>().anchoredPosition.x - origin) <  0.2f)
            {
                _action = false;
            }
        }
        
    }

    #region 事件

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_action)
        {
            return;
        }
        lastPointerPosition = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_action)
        {
            return;
        }

        Vector2 currentPointerPosition = eventData.position;
        Vector2 delta = currentPointerPosition - lastPointerPosition;

        
        float rotationAmount = delta.x * 0.2f;
        transform.Translate(Vector2.right * rotationAmount * Time.deltaTime);

        // 更新最後的滑鼠位置
        lastPointerPosition = currentPointerPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_action)
        {
            return;
        }

        if (startPos.x < eventData.position.x) // 手往右滑 
        {
            
            if(GameManage.index != 0)
            {
                GameManage.index -= 1;
            }
            

            origin += width;
            _action = true;
        }
        else if (startPos.x > eventData.position.x) // 手往左滑
        {

            if (GameManage.index != 5)
            {
                GameManage.index += 1;
            }
            

            origin -= width;
            _action = true;
        }

    }

    #endregion
}
