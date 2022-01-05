using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayDrop : MonoBehaviour
{
    public int state = 0;
    public float MoveSpeed = 0f;

    GameObject first;
    GameObject second;
    GameObject third;
    GameObject forth;
    GameObject fifth;
    GameObject sixth;

    void Start()
    {
        first = transform.Find("1st").gameObject;
        second = transform.Find("2nd").gameObject;
        third = transform.Find("3rd").gameObject;
        forth = transform.Find("4rd").gameObject;
        fifth = transform.Find("5rd").gameObject;
        sixth = transform.Find("6rd").gameObject;
    }
    
    void Update()
    {
        if (state.Equals(0))
        {
            first.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        }
        else if (state.Equals(1))
        {
            second.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        }
        else if (state.Equals(2))
        {
            third.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        }
        else if (state.Equals(3))
        {
            forth.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        }
        else if (state.Equals(4))
        {
            fifth.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        }
        else if (state.Equals(5))
        {
            sixth.transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        }
        else if (state.Equals(6))
        {
            first.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);            

            if(first.transform.localPosition.y > 0)
            {
                state++;
            }
        }
        else if (state.Equals(7))
        {
            second.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if (second.transform.localPosition.y > 0)
            {
                state++;
            }
        }
        else if (state.Equals(8))
        {
            third.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if (third.transform.localPosition.y > 0)
            {
                state++;
            }
        }
        else if (state.Equals(9))
        {
            forth.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if (forth.transform.localPosition.y > 0)
            {
                state++;
            }
        }
        else if (state.Equals(10))
        {
            fifth.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if (fifth.transform.localPosition.y > 0)
            {
                state++;
            }
        }
        else if (state.Equals(11))
        {
            sixth.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if (sixth.transform.localPosition.y > 0)
            {
                state++;
                StartCoroutine(timer());
            }            
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);

        state = 0;
    }
}
