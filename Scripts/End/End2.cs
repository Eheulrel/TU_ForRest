using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End2 : MonoBehaviour
{
    private bool indexA = true;
    private bool indexB = false;
   
    GameObject index1;
    GameObject index2;

    //public TypeWriterEffect twe;

    void Start()
    {
        indexA = true;
        indexB = false;
    
        index1 = transform.Find("2-1").gameObject;
        index2 = transform.Find("2-2").gameObject; 
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
            SceneManager.LoadScene("Outro");
        }     
    }
}
