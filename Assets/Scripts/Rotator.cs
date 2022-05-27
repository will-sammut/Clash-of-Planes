using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] int speed = 500;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
