using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroControl : MonoBehaviour
{
    private bool indexA = true;
    private bool indexB = false;
    private bool indexC = false;
    private bool indexD = false;
    private bool indexE = false;
    private bool indexF = false;

    GameObject index1;
    GameObject index2;
    GameObject index3;
    GameObject index4;
    GameObject index5;
    GameObject index6;

    public AudioClip audio;

    AudioSource aSource;

    //public TypeWriterEffect twe;

    void Start()
    {
        indexA = true;
        indexB = false;
        indexC = false;

        index1 = transform.Find("intro1").gameObject;
        index2 = transform.Find("intro2").gameObject;
        index3 = transform.Find("intro3").gameObject;
        index4 = transform.Find("intro4").gameObject;
        index5 = transform.Find("intro5").gameObject;
        index6 = transform.Find("intro6").gameObject;

        aSource = GetComponent<AudioSource>();
        aSource.clip = audio;
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

            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (indexB)
        {
            indexB = false;
            indexC = true;

            index2.SetActive(false);
            index3.SetActive(true);

            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (indexC)
        {
            indexC = false;
            indexD = true;

            index3.SetActive(false);
            index4.SetActive(true);

            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (indexD)
        {
            indexD = false;
            indexE = true;

            index4.SetActive(false);
            index5.SetActive(true);

            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (indexE)
        {
            indexE = false;
            indexF = true;

            index5.SetActive(false);
            index6.SetActive(true);

            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (indexF)
        {
            SceneManager.LoadScene("Start");
        }
    }
}
