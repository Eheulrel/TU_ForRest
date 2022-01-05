using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRiding : MonoBehaviour
{
    public float BlockSpeed = 1;
    public bool SwitchOn = false;
    public bool check = false;
    public Transform Player;   

    public static bool ride = false;

    public Sprite[] sprites;
    public SpriteRenderer spr;

    void Start()
    {      
        SwitchOn = false;

        spr = transform.Find("Switch").GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    void FixedUpdate()
    {
        if (ride)
        {           
            if (MoveControl.inputLeft)
            {
                transform.Translate(Vector3.left * BlockSpeed * Time.deltaTime);
                Player.transform.Translate(Vector3.left * BlockSpeed * Time.deltaTime);
            }

            if (MoveControl.inputRight)
            {
                transform.Translate(Vector3.right * BlockSpeed * Time.deltaTime);
                Player.transform.Translate(Vector3.right * BlockSpeed * Time.deltaTime);
            }

            if (MoveControl.inputUp)
            {
                transform.Translate(Vector3.up * BlockSpeed * Time.deltaTime);
                Player.transform.Translate(Vector3.up * BlockSpeed * Time.deltaTime);
            }

            if (MoveControl.inputDown)
            {
                transform.Translate(Vector3.down * BlockSpeed * Time.deltaTime);
                Player.transform.Translate(Vector3.down * BlockSpeed * Time.deltaTime);
            }

            if (MoveControl.inputZ && !check)
            {
                SwitchOn = false;
                ride = false;
                spr.sprite = sprites[0];
            }
        }

        if (SwitchOn && !check)
        {
            if (MoveControl.inputZ)
            {
                ride = true;
                check = true;
                spr.sprite = sprites[1];
                StartCoroutine(checkf());
            }
        }             
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwitchOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwitchOn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {        
            gameObject.SetActive(false);
            ride = false;
        }
    }

    IEnumerator checkf()
    {
        yield return new WaitForSeconds(0.01f); //코루틴 실행 1초 뒤에 아래 명령어 실행

        check = false;
    }
}
