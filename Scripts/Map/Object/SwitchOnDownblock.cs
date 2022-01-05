using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnDownblock : MonoBehaviour
{
    public SwitchI switchI; //SwitchI 받음  

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (switchI.blockdown)
            {
                transform.Translate(Vector2.down * 2f * Time.deltaTime);

                StartCoroutine(timer());
            }            
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}