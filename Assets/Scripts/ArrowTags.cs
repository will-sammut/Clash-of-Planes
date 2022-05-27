using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTags : MonoBehaviour
{
    public List<string> tags = new();

    public bool SameTags(string otherTag)
    {
        foreach (string tag in tags)
        {
            if (tag == otherTag)
            {
                return true;
            }
        }
        return false;
    }
}
