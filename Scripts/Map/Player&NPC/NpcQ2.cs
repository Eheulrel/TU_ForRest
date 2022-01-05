using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcQ2 : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public TypeWriterEffect twe;
    public GameObject dialog;

    bool point = true;
    bool dead = false;

    void Update()
    {
        if (point)
        {
            transform.Translate(new Vector2(1, 0) * MoveSpeed * Time.deltaTime);
            StartCoroutine(timer());
        }

        if (dead)
        {
            dialog.SetActive(true);

            if (!twe.text_exit)
            {
                if (MoveControl.inputZ)
                {
                    twe.End_Typing();
                }
            }
            else if (twe.text_exit)
            {
                dialog.SetActive(false);                
                StartCoroutine(timer2());
            }
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        
        point = false;
        dead = true;
    }

    IEnumerator timer2()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("End");
    }
}
