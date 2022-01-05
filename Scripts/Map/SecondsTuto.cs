using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsTuto : MonoBehaviour
{
    public TypeWriterEffect twe;
    public GameObject tuto;
    public GameObject tutopc;
    public Rigidbody2D player;   

    bool check = false;

    void Update()
    {
        if (check)
        {
            if (!twe.text_exit)
            {
                GameController.Apoint = 3;
                if (MoveControl.inputStop)
                {
                    twe.text_exit = true;
                    player.constraints = RigidbodyConstraints2D.FreezeRotation;                    
                }
            }
            else if (twe.text_exit)
            {
                if (GameController.pcmobile.Equals(1))
                {
                    //mobile
                    tuto.SetActive(false);
                }
                else if (GameController.pcmobile.Equals(0))
                {
                    //pc
                    tutopc.SetActive(false);
                }                
                check = false;
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation
                | RigidbodyConstraints2D.FreezePositionY;

            if (GameController.pcmobile.Equals(1))
            {
                //mobile
                tuto.SetActive(true);
            }
            else if (GameController.pcmobile.Equals(0))
            {
                //pc
                tutopc.SetActive(true);
            }

            check = true;
        }
    }
}
