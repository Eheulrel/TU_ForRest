using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchC : MonoBehaviour
{
    [SerializeField] private Transform Pos;

    public float MoveSpeed = 2f;    
    public bool switchOn = false;
    public bool check = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    private Vector3 orgPos;

    GameObject top;
    GameObject bottom;

    void Start()
    {
        switchOn = false;        

        top = transform.Find("topP").gameObject;
        bottom = transform.Find("bottomP").gameObject;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];

        orgPos = Pos.localPosition;
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
                top.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
                bottom.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);

                if (Vector3.Distance(top.transform.localPosition, orgPos) <= 0.1f)
                {
                    switchOn = false;  //trapA와 orgPos의 거리가 1보다 크면 MoveA를 false
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
