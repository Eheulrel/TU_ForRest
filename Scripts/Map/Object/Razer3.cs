using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer3 : MonoBehaviour
{
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 0.8f;
    private float nextTime = 0.0f;

    private GameObject Razer32;
    private GameObject Razer33;
    private GameObject Razer34;

    // Start is called before the first frame update
    void Start()
    {
        Razer32 = transform.Find("Razer32").gameObject;
        Razer33 = transform.Find("Razer33").gameObject;
        Razer34 = transform.Find("Razer34").gameObject;

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

        if (!GameController.StopA)
            block();
    }

    void block()
    {
        if (vision == true)
        {
            Razer32.SetActive(true);
            Razer33.SetActive(true);
            Razer34.SetActive(true);


        }
        else if (vision == false)
        {
            Razer32.SetActive(false);
            Razer33.SetActive(false);
            Razer34.SetActive(false);

        }

    }
}
