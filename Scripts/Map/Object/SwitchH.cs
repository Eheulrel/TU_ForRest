using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchH : MonoBehaviour
{
    [SerializeField] private Transform orgPos;

    public float MoveSpeed = 2f;
    public bool switchOn = false;

    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    private Vector3 PosB;
    private Vector3 nexPos;
    GameObject block;

    void Start()
    {
        switchOn = false;
        block = transform.Find("drop").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];

        PosB = orgPos.localPosition;
        nexPos = PosB;
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
                block.transform.localPosition = Vector3.MoveTowards(block.transform.localPosition, nexPos, MoveSpeed * Time.deltaTime);

                if (Vector3.Distance(block.transform.localPosition, nexPos) <= 0.05f)
                {
                    switchOn = false;
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
