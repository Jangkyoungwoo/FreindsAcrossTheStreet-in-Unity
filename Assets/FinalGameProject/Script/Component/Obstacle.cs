using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float RangeDestroy = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movex = MoveSpeed * Time.deltaTime; // x축으로 어느 정도 움직일지 설정
        this.transform.Translate(movex, 0f, 0f); //Obstacle 움직임

        if(this.transform.localPosition.x>= RangeDestroy)
        {
            GameObject.Destroy(this.gameObject);
        }
   
    }
}
