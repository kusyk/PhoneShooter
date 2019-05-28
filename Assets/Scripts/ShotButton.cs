using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShotButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    public static bool isPressed = false;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.75f);
    }
}
