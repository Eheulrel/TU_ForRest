using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownblock : MonoBehaviour
{
    int block = 1;

    void Update()
    {
        if (transform.localPosition.y > -67f)
        {
            block = -1;
        }
        else if (transform.localPosition.y < -72.8f)
        {
            block = 1;
        }

        transform.Translate(Vector3.up * 2.0f * Time.deltaTime * block);
    }
} 

