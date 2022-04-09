using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    float hAxis;
    float vAxis;


    public Transform myPlayer;
    STATE myState = STATE.NONE;
    bool OnHide = false;

    Animator _Anim = null;
    Animator myAnim
    {
        get
        {
            if (_Anim == null) _Anim = GetComponentInChildren<Animator>();
            return _Anim;
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

        this.transform.Translate(pos * MoveSpeed * Time.deltaTime); // 이동  
    }

    public void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        
        switch(myState)
        {
            case STATE.CREATE:
                ChangeState(STATE.PLAY); // 생성후 Play STATE로 변경
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
                hAxis = Input.GetAxis("Horizontal");
                vAxis = Input.GetAxis("Vertical");
                Vector3 pos = new Vector3(hAxis, 0, vAxis).normalized;
                Moving(pos);
                break;
            case STATE.DEATH:
                break;
        }
    }

    public void Hiding()
    {
        if(OnHide == false)
        {
            if(Input.GetKeyDown(KeyCode.Space))   // 스페이스 바를 눌렀을 때 hiding 작동
            {


            }
        }

    }


}
