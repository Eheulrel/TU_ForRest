using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class brokenPlate : MonoBehaviour
{
    public bool playerin = false;
    public float lifetime = 1f;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerin)
        {
            StartCoroutine(timer());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerin = true;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.5f);

        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        StartCoroutine(timer2());
    }

    IEnumerator timer2()
    {
        yield return new WaitForSeconds(lifetime);

        gameObject.SetActive(false);
    }
}
