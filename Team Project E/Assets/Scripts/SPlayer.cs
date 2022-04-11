using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SPlayer : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    float OriginMoveSpeed = 5.0f;

    float hAxis;
    float vAxis;

    public float Hp = 100.0f;  // player HP

    public Transform myPlayer;
    STATE myState = STATE.NONE;
    public bool OnHide = false;

    Animator _Anim = null;
    Animator myAnim
    {
        get
        {
            if (_Anim == null) _Anim = GetComponentInChildren<Animator>();
            return _Anim;
        }
    }
    SAnimEvent _animEvent = null;
    SAnimEvent myAnimEvent
    {
        get
        {
            if (_animEvent == null)
            {
                _animEvent = this.GetComponentInChildren<SAnimEvent>();
            }
            return _animEvent;
        }
    }

    public enum STATE
    {
        NONE, CREATE, PLAY, DEATH
    }


    void Start()
    {
        ChangeState(STATE.CREATE);
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }


    public void Moving(Vector3 pos)
    {

        myAnim.SetBool("IsWalk", pos != Vector3.zero);
        myPlayer.LookAt(myPlayer.transform.position + pos);

        this.transform.Translate(pos * MoveSpeed * Time.deltaTime); // �̵�  
    }

    public void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        
        switch(myState)
        {
            case STATE.CREATE:
                myAnimEvent.StandUp += () => OnHide = false;  // ���� ���� �����ǵ��� �ϴ� delegate ����
                ChangeState(STATE.PLAY); // ������ Play STATE�� ����
                break;
            case STATE.PLAY:
                
                break;
            case STATE.DEATH:
                break;
        }
    }

    public void StateProcess()
    {

        switch (myState)
        {
            case STATE.CREATE:
                break;
            case STATE.PLAY:

                if (!OnHide)  // ���� ���°� �ƴҶ��� �̵� ����
                {
                    hAxis = Input.GetAxis("Horizontal");
                    vAxis = Input.GetAxis("Vertical");
                    Vector3 pos = new Vector3(hAxis, 0, vAxis).normalized;
                    Moving(pos);
                }

                if(Input.GetKeyDown(KeyCode.Space))
                Hiding();

                break;
            case STATE.DEATH:
                break;
        }
    }

    public void Hiding()
    {
        if (OnHide == false)  // ���� ���� ��� ���´�
        {
            myAnim.SetTrigger("Hiding");  // Hiding �ִϸ��̼� ����
            OnHide = true;
        }
        else
        {
            myAnim.SetTrigger("StandUp");
        }

    }

    IEnumerator SpeedDown(float speed, float time)
    {
        if (MoveSpeed > speed)  // ���� ������ ������� ���� �� �ֵ��� �ϱ� ���� ����
        {
            MoveSpeed = speed;
        }
        yield return new WaitForSeconds(time);
        MoveSpeed = OriginMoveSpeed;
    }

    public void SetSpeed(float speed, float time)
    {
        StartCoroutine(SpeedDown(speed, time));
    }


}
