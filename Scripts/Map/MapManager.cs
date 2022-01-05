using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject map3;
    public GameObject map2_object;
    
    void Update()
    {
        if(GameController.first.Equals(0))
        {
            map3.SetActive(false);
            map2_object.SetActive(false);            
        }
        else if (GameController.first.Equals(1))
        {
            map3.SetActive(true);
            map2_object.SetActive(true);
        }
    }
}
