using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcController4 : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public TypeWriterEffect twe;
    public GameObject dialog;
    public Animator anim;

    bool point = true;
    bool dead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

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
                anim.SetBool("isDead", true);
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
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("End");
    }
}
