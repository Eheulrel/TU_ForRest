using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchB : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float MoveSpeed2 = 0.2f;
    public bool switchOn = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    bool stop = false;
    bool doorA = false;
    bool doorB = false;
    bool check = false;

    BoxCollider2D boxcol;
    GameObject door;
    GameObject slow;

    void Start()
    {
        switchOn = false;
        doorA = false;
        doorB = false;
        check = false;

        door = transform.Find("doorLock").gameObject;
        slow = transform.Find("slowDoor").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];

        boxcol = slow.GetComponent<BoxCollider2D>();
        boxcol.enabled = false;
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
                if (!stop)
                {
                    door.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

                    if (door.transform.position.y > -3.5f)
                    {
                        stop = true;
                        doorA = true;
                    }
                }

                if (doorA)
                {
                    slow.transform.Translate(Vector2.down * MoveSpeed2 * Time.deltaTime);

                    if (slow.transform.position.y < -5.5f)
                    {
                        switchOn = false;
                        doorA = false;
                        doorB = true;
                        spr.sprite = sprites[0];

                        boxcol.enabled = true;
                    }
                }

                if (doorB)
                {
                    slow.transform.Translate(Vector2.up * MoveSpeed2 * Time.deltaTime);

                    if (slow.transform.position.y > -4.5f)
                    {
                        boxcol.enabled = false;

                        doorA = true;
                        doorB = false;
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
        }
    }
}
