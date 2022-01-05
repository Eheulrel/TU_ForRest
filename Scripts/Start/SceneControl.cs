//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SceneControl : MonoBehaviour
//{
//    [SerializeField] private float MoveSpeed;

//    public bool Moving;
//    public SpriteRenderer press;
//    private bool isPress;

//    void Awake()
//    {        
//        Moving = false;
//        MoveSpeed = 10.0f;
//        isPress = true;
//        transform.position = new Vector3(0, 0, 0);
//        press = transform.Find("press_button").GetComponent<SpriteRenderer>();
//    }
    
//    void Update()
//    {
//        if (StartManager.mainS && !StartManager.secondS)
//        {
//            if (isPress)
//            {
//                StartCoroutine(pressK());
//                isPress = false;
//            }            
//        }
//        else
//        {
//            StopCoroutine(pressK());
//            isPress = true;
//        }
//    }

//    void FixedUpdate()
//    {
//        if (Moving)
//        {
//            //아무 버튼 누르면 메인화면으로 이동
//            if (StartManager.secondS && !StartManager.AchieveS && !StartManager.mainS)
//            {
//                transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);

//                if (transform.position.y >= 10.15f)
//                {
//                    Moving = false;
//                }
//            }
//            //esc 누르면 첫화면으로 이동
//            if (StartManager.mainS && StartManager.secondS)
//            {
//                transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);

//                if (transform.position.y <= 0.0f)
//                {
//                    Moving = false;
//                    StartManager.secondS = false;
//                }               
//            }
//            //도전과제버튼 누르면 도전과제화면으로 이동
//            if (!StartManager.secondS && StartManager.AchieveS)
//            {
//                transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);

//                if (transform.position.x <= -17.85f)
//                {
//                    Moving = false;
//                }
//            }
//            //도전과제 화면에서 esc누르면 메인화면으로 이동
//            if (StartManager.AchieveS && StartManager.secondS)
//            {
//                transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

//                if (transform.position.x >= 0.0f)
//                {
//                    Moving = false;
//                    StartManager.AchieveS = false;
//                }                
//            }          
//        }
//    }

//    IEnumerator pressK()
//    {
//        int countTime = 0;

//        while (StartManager.mainS)
//        {
//            if (countTime % 2 == 0)
//            {
//                press.color = new Color32(255, 255, 255, 90);
//            }
//            else
//            {
//                press.color = new Color32(255, 255, 255, 180);
//            }

//            yield return new WaitForSeconds(0.4f);

//            countTime++;
//        }
//    }
//}

