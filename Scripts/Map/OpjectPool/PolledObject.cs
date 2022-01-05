using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PolledObject
{
    public string poolItemName = string.Empty; //객체를 검색할 때 사용할 이름
    public GameObject prefab = null; //오브젝트 풀에 저장할 프리팹
    public int poolCount = 0; //초기화할 때 생성할 객체의 수
    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>(); //생성한 객체들을 저장할 리스트

    public void Initialize(Transform parent = null)
    {
        //PooledObject 객체를 초기화 할 때 처음 한번만 호출, 
        //poolCount에 지정한 수 만큼 객체를 생성해서 poolList에 추가하는 역할
        //parent=null이면 ObjectPool의 자식오브젝트로 지정, 다른 transform을 지정하면 그 transform의 자식이 됨
        for(int ix = 0; ix < poolCount; ++ix)
        {
            poolList.Add(CreateItem(parent));
        }
    }

    public void PushToPool(GameObject item, Transform parent = null)
    {
        //사용한 객체를 다시 오브젝트 풀에 반환하는 함수
        item.transform.SetParent(parent);
        item.SetActive(false);
        poolList.Add(item);
    }

    public GameObject PopFromPool(Transform parent = null)
    {
        //객체가 필요할 때 오브젝트 풀에 요청하는 용도
        if (poolList.Count == 0) //먼저 저장한 오브젝트가 남아있는지 확인
            poolList.Add(CreateItem(parent)); //없으면 새로 생성해서 추가
        GameObject item = poolList[0]; //미리 저장해둔 리스트에서 하나를 꺼내고
        poolList.RemoveAt(0); //리스트에서 첫번째 요소 제거해야함
        return item; //객체를 반환
    }

    private GameObject CreateItem(Transform parent = null)
    {
        //Prefab 변수에 지정된 게임 오브젝트를 생성하는 역할
        GameObject item = Object.Instantiate(prefab) as GameObject; //prefab에 지정한 정보를 바탕으로 게임오브젝트를 생성
        item.name = poolItemName; //poolItemName에 지정한 이름을 새로 생성한 게임오브젝트 이름으로 지정
        item.transform.SetParent(parent); //부모 계층을 지정한 뒤에
        item.SetActive(false); //생성한 오브젝트를 비활성화해서 나중에 쓸 준비
        return item;
    }
}

