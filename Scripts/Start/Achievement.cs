using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    
    
    public class SaveData
    {
        [SerializeField] public static int DeadCount;
        [SerializeField] public static bool Clear;

       public SaveData()
        {
            //초기화 하는 부분
            DeadCount = 0;
            Clear = false;
        }   
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Achievement.SaveData.DeadCount == 1)
        {

        }

        if(Achievement.SaveData.Clear)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Achievement.SaveData.Clear = true;
        }
    }
}
