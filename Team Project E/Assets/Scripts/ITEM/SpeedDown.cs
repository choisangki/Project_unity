using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{

    public LayerMask CrashMask;
    public float Downspeed = 2.0f;   // 디폴트 다운 스피드는 2.0f
    public float Duration = 0.5f;    // 디폴드 지속시간은 0.5f초로 해놓음


    public void OnTriggerEnter(Collider other) //충돌시 
    {

        if ((CrashMask & (1 << other.gameObject.layer)) > 0)
        {
            SPlayer MSpeed = other.GetComponent<SPlayer>();

            MSpeed.SetSpeed(Downspeed, Duration);  // 플레이어에게 본인이 가지고 있는 Downspeed, Duration 값을 넘김
            Destroy(this.gameObject);
        }

    }
    /*
    IEnumerator DownSpeed(float t) // t=속도감소의 지속시간 
    {
        SPlayer MSpeed = GameObject.Find("Player").GetComponent<SPlayer>(); //플레이어 스크립트 참조

        MSpeed.MoveSpeed = 0.5f;

        yield return new WaitForSeconds(t); 

        MSpeed.MoveSpeed = 5f;

        Destroy(this.gameObject);
    }
    */
}
