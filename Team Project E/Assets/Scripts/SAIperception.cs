using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAIperception : MonoBehaviour
{
    public LayerMask myEnemyMask;
    public SMonster myMonster;
    public List<GameObject> myEnemyList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if((myEnemyMask & (1 << other.gameObject.layer)) != 0 )
        {
            myEnemyList.Add(other.gameObject); // 나중에 플레이어에게 심박수 시스템 작동시키기 위해 게임 오브젝트 취해뒀음
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        myEnemyList.Remove(other.gameObject); // 범위에서 빠져나가면 리스트에서 사라짐
    }

}
