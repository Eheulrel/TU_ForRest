using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchF : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public bool switchOn = false;

    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    GameObject bottom;
    GameObject top;
    GameObject topT;
    GameObject bottomT;

    void Start()
    {
        switchOn = false;
        
        bottom = transform.Find("bottom").gameObject;
        top = transform.Find("top").gameObject;
        bottomT = bottom.transform.Find("bottomT").gameObject;
        topT = top.transform.Find("topT").gameObject;

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
                topT.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
                bottomT.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);

                StartCoroutine(hideT());
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

    IEnumerator hideT()
    {
        yield return new WaitForSeconds(1);

        topT.SetActive(false);
        bottomT.SetActive(false);

        switchOn = false;
        spr.sprite = sprites[0];
    }
}
