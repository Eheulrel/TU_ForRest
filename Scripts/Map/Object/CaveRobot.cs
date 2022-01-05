using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveRobot : MonoBehaviour
{
    public float MoveSpeed;
    public string poolItemName = "Robot";
    public float lifeTime = 30f;
    public float _elapsedTime = 0f; //로봇이 활성화 된 뒤 경과시간을 계산하기 위해

    private bool isDead = false; 
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameController.StopA)
        {
            if (!isDead)
            {
                transform.Translate(new Vector2(1, 0) * MoveSpeed * Time.deltaTime);
            }
            else if (isDead){
                anim.SetBool("isDead", true);
            }
        }
        

        if (GetTimer() > lifeTime)
        {
            SetTimer();
            ObjectPool.Instance.PushToPool(poolItemName, gameObject);
        }
    }

    float GetTimer()
    {
        return (_elapsedTime += Time.deltaTime);
    }

    void SetTimer()
    {
        _elapsedTime = 0f;
    }

    private void Flip() //캐릭터 좌우반전
    {       
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            MoveSpeed *= -1f;
            Flip();
        }

        if (other.gameObject.CompareTag("Die"))
        {
            StartCoroutine(timer());
            isDead = true;            
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
