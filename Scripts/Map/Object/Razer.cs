using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour
{
    
    private Vector3 pos;
    private bool vision;
    private float TimeLimt = 0.7f;
    private float nextTime = 0.0f;

    private GameObject Razer1;
    private GameObject Razer2;
    private GameObject Razer3;
    private GameObject Razer4;
    private GameObject Razer5;
    private GameObject Razer6;
    private GameObject Razer7;
    private GameObject Razer8;
    private GameObject Razer9;
    private GameObject Razer10;
    private GameObject Razer11;
    private GameObject Razer12;
    private GameObject Razer13;
    private GameObject Razer14;
    private GameObject Razer15;
    private GameObject Razer16;
    private GameObject Razer17;

    // Start is called before the first frame update
    void Start()
    {
        Razer1 = transform.Find("Razer1").gameObject;
        Razer2 = transform.Find("Razer2").gameObject;
        Razer3 = transform.Find("Razer3").gameObject;
        Razer4 = transform.Find("Razer4").gameObject;
        Razer5 = transform.Find("Razer5").gameObject;
        Razer6 = transform.Find("Razer6").gameObject;
        Razer7 = transform.Find("Razer7").gameObject;
        Razer8 = transform.Find("Razer8").gameObject;
        Razer9 = transform.Find("Razer9").gameObject;
        Razer10 = transform.Find("Razer10").gameObject;
        Razer11 = transform.Find("Razer11").gameObject;
        Razer12 = transform.Find("Razer12").gameObject;
        Razer13 = transform.Find("Razer13").gameObject;
        Razer14 = transform.Find("Razer14").gameObject;
        Razer15 = transform.Find("Razer15").gameObject;
        Razer16 = transform.Find("Razer16").gameObject;
        Razer17 = transform.Find("Razer17").gameObject;

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
            Razer1.SetActive(true);
            Razer2.SetActive(true);
            Razer3.SetActive(true);
            Razer4.SetActive(true);
            Razer5.SetActive(true);
            Razer6.SetActive(true);
            Razer7.SetActive(true);
            Razer8.SetActive(true);
            Razer9.SetActive(true);
            Razer10.SetActive(true);
            Razer11.SetActive(true);
            Razer12.SetActive(true);
            Razer13.SetActive(true);
            Razer14.SetActive(true);
            Razer15.SetActive(true);
            Razer16.SetActive(true);
            Razer17.SetActive(true);

        }
        else if (vision == false)
        {
            Razer1.SetActive(false);
            Razer2.SetActive(false);
            Razer3.SetActive(false);
            Razer4.SetActive(false);
            Razer5.SetActive(false);
            Razer6.SetActive(false);
            Razer7.SetActive(false);
            Razer8.SetActive(false);
            Razer9.SetActive(false);
            Razer10.SetActive(false);
            Razer11.SetActive(false);
            Razer12.SetActive(false);
            Razer13.SetActive(false);
            Razer14.SetActive(false);
            Razer15.SetActive(false);
            Razer16.SetActive(false);
            Razer17.SetActive(false);
        }    
    }
}
