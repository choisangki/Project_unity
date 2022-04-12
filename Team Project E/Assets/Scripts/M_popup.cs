using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class M_popup : MonoBehaviour
{
    public GameObject layout;
    public event UnityAction showing = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        Time.timeScale = 0;
        showing.Invoke();
        layout.SetActive(true);
        GameObject obj = Instantiate(Resources.Load("UI/M_Menu"), this.transform) as GameObject;
        obj.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);
        obj.GetComponent<M_menu>().layouts += () => layout.SetActive(false);
        obj.GetComponent<M_menu>().shows += showing;
    }
}
