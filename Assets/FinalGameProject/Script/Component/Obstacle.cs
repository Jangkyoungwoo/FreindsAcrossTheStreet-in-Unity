using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

     float MoveSpeed = 3f;
    public float RangeDestroy = 12;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        float movex = MoveSpeed * Time.deltaTime; // x축으로 어느 정도 움직일지 설정
        this.transform.Translate(movex, 0f, 0f); //Obstacle 움직임

        if(this.transform.localPosition.x>= RangeDestroy)// 길의 끝에 도달하면 삭제
        {
            GameObject.Destroy(this.gameObject);
        }
   
    }
}
