using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideTrap : MonoBehaviour
{
    public bool power = false;
    public float MoveSpeed = 2f;

    GameObject control;
   
    void Start()
    {
        power = false;
        control = transform.Find("MoveP").gameObject;
    }

    void FixedUpdate()
    {
        if (power)
        {
            control.transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

            if(control.transform.position.y > -13.7f)
            {
                power = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.6f);

        power = true;
    }
}
