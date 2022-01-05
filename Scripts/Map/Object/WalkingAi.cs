using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAi : MonoBehaviour
{
    public float movePower = 2f;

    //Animator animator; 애니메이션 추가하면 적용
    Vector3 movement;
    int movementFlag = 0; //0:Idle, 1:Left, 2:Right

    // Start is called before the first frame update
    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();

        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag.Equals(1))
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(3, 3, 1);
        }
        else if (movementFlag.Equals(2))
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-3, 3, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    IEnumerator ChangeMovement()
    {
        //Random Change Movement
        movementFlag = Random.Range(0, 3);

        ////Mapping Animation
        //if (movementFlag.Equals(0))
        //{
        //    animator.SetBool("isMoving", false);
        //}
        //else
        //{
        //    animator.SetBool("isMoving", false);
        //}

        yield return new WaitForSeconds(2f);

        if (movementFlag.Equals(1))
        {
            movementFlag = 2;
        }
        else if (movementFlag.Equals(2))
        {
            movementFlag = 1;
        }

        StartCoroutine("ChangeMovement");
    }     
}
