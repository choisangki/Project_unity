using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{

   

    Coroutine DeBuff;
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other) //충돌시 
    {
        
        if (other.gameObject.tag == "Untagged") // 태그의 이름으로 판단
        {

            
                if (DeBuff != null)
                {
                    StopCoroutine((DeBuff));
                }
                DeBuff = StartCoroutine(DownSpeed(5)); 

            gameObject.GetComponent<SphereCollider>().enabled = false; 
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }

    IEnumerator DownSpeed(float t) // t=속도감소의 지속시간 
    {
        SPlayer MSpeed = GameObject.Find("Player").GetComponent<SPlayer>(); //플레이어 스크립트 참조

        MSpeed.MoveSpeed = 0.5f;

        yield return new WaitForSeconds(t); 

        MSpeed.MoveSpeed = 5f;

        Destroy(this.gameObject);
    }
} 
