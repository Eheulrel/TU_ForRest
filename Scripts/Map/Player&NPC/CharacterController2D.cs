using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 0f;
    [SerializeField] private float MoveSpeed = 0f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;

    public PlayerController control;
    const float k_GroundedRadius = .2f;
    public bool m_Grounded;
    public bool isWall = false;
    private bool wallJ = true;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        //OverlapCircleAll(Vector2 point, radius, layerMask);, 위치로부터 원형으로 충돌하는 물체를 배열로 저장
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position,
            k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject) //범위 내의 레이어가 플레이어가 아닐때 발동
            {
                m_Grounded = true;
                isWall = false;
                if (!wasGrounded) //wasGrounded가 아니면 콜백함수 호출 (PlayerController의 OnLanding)
                    OnLandEvent.Invoke(); //PlayerController의 isJumping = false가 됨
            }
        }

        if (!m_Grounded && isWall) //벽점프
        {
            if (wallJ)
            {
                if (m_FacingRight) //오른쪽 벽을 발판으로
                {
                    if (MoveControl.inputJump)
                    {
                        m_Rigidbody2D.AddForce(new Vector2(MoveSpeed * -2f, m_JumpForce));
                        //Flip();                        
                        StartCoroutine(walljump()); //점프 쿨타임 0.15초
                    }
                }

                else if (!m_FacingRight) //왼쪽 벽을 발판으로
                {
                    if (MoveControl.inputJump)
                    {
                        m_Rigidbody2D.AddForce(new Vector2(MoveSpeed * 2f, m_JumpForce));
                        //Flip();                        
                        StartCoroutine(walljump()); //점프 쿨타임 0.15초
                    }
                }
            }            

            if (!MoveControl.inputJump)
            {
                m_Rigidbody2D.velocity *= 0.8f; //벽에 붙으면 속도 0.8배
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if (!control.yesRope)
        {
            Vector3 targetVelocity = new Vector2(move * 20f, m_Rigidbody2D.velocity.y); //걷기
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity,
                targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }

        if (m_Grounded && jump)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); //점프            

            m_Grounded = false;
            StartCoroutine(jumpc()); //점프 쿨타임 0.01초
        }

        if (control.yesRope) //로프
        {
            if (jump) //매달린 상태에서 점프
            {
                if (!m_FacingRight) //왼쪽에서 매달렸을때
                {
                    //MoveSpeed = 250, JumpForce = 400 기준으로 m_JumpForce * 0.5f
                    if (move > 0) //등쪽 방향(오른쪽 방향키)
                    {
                        m_Rigidbody2D.AddForce(new Vector2(MoveSpeed * 0.5f, m_JumpForce*0.5f));
                        Flip();
                        control.yesRope = false;
                    }
                    else if (move < 0) //보는 방향(왼쪽 방향키)
                    {
                        m_Rigidbody2D.AddForce(new Vector2(-MoveSpeed * 0.5f, m_JumpForce * 0.5f));
                        //m_Rigidbody2D.velocity *= 0.7f; //속력 0.7배, 안하면 너무 멀리 날아가서 달아둠, 시간되면 수정할 예정
                        control.yesRope = false;
                    }
                }
                else if (m_FacingRight) //오른쪽에서 매달렸을때
                {
                    if (move < 0) //등쪽 방향(왼쪽 방향키)
                    {
                        m_Rigidbody2D.AddForce(new Vector2(-MoveSpeed * 0.5f, m_JumpForce * 0.5f));
                        Flip();
                        control.yesRope = false;
                    }
                    else if (move > 0) //보는 방향(오른쪽 방향키)
                    {
                        m_Rigidbody2D.AddForce(new Vector2(MoveSpeed * 0.5f, m_JumpForce * 0.5f));
                        //m_Rigidbody2D.velocity *= 0.7f; //속력 0.7배, 안하면 너무 멀리 날아가서 달아둠, 시간되면 수정할 예정
                        control.yesRope = false;
                    }
                }
                OnLandEvent.Invoke();
            }
        }
    }

    private void Flip() //캐릭터 좌우반전
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isWall = false;
        }
    }

    IEnumerator walljump()
    {
        wallJ = false;
        yield return new WaitForSeconds(0.15f);
        wallJ = true;
    }

    IEnumerator jumpc()
    {        
        yield return new WaitForSeconds(0.01f);
        control.isJumping = false;
    }
}
