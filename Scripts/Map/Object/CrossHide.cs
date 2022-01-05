using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHide : MonoBehaviour
{
    [SerializeField] private bool vision = true;
    public float cycle = 1f;

    GameObject first;
    GameObject seconds;   

    // Start is called before the first frame update
    void Start()
    {
        first = transform.Find("first").gameObject;
        seconds = transform.Find("seconds").gameObject;

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    { 
        block();
    }

    void block()
    {
        if (vision)
        {
            first.SetActive(true);
            seconds.SetActive(false);            
        }
        else if (!vision)
        {
            first.SetActive(false);
            seconds.SetActive(true);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(cycle);

        if (vision)
        {
            vision = false;
        }
        else if (!vision)
        {
            vision = true;
        }

        StartCoroutine(Timer());
    }
}
