using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;

    Image backgroundImage, handleImage;
    Color backgroundDefaultColor, handleDefaultColor;
    Toggle toggle;

    Vector2 handlePosition;

    void awake()
    {
        toggle = GetComponent <Toggle> ();
        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage= uiHandleRectTransform.parent.GetComponent <Image> ();
        handleImage = uiHandleRectTransform.GetComponent <Image> ();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if(toggle.isOn)
        {
            OnSwitch(true);
        }
    }

    void OnSwitch(bool on)
    {
        if(on)
        {
            uiHandleRectTransform.anchoredPosition= handlePosition * -1;
        }
        else
        {
            uiHandleRectTransform.anchoredPosition= handlePosition;
        }
    }
    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
    // Start is called before the first frame update

}
