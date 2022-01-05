using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCheck : MonoBehaviour
{

    //public itemManager it;        
    //private GameObject pet;

    //bool Creature = false;
    //bool isDead = false;

    //void Start()
    //{            
    //    pet = transform.Find("creature").gameObject;
    //}

    //void Update()
    //{
    //    if (isDead == true)
    //    {
    //        gameObject.SetActive(false);
    //    }

    //    if (it.item == true)
    //    {
    //        Creature = true;
    //    }

    //    Summon();
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{      

    //    if (other.gameObject.tag == "itemA")
    //    {
    //        it.itemA = true;
    //        GameObject itA = GameObject.Find("itemA"); //object_name 으로 검색
    //        itA.SetActive(false);
    //    }

    //    if (other.gameObject.tag == "itemB")
    //    {
    //        it.itemB = true;
    //        GameObject itB = GameObject.FindWithTag("itemB"); //object_tag 로 검색
    //        itB.SetActive(false);
    //    }

    //    if (other.gameObject.tag == "itemC")
    //    {
    //        it.itemC = true;
    //        GameObject itC = GameObject.FindWithTag("itemC");
    //        itC.SetActive(false);
    //    }    

    //    if(other.gameObject.tag == "NextStg")
    //    {
    //        Scene scene = SceneManager.GetActiveScene(); //현재 씬의 정보

    //        int curScene = scene.buildIndex; //현재 씬의 빌드순서
    //        int nextScene = curScene + 1; //현재 씬의 다음 씬

    //        if(curScene == 2) // 현재 씬이 2번이면 시간을 멈춘다.
    //        {
    //            Time.timeScale = 0f;
    //        }
    //        else
    //        {
    //            SceneManager.LoadScene(nextScene);
    //        }            
    //    }

    //    if(other.gameObject.tag == "Die" && isDead == false)
    //    {
    //        isDead = true;
    //    }
    //}

    //private void Summon()
    //{

    //    if (Creature == true)
    //    {
    //        pet.SetActive(true);
    //    }
    //    else if (Creature == false)
    //    {
    //        pet.SetActive(false);
    //    }
    //}
}
