//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SelectManager : MonoBehaviour
//{
//    [SerializeField] private bool buttonA = true;
//    //[SerializeField] private bool buttonC = false;
//    [SerializeField] private bool buttonD = false;

//    GameObject button1;
//    //GameObject button3;
//    GameObject button4;

//    public SpriteRenderer b1;
//    //public SpriteRenderer b3;
//    public SpriteRenderer b4;
   
//    bool isChoice = true;

//    void Awake()
//    {    
//        button1 = transform.Find("StartB").gameObject; //게임시작 버튼       
//        //button3 = transform.Find("AchieveB").gameObject; //도전과제 버튼        
//        button4 = transform.Find("ExitB").gameObject; //게임종료 버튼

//        b1 = button1.GetComponent<SpriteRenderer>();
//        //b3 = button3.GetComponent<SpriteRenderer>();
//        b4 = button4.GetComponent<SpriteRenderer>();
//    }       

//    // Update is called once per frame
//    void Update()
//    {      

//        if (StartManager.secondS && !StartManager.AchieveS)
//        {           
//            if (buttonA)
//            {
//                if (isChoice)
//                {
//                    StartCoroutine(choiceA());
//                    isChoice = false;
//                }

//                if (Input.GetKeyDown(KeyCode.Space))
//                {
//                    SceneManager.LoadScene("Loading");
//                }

//                else if (Input.GetKeyDown(KeyCode.DownArrow))
//                {  
//                    buttonA = false;
//                    buttonD = true;

//                    StopCoroutine(choiceA());
//                    isChoice = true;

//                    b1.color = new Color32(255, 255, 255, 255);
//                }
//            }           
//            //else if (buttonC)
//            //{
//            //    if (isChoice)
//            //    {
//            //        StartCoroutine(choiceC());
//            //        isChoice = false;
//            //    }

//            //    if (Input.GetKeyDown(KeyCode.Space))
//            //    {                  
//            //        StartManager.AchieveS = true;                    
//            //    }

//            //    else if (Input.GetKeyDown(KeyCode.UpArrow))
//            //    {
//            //        buttonC = false;
//            //        buttonA = true;

//            //        StopCoroutine(choiceC());
//            //        isChoice = true;

//            //        b3.color = new Color32(255, 255, 255, 255);
//            //    }
//            //    else if (Input.GetKeyDown(KeyCode.DownArrow))
//            //    {
//            //        buttonC = false;
//            //        buttonD = true;

//            //        StopCoroutine(choiceC());
//            //        isChoice = true;

//            //        b3.color = new Color32(255, 255, 255, 255);
//            //    }
//            //}
//            else if (buttonD)
//            {
//                if (isChoice)
//                {
//                    StartCoroutine(choiceD());
//                    isChoice = false;
//                }

//                if (Input.GetKeyDown(KeyCode.Space))
//                {
//                    Application.Quit();
//                }

//                else if (Input.GetKeyDown(KeyCode.UpArrow))
//                {
//                    buttonD = false;
//                    buttonA = true;

//                    StopCoroutine(choiceD());
//                    isChoice = true;

//                    b4.color = new Color32(255, 255, 255, 255);
//                }
//            }
        
//        }        
//    }

//    IEnumerator choiceA()
//    {
//        int countTime = 0;

//        while (buttonA)
//        {
//            if (countTime % 2 == 0)
//            {
//                b1.color = new Color32(255, 255, 255, 90);
//            }
//            else
//            {
//                b1.color = new Color32(255, 255, 255, 180);
//            }

//            yield return new WaitForSeconds(0.4f);

//            countTime++;
//        }
//    }
    
//    //IEnumerator choiceC()
//    //{
//    //    int countTime = 0;

//    //    while (buttonC)
//    //    {
//    //        if (countTime % 2 == 0)
//    //        {
//    //            b3.color = new Color32(255, 255, 255, 90);
//    //        }
//    //        else
//    //        {
//    //            b3.color = new Color32(255, 255, 255, 180);
//    //        }

//    //        yield return new WaitForSeconds(0.4f);

//    //        countTime++;

//    //        b3.color = new Color32(255, 255, 255, 255);
//    //    }
//    //}

//    IEnumerator choiceD()
//    {
//        int countTime = 0;

//        while (buttonD)
//        {
//            if (countTime % 2 == 0)
//            {
//                b4.color = new Color32(255, 255, 255, 90);
//            }
//            else
//            {
//                b4.color = new Color32(255, 255, 255, 180);
//            }

//            yield return new WaitForSeconds(0.4f);

//            countTime++;

//            b4.color = new Color32(255, 255, 255, 255);
//        }
//    }
//}
