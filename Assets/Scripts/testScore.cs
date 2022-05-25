using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScore : MonoBehaviour
{
    public GameMangement test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing the score
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Whats wrong");
            test.AmendScore();
        }
    }
}
