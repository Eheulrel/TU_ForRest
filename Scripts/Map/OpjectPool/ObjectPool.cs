using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool:Singleton<ObjectPool>
{
    public List<PolledObject> objectPool = new List<PolledObject>();

    void Awake()
    {
        for(int ix = 0; ix < objectPool.Count; ++ix)
        {
            objectPool[ix].Initialize(transform); //오브젝트 풀 초기화, PolledObject에 지정한 poolCount 수 만큼 각 리스트에 객체가 생성되어 추가
        }
    }

    public bool PushToPool(string itemName, GameObject item, Transform parent = null)
    {
        //사용한 객체를 ObjectPool에 반환할 때 사용할 함수
        //itemName : 반환할 객체의 오브젝트 이름, item : 반환할 객체, parent : 부모계층 관계 설정
        PolledObject pool = GetPoolItem(itemName); //itemName에 전달된 이름과 동일한 pool을 찾는다
        if(pool == null) //pool검색에 실패
        {
            return false;
        }
        pool.PushToPool(item, parent == null ? transform : parent); //성공했으면 객체를 poolList에 저장
        //parent==null이면 게임오브젝트를 parent로, 지정되어 있으면 지정한 오브젝트를 parent로
        return true;
    }

    public GameObject PopFromPool(string  itemName, Transform parent = null)
    {
        //필요한 객체를 오브젝트 풀에 요청할 때 사용
        PolledObject pool = GetPoolItem(itemName); //itemName과 이름이 동일한 pool을 검색
        if (pool == null)
            return null;

        return pool.PopFromPool(parent); //검색을 성공한 경우, PolledObject의 PopFromPool를 호출해서 오브젝트를 얻고, 이 값을 리턴
    }

    PolledObject GetPoolItem(string itemName)
    {
        //전달된 itemName과 같은 이름을 가진 오브젝트 풀을 검색하고, 그 결과를 리턴
        for(int ix = 0; ix < objectPool.Count; ++ix)
        {
            if (objectPool[ix].poolItemName.Equals(itemName))
                return objectPool[ix];
        }

        return null;
    }
}
