using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletControl : MonoBehaviour
{       
    public float MoveSpeed;
    public float x = -1f;
    public float y = 0f;
    public string poolItemName = "Bullet";    
    public float lifeTime = 3f;
    public float _elapsedTime = 0f; //총알이 활성화 된 뒤 경과시간을 계산하기 위해
  
    void Update()
    {
        transform.Translate(new Vector2(x,y) * MoveSpeed * Time.deltaTime);
        
        if(GetTimer() > lifeTime)
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
}
