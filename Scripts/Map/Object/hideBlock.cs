using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideBlock : MonoBehaviour
{
    [SerializeField] private bool change = false;
    [SerializeField] private float timer = 2f;

    GameObject hide;

    void Awake()
    {       
        hide = transform.Find("hide").gameObject;

        StartCoroutine(changeMod());
    }

    IEnumerator changeMod()
    {
        yield return new WaitForSeconds(timer);

        if (change)
        {
            change = false;
            hide.SetActive(false);
        }
        else if (!change)
        {
            change = true;
            hide.SetActive(true);
        }

        StartCoroutine(changeMod());
    }
}
