using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlingkingOneBlock : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 1.7f;
    private float nextTime = 0.0f;

    private GameObject Block;



    // Start is called before the first frame update
    void Start()
    {
        Block = transform.Find("Block").gameObject;
        
        vision = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTime >= TimeLimt)
        {
            if (vision == false)
            {
                vision = true;
                nextTime = 0;
            }
            else if (vision == true)
            {
                vision = false;
                nextTime = 0;
            }
        }
        else
        {
            nextTime += Time.deltaTime;
        }

        block();
    }

    void block()
    {
        if (vision == true)
        {
            Block.SetActive(true);

        }
        else if (vision == false)
        {
            Block.SetActive(false);

        }
    }
}
