using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchI : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool switchOn = false;
    public bool blockdown = false;

    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    GameObject Thorn;

    void Start()
    {
        switchOn = false;
        blockdown = false;
        Thorn = transform.Find("LeftThorn").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    void FixedUpdate()
    {
        if (!GameController.StopA)
        {
            if (switchOn)
            {
                if (MoveControl.inputZ)
                {
                    check = true;
                    spr.sprite = sprites[1];
                }

                if (check)
                {
                    Thorn.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

                    if (Thorn.transform.position.x < 415.5)
                    {
                        switchOn = false;
                        spr.sprite = sprites[0];
                    }
                }                    
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switchOn = true;
            blockdown = true;
        }
    }
}