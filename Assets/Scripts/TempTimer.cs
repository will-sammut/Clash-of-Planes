using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempTimer : MonoBehaviour
{
    public UnityEvent onTimerFire;

    [SerializeField] private float time;
    [SerializeField] private float repeatRate;

    void Start()
    {
        if (onTimerFire == null) onTimerFire = new UnityEvent();
        InvokeRepeating(nameof(Trigger), time, repeatRate);
    }

    private void Trigger() => onTimerFire.Invoke();
}
