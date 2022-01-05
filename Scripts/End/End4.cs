using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End4 : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene("Outro");
    }
}
