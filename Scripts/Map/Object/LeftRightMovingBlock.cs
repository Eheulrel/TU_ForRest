using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovingBlock : MonoBehaviour
{
    int block = 1;

    void Update()
    {
        if (transform.localPosition.x < -22.5f)
        {
            block = -1;
        }
        else if (transform.localPosition.x > -15.5f)
        {
            block = 1;
        }

        transform.Translate(Vector3.left * 2.0f * Time.deltaTime * block);
    }
}
