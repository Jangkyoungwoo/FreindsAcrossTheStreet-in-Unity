using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform CloneTarget = null; //Obstacle 복사할 요소
    public Transform GenerationPos = null; //어디에서 생성될 것인지 설정
    public int GenerationPersent = 50;

    public float CloneDelaySec = 1f; //몇초마다 한번씩 생길 것인지 설정
    protected float NextSecToClone = 0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float setTime = Time.time;
        if (NextSecToClone <= setTime) //원하는 시간마다 clone을 생성
        {
            int randomval = Random.Range(0, 100);
            if(randomval <= GenerationPersent)// 어느 타이밍에 무작위로 GenerationPersent만큼 생성
            { 
                CloneObstacle();  
            }
            NextSecToClone = setTime + CloneDelaySec;
        }
    }

    void CloneObstacle()
    {
        Transform cloneTrans = GenerationPos;
        Vector3 offsetPos = cloneTrans.position; //어디에서 만들 것인지
        offsetPos.y = 1f; // y좌표의 값을 1으로 지정해서 floor와 붙어 있게 설정
       
        GameObject cloneObj = GameObject.Instantiate(CloneTarget.gameObject
            ,offsetPos
            , GenerationPos.rotation
            ,this.transform); // 새로운 Object를 생성하는 함수를 사용

        cloneObj.SetActive(true);
    }
}
