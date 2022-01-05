using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject dialog;
    public GameObject text1;
    public GameObject text2;
    public Rigidbody2D player;

    public int first = 0;
    public bool playerin = false;
    public bool acc = false;

    void Start()
    {
        first = 0;
        playerin = false;
        acc = false;
    }

    void Update()
    {
        if (playerin)
        {
            if (acc)
            {
                if (first.Equals(0))
                {
                    dialog.SetActive(true);
                    text1.SetActive(true);
                    text2.SetActive(false);

                    if (MoveControl.inputZ)
                    {
                        StartCoroutine(timer());
                    }
                }

                if (first.Equals(1))
                {
                    dialog.SetActive(true);
                    text1.SetActive(false);
                    text2.SetActive(true);

                    if (MoveControl.inputZ)
                    {
                        first = 2;
                        dialog.SetActive(false);
                        acc = false;
                    }
                }

                if (first.Equals(2))
                {
                    player.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }        
        }

        if (playerin)
        {
            if (MoveControl.inputZ)
            {
                acc = true;
                player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation
                       | RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerin = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerin = false;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.3f);

        first = 1;
    }
}
