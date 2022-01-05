using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchL : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public bool switchOn = false;

    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    GameObject door;

    void Start()
    {
        switchOn = false;
        check = false;

        door = transform.Find("DoorLock").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];

    }

    void FixedUpdate()
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
                door.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

                if (door.transform.position.y > -19f)
                {
                    switchOn = false;
                    check = false;
                    spr.sprite = sprites[0];
                }
            }
           
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switchOn = true;
        }
    }
}
