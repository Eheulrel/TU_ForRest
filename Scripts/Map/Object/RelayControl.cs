using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayControl : MonoBehaviour
{
    public RelayDrop mom;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            mom.state +=1;
        }
    }
}
