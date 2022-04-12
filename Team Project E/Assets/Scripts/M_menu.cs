using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class M_menu : MonoBehaviour
{
    public event UnityAction layouts = null;
    public event UnityAction shows= null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClose()
    {
        layouts.Invoke();
        shows.Invoke();
        Destroy(this.gameObject);
        Time.timeScale = 1;
    }
}
