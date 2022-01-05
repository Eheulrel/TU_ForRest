using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reAct : MonoBehaviour
{
    GameObject down;
    GameObject up;

    void Start()
    {
        down = transform.Find("downT").gameObject;
        up = transform.Find("upT").gameObject;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);

        down.SetActive(true);
        up.SetActive(true);
    }
}
