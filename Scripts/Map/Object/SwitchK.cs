using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchK : MonoBehaviour
{
    public bool switchOn = false;
    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    GameObject block;

    void Start()
    {
        block = transform.Find("block").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    void Update()
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
                block.SetActive(true);
                check = false;
                switchOn = false;
                spr.sprite = sprites[0];
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
