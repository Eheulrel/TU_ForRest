using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowDoor : MonoBehaviour
{
    public float MoveSpeed = 0.2f;

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    }
}
