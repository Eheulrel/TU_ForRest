using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveControl : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public float playerX;
        public float playerY;
        public float playerZ;

        public int Apoint;
        public int start;
        public bool saveit;
        public bool desobj;
        public int first;
    }

    private PlayerController thePlayer;    
    public Data data;
    private Vector3 vector;

    public void CallSave()
    {  
        thePlayer = FindObjectOfType<PlayerController>();
       
        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;
        data.Apoint = GameController.Apoint;
        data.start = GameController.start;
        data.saveit = GameController.saveit;
        data.desobj = GameController.desobj;
        data.first = GameController.first;

        Debug.Log("기초 데이터 성공");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveFile.dat");        

        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Application.persistentDataPath + "의 위치에 저장했습니다.");
    }

    public void CallLoad()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SaveFile.dat", FileMode.Open);
        
        if (file != null && file.Length > 0)
        {
            data = (Data)bf.Deserialize(file);
           
            thePlayer = FindObjectOfType<PlayerController>();
            
            vector.Set(data.playerX, data.playerY, data.playerZ);
            thePlayer.transform.position = vector;
            GameController.Apoint = data.Apoint;
            GameController.start = data.start;
            GameController.saveit = data.saveit;
            GameController.desobj = data.desobj;
            GameController.first = data.first;
        }
        else
        {
            Debug.Log("저장된 세이브 파일이 없습니다");
        }


        file.Close();
    }

    public void CallDelete()
    {
        BinaryFormatter bf = new BinaryFormatter();
        File.Delete(Application.persistentDataPath + "/SaveFile.dat");

        Debug.Log("저장된 파일이 삭제되었습니다.");
    }
}
