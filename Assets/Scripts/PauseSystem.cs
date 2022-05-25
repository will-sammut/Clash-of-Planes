using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    //  This script will listen for the space keycode if pressed it pauses.
    //  if pressed again it resumes the code.
    //  This script was created via paired programming: Stephen McGuinness and Kyle.

    //reference to the scriptable object: game management
    public GameMangement gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.PauseToggle();
        }


    }
}
