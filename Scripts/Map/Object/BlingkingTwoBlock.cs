using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlingkingTwoBlock : MonoBehaviour
{
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 1.2f;
    private float nextTime = 0.0f;

    private GameObject Block1;
    private GameObject Block2;



    // Start is called before the first frame update
    void Start()
    {
        Block1 = transform.Find("Block1").gameObject;
        Block2 = transform.Find("Block2").gameObject;


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
            Block1.SetActive(true);
            Block2.SetActive(true);

        }
        else if (vision == false)
        {
            Block1.SetActive(false);
            Block2.SetActive(false);

        }
    }
}
