using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{

    public LayerMask CrashMask;
    public float Downspeed = 2.0f;   // ����Ʈ �ٿ� ���ǵ�� 2.0f
    public float Duration = 0.5f;    // ������ ���ӽð��� 0.5f�ʷ� �س���


    public void OnTriggerEnter(Collider other) //�浹�� 
    {

        if ((CrashMask & (1 << other.gameObject.layer)) > 0)
        {
            SPlayer MSpeed = other.GetComponent<SPlayer>();

            MSpeed.SetSpeed(Downspeed, Duration);  // �÷��̾�� ������ ������ �ִ� Downspeed, Duration ���� �ѱ�
            Destroy(this.gameObject);
        }

    }
    /*
    IEnumerator DownSpeed(float t) // t=�ӵ������� ���ӽð� 
    {
        SPlayer MSpeed = GameObject.Find("Player").GetComponent<SPlayer>(); //�÷��̾� ��ũ��Ʈ ����

        MSpeed.MoveSpeed = 0.5f;

        yield return new WaitForSeconds(t); 

        MSpeed.MoveSpeed = 5f;

        Destroy(this.gameObject);
    }
    */
}
