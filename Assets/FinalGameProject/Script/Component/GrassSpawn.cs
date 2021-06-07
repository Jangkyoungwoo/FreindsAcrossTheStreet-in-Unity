using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{

    public List<Transform> EnviromentObjectList = new List<Transform>();
    public int startMinVal = -12;  //시작과 끝을 설정
    public int startMaxVal = 12;

    public int SpawnCreateRandom = 20; //생성되는 비율

    void GeneratorRoundBlock() // 주변만 막는 부분
    {
        int randomIndex = 0;
        GameObject tempClone = null;
        Vector3 offsetPos = Vector3.zero;

        float posz = this.transform.position.z;
        for (int i = startMinVal; i < startMaxVal; ++i)
        {
            if (i<-5 || i>5)
            {
                randomIndex = Random.Range(0, EnviromentObjectList.Count); // 어떤 것을 기준으로 만들것이냐
                tempClone = GameObject.Instantiate(EnviromentObjectList[randomIndex].gameObject);
                tempClone.SetActive(true);
                offsetPos.Set(i, 0.5f, 0f);

                tempClone.transform.SetParent(this.transform);
                tempClone.transform.localPosition = offsetPos;
            }
        }
    }

    void GeneratorBackBlock()// 전부 다 막는 부분
    {
        int randomIndex = 0;
        GameObject tempClone = null;
        Vector3 offsetPos = Vector3.zero;
        
        float posz = this.transform.position.z;
        for (int i = startMinVal; i < startMaxVal; ++i)
        {
            randomIndex = Random.Range(0, EnviromentObjectList.Count); // 어떤 것을 기준으로 만들것이냐
            tempClone = GameObject.Instantiate(EnviromentObjectList[randomIndex].gameObject);
            tempClone.SetActive(true);
            offsetPos.Set(i, 0.5f, 0f);

            tempClone.transform.SetParent(this.transform);
            tempClone.transform.localPosition = offsetPos;  
        }
    }

    void GeneratorTree()
    {
        int randomIndex = 0;
        int randomVal = 0;
        GameObject tempClone = null;
        Vector3 offsetPos = Vector3.zero;

        float posz = this.transform.position.z;
        for (int i = startMinVal; i < startMaxVal; ++i)
        {
            randomVal = Random.Range(0, 100);
            if (randomVal < SpawnCreateRandom)
            {
                randomIndex = Random.Range(0, EnviromentObjectList.Count); // 어떤 것을 기준으로 만들것이냐
                tempClone = GameObject.Instantiate(EnviromentObjectList[randomIndex].gameObject); // cloneObject 복제
                tempClone.SetActive(true);
                offsetPos.Set(i, 1f, 0f);

                tempClone.transform.SetParent(this.transform);
                tempClone.transform.localPosition = offsetPos;
            }
        }
    }
    void GeneratorEnviroment()
    {
        if (this.transform.position.z <= -4)
        {
            GeneratorBackBlock();
        }
        else if (this.transform.position.z <= 0)
        {
            GeneratorRoundBlock();
        }
        else
        {
            GeneratorTree();
        }

    }
    void Start()
    {
        GeneratorEnviroment();
    }


    void Update()
    {

    }
}
