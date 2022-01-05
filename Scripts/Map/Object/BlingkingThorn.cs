using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlingkingThorn : MonoBehaviour
{
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 2.5f;
    private float nextTime = 0.0f;

    private GameObject At;
    private GameObject Bt;


    // Start is called before the first frame update
    void Start()
    {
        At = transform.Find("At").gameObject;       
        Bt = transform.Find("Bt").gameObject;       

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
            At.SetActive(true);            
            Bt.SetActive(false);
        }
        else if (vision == false)
        {
            At.SetActive(false);
            Bt.SetActive(true);
        }
    }
}
