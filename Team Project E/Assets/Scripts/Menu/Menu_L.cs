using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_L : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject odj = Instantiate(Resources.Load("UI/Canvas_FirstMenu")) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
