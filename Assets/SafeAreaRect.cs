// From https://www.youtube.com/watch?v=PLQ4ywB13eg

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SafeAreaRect : MonoBehaviour
{
    private ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;
    private Rect currentSafeArea = new Rect();
    
    public Canvas canvas;
    private RectTransform panelSafeArea;
    
    // Start is called before the first frame update
    void Start()
    {
        panelSafeArea = GetComponent <RectTransform>();

        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;
        
        ApplySafeArea();
    }

    public void ApplySafeArea()
    {
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;
        
        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;
        
        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;
        
    }

    void Update()
    {
        if ((currentOrientation != Screen.orientation) || currentSafeArea != Screen.safeArea)
        {
            ApplySafeArea();
        }
    }
}
