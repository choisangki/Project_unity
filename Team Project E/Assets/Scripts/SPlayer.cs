using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    public float MoveSpeed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }


    public void Moving()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 pos = Vector3.right * h + Vector3.forward * v;
        pos.Normalize();

        this.transform.Translate(pos * MoveSpeed * Time.deltaTime);




    }
}
