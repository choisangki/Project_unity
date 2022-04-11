using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionButton_L : MonoBehaviour , IPointerClickHandler
{
    public GameObject FirstMenu;
   
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
        GameObject odj = Instantiate(Resources.Load("UI/Canvas_OptionMenu")) as GameObject;
        Destroy(FirstMenu);
    }



}
