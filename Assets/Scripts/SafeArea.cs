using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SafeArea : MonoBehaviour
{


    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        Rect screenSafeArea = Screen.safeArea;

        Vector2 minVec2 = screenSafeArea.position;
        Vector2 maxVec2 = screenSafeArea.size + minVec2;

        minVec2.x /= Screen.width;
        minVec2.y /= Screen.height;
        maxVec2.x /= Screen.width;
        maxVec2.y /= Screen.height;



        GetComponent<RectTransform>().anchorMin = minVec2;
        GetComponent<RectTransform>().anchorMax = maxVec2;

    }

    



}
