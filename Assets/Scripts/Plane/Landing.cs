using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Landing : MonoBehaviour
{
    private bool landing = false;
    public UnityEvent onLand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (landing)
        {
            Trigger();
            Destroy(gameObject);
        }
    }

    public void LandPlane()
    {
        landing = true;
    }

    private void Trigger() => onLand.Invoke();
}
