using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargePoint : MonoBehaviour
{
    public TypeWriterEffect twe;
    public GameObject dialog;
    public GameObject text;

    public Sprite[] sprites;
    SpriteRenderer spr;

    bool robotmeet = false;

    int meet = 0;
    
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    void Update()
    {
        if (robotmeet)
        {
            if (MoveControl.inputZ)
            {
                if (meet.Equals(0))
                {
                    dialog.SetActive(true);                    

                    if (!twe.text_exit)
                    {
                        twe.End_Typing();
                    }
                    else if (twe.text_exit)
                    {
                        dialog.SetActive(false);
                        meet++;
                        GameController.Apoint = 3;
                        spr.sprite = sprites[1];
                        text.SetActive(true);
                    }
                }
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            robotmeet = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            robotmeet = false;
        }
    }
}
