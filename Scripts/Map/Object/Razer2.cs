using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer2 : MonoBehaviour
{
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 0.8f;
    private float nextTime = 0.0f;

    private GameObject Razer21;
    private GameObject Razer22;
    private GameObject Razer23;
    private GameObject Razer24;
    private GameObject Razer25;
    private GameObject Razer26;
    private GameObject Razer27;
    private GameObject Razer28;
    private GameObject Razer29;
    private GameObject Razer30;

    // Start is called before the first frame update
    void Start()
    {
        Razer21 = transform.Find("Razer21").gameObject;
        Razer22 = transform.Find("Razer22").gameObject;
        Razer23 = transform.Find("Razer23").gameObject;
        Razer24 = transform.Find("Razer24").gameObject;
        Razer25 = transform.Find("Razer25").gameObject;
        Razer26 = transform.Find("Razer26").gameObject;
        Razer27 = transform.Find("Razer27").gameObject;
        Razer28 = transform.Find("Razer28").gameObject;
        Razer29 = transform.Find("Razer29").gameObject;
        Razer30 = transform.Find("Razer30").gameObject;


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
            Razer21.SetActive(true);
            Razer22.SetActive(true);
            Razer23.SetActive(true);
            Razer24.SetActive(false);
            Razer25.SetActive(false);
            Razer26.SetActive(false);
            Razer27.SetActive(true);
            Razer28.SetActive(true);
            Razer29.SetActive(true);
            Razer30.SetActive(true);

        }
        else if (vision == false)
        {
            Razer21.SetActive(false);
            Razer22.SetActive(false);
            Razer23.SetActive(false);
            Razer24.SetActive(true);
            Razer25.SetActive(true);
            Razer26.SetActive(true);
            Razer27.SetActive(false);
            Razer28.SetActive(false);
            Razer29.SetActive(false);
            Razer30.SetActive(false);

        }

    }
}
