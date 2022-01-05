using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlingkingBlock2 : MonoBehaviour
{
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 2.5f;
    private float nextTime = 0.0f;

    private GameObject AA;
    private GameObject aa;
    private GameObject BB;
    

    // Start is called before the first frame update
    void Start()
    {
        AA = transform.Find("A1").gameObject;
        aa = transform.Find("A2").gameObject;
        BB = transform.Find("B1").gameObject;
        

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
            AA.SetActive(true);
            aa.SetActive(true);
            BB.SetActive(false);

        }
        else if (vision == false)
        {
            AA.SetActive(false);
            aa.SetActive(false);
            BB.SetActive(true);

        }
    }
}
