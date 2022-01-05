using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public float movementSpeed;  
    [SerializeField] private float DashSpeed = 0f;
    [SerializeField] private float RopeSpeed = 0f;

    private Rigidbody2D playerRigidbody;
    float horizontalMovementSpeed;

    public bool isJumping = false;
    public bool isRope = false;
    public bool yesRope = false;
    public bool isDown = false;
    public bool isDead = false;

    private int playerLayer, DownPlate, dropzone;
    private GameObject dashE;

    public AudioClip[] stopp;
    AudioSource aSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController2D>();
        aSource = GetComponent<AudioSource>();

        dashE = transform.Find("dashEffect").gameObject;   
        //아래점프 위해서 레이어지정    
        playerLayer = LayerMask.NameToLayer("Player");
        DownPlate = LayerMask.NameToLayer("DownPlate");
        dropzone = LayerMask.NameToLayer("dropzone");
    }

    void Update()
    {
        //horizontalMovementSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        if (!BlockRiding.ride)
        {
            if (MoveControl.inputRight)  //우측방향키
            {
                horizontalMovementSpeed = 1.0f * movementSpeed;
            }
            else if (!MoveControl.inputRight) //우측방향키를 누르지 않을때, 
            {
                if (!MoveControl.inputLeft) //좌측방향키도 누르지 않은 상태이면
                {
                    horizontalMovementSpeed = 0.0f * movementSpeed; //멈춘다
                }
            }
            if (MoveControl.inputLeft) //좌측방향키
            {
                horizontalMovementSpeed = -1.0f * movementSpeed;
            }
            else if (!MoveControl.inputLeft)
            {
                if (!MoveControl.inputRight)
                {
                    horizontalMovementSpeed = 0.0f * movementSpeed;
                }
            }
        }        

        anim.SetFloat("speed", Mathf.Abs(horizontalMovementSpeed));

        if (MoveControl.inputJump) //점프
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }

        if (isDead)
        {
            anim.SetBool("isDead", true);
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation
              | RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(DeadT());
        }

        if (isRope) //로프
        {
            if (!yesRope)
            {
                if (MoveControl.inputUp) //로프에 매달리기
                {
                    yesRope = true; //로프에 매달렸는지 체크
                    anim.SetBool("isRope", true); //애니메이션
                    playerRigidbody.gravityScale = 0f; //중력0(바닥으로 안떨어지게)
                    playerRigidbody.velocity = Vector2.zero; //속력0(밧줄 밖으로 탈출 안하게)
                }
                else if (!MoveControl.inputUp) //위 방향키 때면
                {
                    playerRigidbody.velocity *= 1f; //속력은 다시 정상화, 안하면 안움직임
                }
            }            

            if (yesRope) //줄에 매달렸을때
            {
                if (MoveControl.inputUp) //위로 이동
                {
                    //playerRigidbody.AddForce(new Vector2(0f, RopeSpeed));
                    playerRigidbody.velocity = new Vector2(0f, RopeSpeed);
                }
                else if (!MoveControl.inputUp)
                {
                    if (!MoveControl.inputDown)
                    {
                       playerRigidbody.velocity *= 0.2f;
                    }                   
                }

                if (MoveControl.inputDown) //아래로 이동
                {
                    //playerRigidbody.AddForce(new Vector2(0f, -RopeSpeed));
                    playerRigidbody.velocity = new Vector2(0f, -RopeSpeed);
                }
                else if (!MoveControl.inputDown)
                {
                    if (!MoveControl.inputUp)
                    {
                        playerRigidbody.velocity *= 0.2f;
                    }                    
                }
            }           
        }
        else if (!yesRope) //줄에서 벗어났을때
        {
            anim.SetBool("isRope", false); //애니메이션 끔
            playerRigidbody.gravityScale = 1f; //중력 정상화
        }

        if (MoveControl.inputDash) //1스택 사용
        {
            if (GameController.Apoint > 0)
            {
                dashE.SetActive(true); //대쉬 이펙트를 켠다
                StartCoroutine(dashtimer()); //이펙트 타이머

                if (horizontalMovementSpeed > 0)
                {
                    playerRigidbody.AddForce(new Vector2(DashSpeed, 1f));
                    GameController.Apoint -= 1;                    
                }
                else if (horizontalMovementSpeed < 0)
                {
                    playerRigidbody.AddForce(new Vector2(-DashSpeed, 1f));
                    GameController.Apoint -= 1;                    
                }
            }
        }

        if (MoveControl.inputStop) //3스택 사용
        {
            if (GameController.Apoint.Equals(3))
            {
                GameController.StopA = true;
                GameController.Apoint -= 3;
                StartCoroutine(stopS());
            }
        }

        if (MoveControl.inputDown) //아랫점프 하기
        {
            StartCoroutine(Downjump());
        }

        if (playerRigidbody.velocity.y > 0) //DownPlate 위에 있으면 충돌하고 밑에 있으면 충돌안함
        {
            Physics2D.IgnoreLayerCollision(playerLayer, DownPlate, true);
        }
        else if (playerRigidbody.velocity.y <= 0 && !isDown)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, DownPlate, false);
        }

        if (GameController.saveit && GameController.desobj)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, dropzone, true);
        }
    }

    public void Onlanding()
    {
        isJumping = false;
        anim.SetBool("isJumping", false);   
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMovementSpeed * Time.fixedDeltaTime, isJumping);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (GameController.Apoint < 3)
            {
                GameController.Apoint += 1;
            }
        }

        if (other.gameObject.CompareTag("Die"))
        {
            isDead = true;
        }

        if (other.gameObject.CompareTag("rope"))
        { 
            isRope = true;                
        }

        if (other.gameObject.CompareTag("Map1"))
        {
            BackGroundd.mapnum = 0;
        }

        if (other.gameObject.CompareTag("Map2"))
        {
            BackGroundd.mapnum = 1;
        }

        if (other.gameObject.CompareTag("Map3"))
        {
            BackGroundd.mapnum = 2;
        }

        if (other.gameObject.CompareTag("Map3-1"))
        {
            BackGroundd.mapnum = 3;
        }    

        if (other.gameObject.CompareTag("Map3-2"))
        {
            BackGroundd.mapnum = 4;
        }

        if (other.gameObject.CompareTag("Map3-4"))
        {
            BackGroundd.mapnum = 5;
        }

        if (other.gameObject.CompareTag("map1End"))
        {
            GameController.first = 1;            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("rope"))
        {
            isRope = false;
            yesRope = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Die"))
        {
            isDead = true;
        }        
    }

    IEnumerator Downjump()
    {
        isDown = true;
        Physics2D.IgnoreLayerCollision(playerLayer, DownPlate, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(playerLayer, DownPlate, false);
        isDown = false;
    }

    IEnumerator dashtimer()
    {
        yield return new WaitForSeconds(0.5f);

        dashE.SetActive(false);
    }

    IEnumerator DeadT()
    {
        aSource.clip = stopp[1];
        if (!aSource.isPlaying)
        {
            aSource.Play();
        }

        yield return new WaitForSeconds(1f);

        Achievement.SaveData.DeadCount++;
        Debug.Log(Achievement.SaveData.DeadCount);
        SceneManager.LoadScene("Map");                
    }   

    IEnumerator stopS()
    {
        aSource.clip = stopp[0];
        if (!aSource.isPlaying)
        {
            aSource.Play();
            aSource.loop = true;
        }

        yield return new WaitForSeconds(1f);

        aSource.Stop();
        aSource.loop = false;
        StopCoroutine(stopS());
    }
}
