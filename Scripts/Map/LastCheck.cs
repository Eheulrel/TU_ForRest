using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCheck : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public GameObject boss;
    public TypeWriterEffect twe;
    public GameObject dialog;
    public Rigidbody2D player;

    bool endCut = false;
    bool hosu = false;

    void Awake()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {
        if (hosu)
        {
            dialog.SetActive(true);

            if (!twe.text_exit)
            {
                player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation
               | RigidbodyConstraints2D.FreezePositionY;
                if (MoveControl.inputZ)
                {
                    twe.End_Typing();
                }
            }
            else if (twe.text_exit)
            {
                dialog.SetActive(false);             
                StartCoroutine(timer());
            }
        }
        
        if (endCut)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            boss.SetActive(true);
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hosu = true;           
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);

        endCut = true;
    }
}
