﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End3 : MonoBehaviour
{
    private bool indexA = true;
    private bool indexB = false;
    private bool indexC = false;
    private bool indexD = false;

    GameObject index1;
    GameObject index2;
    GameObject index3;
    GameObject index4;

    //public TypeWriterEffect twe;

    void Start()
    {
        indexA = true;
        indexB = false;
        indexC = false;
        indexD = false;

        index1 = transform.Find("3-1").gameObject;
        index2 = transform.Find("3-2").gameObject;
        index3 = transform.Find("3-3").gameObject;
        index4 = transform.Find("3-4").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //twe.End_Typing(); //문단 끝맺음
            checkS();
        }
    }

    void checkS()
    {
        if (indexA)
        {
            indexA = false;
            indexB = true;

            index1.SetActive(false);
            index2.SetActive(true);
        }
        else if (indexB)
        {
            indexB = false;
            indexC = true;

            index2.SetActive(false);
            index3.SetActive(true);
        }
        else if (indexC)
        {
            indexC = false;
            indexD = true;

            index3.SetActive(false);
            index4.SetActive(true);
        }
        else if (indexD)
        {
            SceneManager.LoadScene("Outro");
        }       
    }
}
