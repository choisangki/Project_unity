using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class M_bt : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TMPro.TMP_Text mytext;
    public void OnPointerDown(PointerEventData eventData)
    {
        mytext.text = "<#000000ff>�޴� ������</color>";
        mytext.GetComponent<RectTransform>().anchoredPosition += new Vector2(0.0f, -5.0f);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        mytext.text = "<#ffffffff>�޴� ������</color>";
        mytext.GetComponent<RectTransform>().anchoredPosition += new Vector2(0.0f, 5.0f);
    }

}
