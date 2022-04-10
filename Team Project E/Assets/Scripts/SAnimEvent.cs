using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SAnimEvent : MonoBehaviour
{
    public event UnityAction StandUp = null;
    public void OnStandUp()
    {
        StandUp.Invoke();
    }
    
}
