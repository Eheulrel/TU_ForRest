using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHideBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.Translate(Vector2.down * 2f * Time.deltaTime);

            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
