using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchJ : MonoBehaviour
{
    GameObject door;
    public bool switchOn = false;
    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    void Start()
    {
        switchOn = false;
        check = false;

        door = transform.Find("door").gameObject;

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
                door.SetActive(false);
                switchOn = false;
                check = false;
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
