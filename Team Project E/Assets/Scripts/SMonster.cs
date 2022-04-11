using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SMonster : MonoBehaviour
{
    public STATE myState = STATE.NONE;
    Coroutine MoveRoutine = null;
    Coroutine RotRoutine = null;
    public SAIperception myPerception;
    NavMeshAgent myNav;

    public float MoveSpeed = 1.5f;
    public float RotSpeed = 360.0f;

    public enum STATE
    {
        NONE, CREATE, MOVE, FOLLOW , DEATH
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(STATE.CREATE);
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }


    public void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;

        switch (myState)
        {
            case STATE.CREATE:
                myNav = this.GetComponent<NavMeshAgent>();
                ChangeState(STATE.MOVE); // ������ Play STATE�� ����
                break;
            case STATE.MOVE:
                break;
            case STATE.FOLLOW:
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
            case STATE.MOVE:


                float Dist = Random.Range(5.0f, 7.0f);

                if (myPerception.myEnemyList.Count > 0)
                    FindTarget(myPerception.myEnemyList[0]);

                MoveAround(Dist);
                
                break;
            case STATE.FOLLOW:
                if (myPerception.myEnemyList.Count == 0)
                {
                    myNav.isStopped = true;
                    ChangeState(STATE.MOVE);
                }
                else
                {
                    myNav.isStopped = false;
                    myNav.SetDestination(myPerception.myEnemyList[0].transform.position);
                }
                break;
            case STATE.DEATH:
                break;
        }
    }

    public void MoveAround(float Dist)   // ������ �������� ��ȸ�Ѵ�
    {
        if (RotRoutine == null&& MoveRoutine == null )
            RotRoutine = StartCoroutine(Rotating());

        if (MoveRoutine != null) return;
        MoveRoutine = StartCoroutine(Moving(Dist));
    }



    IEnumerator Moving(float Dist)
    {
        // ȸ�� ���Ҷ����� ���

        while (Dist > 0.0f)   //move�����϶� ��� �͸����� �ϸ鼭 �̵�
        {
            if (myState == STATE.FOLLOW) break;
            
            float delta = MoveSpeed * Time.deltaTime;
            if (delta > Dist)
                delta = Dist;

            this.transform.position += this.transform.forward * delta;
            Dist -= delta;
            yield return null;
        }
        MoveRoutine = null;
        
         // ��ƾ�� ������ 3�� ���
    }
    public void FindTarget(GameObject Target)   // �÷��̾ ã�� �ٴѴ�.
    {
        if (Target == null) return;

        Vector3 pos = (Target.transform.position - this.transform.position).normalized;

        float Angle = Mathf.Acos(Vector3.Dot(this.transform.forward, pos)) * 180.0f/Mathf.PI; // �÷��̾�� ���� ���� ���� ���Ϳ� ������ forward ���ͻ����� ���� ����
        // ����μ� 30�� �̳��̸� �߰��ϵ��� ����� �ξ���
        /*
        if (Vector3.Dot(this.transform.right,pos) < 0.0f)
        {
            FindAngle -= 360.0f;
        }
        */


        if(Angle<30.0f && !Target.GetComponent<SPlayer>().OnHide)  // �ޱ��� -30 ~ 30�� ������ ��, �÷��̾ �����ʾ��� ��
        {
            ChangeState(STATE.FOLLOW); // ���¸� FOLLOW ���·� ����
        }

    }

    /*
    public void FollowTarget()
    {
        if(MoveRoutine != null) StopCoroutine(MoveRoutine);
        MoveRoutine = StartCoroutine(Following());

        if(RotRoutine != null) StopCoroutine(RotRoutine);
        RotRoutine = StartCoroutine(Rotating());

    }
    */

    IEnumerator Following()
    {
        while(myState == STATE.FOLLOW)  // FOLLOW ������ �� ��� ����
        {
            if (myPerception.myEnemyList.Count == 0) break;

            float delta = MoveSpeed * Time.deltaTime;
            this.transform.position += this.transform.forward * delta;
            yield return null;
        }

        MoveRoutine = null;
    }
    
    IEnumerator Rotating()
    {

        float RotAngle = Random.Range(0.0f, 180.0f);
        float Dir = 1.0f;
        if (RotAngle > 180.0f)
            Dir = -1.0f;

        while (RotAngle > 0)  //  ���ƾ� �� ������ ���� ���� ��
        {
            if (myState == STATE.FOLLOW) break;

            float delta = RotSpeed * Time.deltaTime;

            if(RotAngle < delta)
            {
                delta = RotAngle;
            }

            this.transform.Rotate(Vector3.up, delta * Dir , Space.World);
            RotAngle -= delta;

            yield return null;
        }
        RotRoutine = null;
    }
}
