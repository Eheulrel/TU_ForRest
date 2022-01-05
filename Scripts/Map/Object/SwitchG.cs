using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchG : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public bool switchOn = false;

    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    GameObject block;

    void Start()
    {
        switchOn = false;
        block = transform.Find("block").gameObject;

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
                block.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);

                StartCoroutine(timer());
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

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.5f);

        block.SetActive(false);

        spr.sprite = sprites[0];
    }
}
