using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundd : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer spr;

    public static int mapnum = 0;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[0];
    }

    void Update(){

        //맵 1, 2, 3 숫자로 구분해서 특정 숫자 되면 이미지를 변경한다.
        //Fade IN, OUT 응용해보자, 그냥 하면 이상할듯
        if(mapnum.Equals(0)) //map1
            spr.sprite = sprites[0];
        else if (mapnum.Equals(1)) //map2
            spr.sprite = sprites[1];
        else if (mapnum.Equals(2)) //map3(cave)
            spr.sprite = sprites[2];
        else if (mapnum.Equals(3)) //map3-1
            spr.sprite = sprites[0];
        else if (mapnum.Equals(4)) //map3-2
            spr.sprite = sprites[0];
        else if (mapnum.Equals(5)) //map3-4(cave)
            spr.sprite = sprites[2];
    }
}
