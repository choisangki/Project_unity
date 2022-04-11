using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton_L : MonoBehaviour , IPointerClickHandler
{
    public GameObject OptionMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject odj = Instantiate(Resources.Load("UI/Canvas_FirstMenu")) as GameObject;
        Destroy(OptionMenu);
    }
}
