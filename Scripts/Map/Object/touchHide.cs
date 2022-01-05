using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchHide : MonoBehaviour
{
    [SerializeField] private Transform nexPos;
    [SerializeField] private float Speed = 1f;
    [SerializeField] private bool check = false;

    void FixedUpdate()
    {
        if (check)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, nexPos.localPosition, Speed * Time.deltaTime);
        }        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(timer());
            check = true;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);
    }
}
