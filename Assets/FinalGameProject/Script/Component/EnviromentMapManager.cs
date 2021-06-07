using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMapManager : MonoBehaviour
{
    public enum E_EnviromentType
    {
        Grass=0,
        Road,
        Water,

        Max
    }

    public enum E_LastRoadType
    {
        Grass=0,
        Road,

        Max
    }
    //public GameObject[] EnviromentObjectArray;
    [Header("[복제용길]")]
    public Road CarRoad = null;
    public Road BusRoad = null;
    public Road WaterRoad = null;
    public Road SmallWaterRoad = null;
    public GrassSpawn GrassRoad = null;
    public Transform ParentTransform = null;

    public int MinPosZ = -20;
    public int MaxPosZ = 20;

    public int FrontOffsetPosZ = 10;
    public int BackOffsetPosZ = 10;

    void Start()
    {
        
    }

    public int GroupRandomRoadLine(int p_posz)
    {
        int randomCount = Random.Range(1, 4); // 길이 복제 되는 정도를 조정

        for(int i=0; i<randomCount; ++i)
        {
            GenerateRoadLine(p_posz + i); // 복제된 길들이 겹치지 않게 생성
        }

        return randomCount;
    }

    public int GroupRandomBusRoadLine(int p_posz)
    {
        int randomCount = Random.Range(1, 4);

        for (int i = 0; i < randomCount; ++i)
        {
            GenerateBusRoadLine(p_posz + i);
        }

        return randomCount;
    }

    public int GroupRandomWaterLine(int p_posz)
    {
        int randomCount = Random.Range(1, 3);

        for (int i = 0; i < randomCount; ++i)
        {
            GenerateWaterLine(p_posz + i);
        }

        return randomCount;
    }

    public int GroupRandomSmallWaterLine(int p_posz)
    {
        int randomCount = Random.Range(1, 3);

        for (int i = 0; i < randomCount; ++i)
        {
            GenerateSmallWaterLine(p_posz + i);
        }

        return randomCount;
    }

    public int GroupRandomGrassLine(int p_posz)
    {
        int randomCount = Random.Range(1, 3);

        for (int i = 0; i < randomCount; ++i)
        {
            GenerateGrassLine(p_posz + i);
        }

        return randomCount;
    }
    public void GenerateRoadLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(CarRoad.gameObject); //GameObj 복제
        cloneObj.SetActive(true);
        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)p_posz;
        cloneObj.transform.SetParent(ParentTransform);
        cloneObj.transform.position = offsetPos;

        int randomrot = Random.Range(0, 2);
        if (randomrot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0f); //장애물들이 반대 방향으로 나오도록 설정
        }
        cloneObj.name = "RoadLine_" + p_posz.ToString();

        m_LineMapList.Add(cloneObj.transform); 
        m_LineMapDic.Add(p_posz, cloneObj.transform);
    }
    public void GenerateBusRoadLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(BusRoad.gameObject);
        cloneObj.SetActive(true);
        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)p_posz;
        cloneObj.transform.SetParent(ParentTransform);
        cloneObj.transform.position = offsetPos;

        int randomrot = Random.Range(0, 2);
        if (randomrot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }
        cloneObj.name = "RoadLine_" + p_posz.ToString();

        m_LineMapList.Add(cloneObj.transform);
        m_LineMapDic.Add(p_posz, cloneObj.transform);
    }
    public void GenerateWaterLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(WaterRoad.gameObject);
        cloneObj.SetActive(true);
        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)p_posz;
        cloneObj.transform.SetParent(ParentTransform);
        cloneObj.transform.position = offsetPos;

        int randomrot = Random.Range(0, 2);
        if (randomrot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }
        cloneObj.name = "WaterLine_" + p_posz.ToString();

        m_LineMapList.Add(cloneObj.transform);
        m_LineMapDic.Add(p_posz, cloneObj.transform);
    }
    public void GenerateSmallWaterLine(int p_posz)
    {
        GameObject cloneObj = GameObject.Instantiate(SmallWaterRoad.gameObject);
        cloneObj.SetActive(true);
        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)p_posz;
        cloneObj.transform.SetParent(ParentTransform);
        cloneObj.transform.position = offsetPos;

        int randomrot = Random.Range(0, 2);
        if (randomrot == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }
        cloneObj.name = "SmallWaterLine_" + p_posz.ToString();

        m_LineMapList.Add(cloneObj.transform);
        m_LineMapDic.Add(p_posz, cloneObj.transform);
    }
    public void GenerateGrassLine(int p_posz)
    {
        GameObject cloneObj=GameObject.Instantiate(GrassRoad.gameObject);
        cloneObj.SetActive(true);
        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)p_posz;
        cloneObj.transform.SetParent(ParentTransform);
        cloneObj.transform.position = offsetPos;

        cloneObj.name = "GrassLine_" + p_posz.ToString();

        m_LineMapList.Add(cloneObj.transform);
        m_LineMapDic.Add(p_posz, cloneObj.transform);
    }


    protected E_LastRoadType m_LastRoadType = E_LastRoadType.Max;
    protected List<Transform> m_LineMapList = new List<Transform>();
    protected Dictionary<int, Transform> m_LineMapDic = new Dictionary<int, Transform>();
    protected int m_LastLinePos = 0;

    [SerializeField]
    protected int m_MinLine = 0;
    public int m_DeleteLine = 10;
    public int m_BackOffsetLineCount = 20;
    public void UpdateForWardBackMove(int p_posz) //p_posz값에 의해서 지형이 생성될 수 있도록 설정
    {
        if (m_LineMapList.Count<=0)
        {
            m_LastRoadType = E_LastRoadType.Grass;
            m_MinLine = MinPosZ;
            int i = 0;
            //초기용 라인들 세팅
            for(i= MinPosZ; i< MaxPosZ; ++i)
            {
                int offsetVal = 0;
                if (i <= 0)
                {
                    GenerateGrassLine(i);
                }
                else
                {
                    if (m_LastRoadType == E_LastRoadType.Grass)
                    {
                        int randomVal = Random.Range(0, 4);
                        if(randomVal == 0)
                        {
                            offsetVal = GroupRandomWaterLine(i);
                        }
                        else if (randomVal == 1)
                        {
                            offsetVal = GroupRandomSmallWaterLine(i);
                        }
                        else if (randomVal == 2)
                        {
                            offsetVal = GroupRandomBusRoadLine(i);
                        }
                        else
                        {
                            offsetVal = GroupRandomRoadLine(i);
                        }
                        m_LastRoadType = E_LastRoadType.Road;
                    }
                    else
                    {
                        offsetVal = GroupRandomGrassLine(i);

                        m_LastRoadType = E_LastRoadType.Grass;
                    }
                    i += offsetVal - 1;
                }
            }
            m_LastLinePos = i;
        }

        //새롭게 생성
        if(m_LastLinePos < p_posz + FrontOffsetPosZ)
        {
            int offsetVal = 0;
                if (m_LastRoadType == E_LastRoadType.Grass)
                {
                    int randomVal = Random.Range(0, 4);
                    if (randomVal == 0)
                    {
                        offsetVal = GroupRandomWaterLine(m_LastLinePos);
                    }
                    else if (randomVal == 1)
                    {
                        offsetVal = GroupRandomSmallWaterLine(m_LastLinePos);
                    }
                    else if (randomVal == 2)
                    {
                        offsetVal = GroupRandomBusRoadLine(m_LastLinePos);
                    }
                    else
                    {
                        offsetVal = GroupRandomRoadLine(m_LastLinePos);
                    }
                    m_LastRoadType = E_LastRoadType.Road;
                }
                else
                {
                    offsetVal = GroupRandomGrassLine(m_LastLinePos);

                    m_LastRoadType = E_LastRoadType.Grass;
                }
                m_LastLinePos += offsetVal;
        }
        //많이 지나갔으면 지우기
        if (p_posz - m_BackOffsetLineCount > m_MinLine - m_DeleteLine)
        {
            int count = m_MinLine + m_DeleteLine;
            for(int i= m_MinLine; i<count; ++i)
            {
                RemoveLine(i);
            }

            m_MinLine += m_DeleteLine;
        }
    }

    void RemoveLine(int p_posz)
    {
        if (m_LineMapDic.ContainsKey(p_posz))
        {
            Transform transObj = m_LineMapDic[p_posz];
            GameObject.Destroy(transObj.gameObject);
            m_LineMapList.Remove(transObj);
            m_LineMapDic.Remove(p_posz);

        }
        else
        {
            Debug.LogErrorFormat("RemoveLine Error:{0}", p_posz);
        }
    }
   
}
