using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public float Dmamge; 
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) //충돌시
    {
        if(other.gameObject.tag == "Untagged") //태그의 이름으로 판단
        {
           
            Destroy(this.gameObject);
        }
    }
}
