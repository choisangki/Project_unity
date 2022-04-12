using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_ui : MonoBehaviour
{
    bool show = true;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<M_popup>().showing += () =>
        {
            if (show)
            {
                show = false;
            }
            else
            {
                show = true;
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (show)
            {
                this.GetComponentInChildren<M_popup>().Open();
                
            }
            else
            {
                this.GetComponentInChildren<M_menu>().OnClose();
            }
        }   
    }
}
