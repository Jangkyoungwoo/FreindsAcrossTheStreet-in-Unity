using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody PlayerBody = null;
    public EnviromentMapManager EnviromentMapManagerCom = null;
    public GameManager manager;
    public AudioSource MoveSound;
    public bool isDead;

    void Start()
    {
        string[] templayer = new string[] { "Plant" };
        m_TreeLayerMask = LayerMask.GetMask(templayer);

        EnviromentMapManagerCom.UpdateForWardBackMove((int)this.transform.position.z);
    }

    public enum E_DirectionType
    {
        up=0,
        Down,
        Left,
        Right
    }

    [SerializeField]
    protected E_DirectionType m_DirectionType=E_DirectionType.up;
    protected int m_TreeLayerMask = -1;
    protected bool IsCheckDirectionViewMove(E_DirectionType p_movetype)
    {
        Vector3 direction = Vector3.zero;
        switch (p_movetype)
        {
            case E_DirectionType.up:
                {
                    direction = Vector3.forward;
                }
                break;
            case E_DirectionType.Down:
                {
                    direction = Vector3.back;
                }
                break;
            case E_DirectionType.Left:
                {
                    direction = Vector3.left;
                }
                break;
            case E_DirectionType.Right:
                {
                    direction = Vector3.right;

                }
                break;
            default:
                Debug.LogErrorFormat("SetActorMove Error:{0}", p_movetype);
                break;
        }

        RaycastHit hitObj;
        if(Physics.Raycast(this.transform.position, direction,out hitObj,1f, m_TreeLayerMask))
        {

            return false;

        }
        return true;
    }

    protected void SetPlayerMove(E_DirectionType p_movetype)
    {
        if (!IsCheckDirectionViewMove(p_movetype))
        {
            return; 
        }
        Vector3 offsetPos = Vector3.zero;

        switch (p_movetype)
        {
            case E_DirectionType.up:
            {
                offsetPos = Vector3.forward;
            }
            break;
            case E_DirectionType.Down:
           {
                offsetPos = Vector3.back;
           }
           break;
           case E_DirectionType.Left:
           {
                offsetPos = Vector3.left;
           }
           break;
           case E_DirectionType.Right:
           {
                offsetPos = Vector3.right;

           }
           break;
            default:
                Debug.LogErrorFormat("SetActorMove Error:{0}", p_movetype);
                break;
        }

        this.transform.position += offsetPos;
        m_RaftOffsetPos += offsetPos;

        EnviromentMapManagerCom.UpdateForWardBackMove((int)this.transform.position.z);
    }

    protected void InputUpdate()  // player 움직임 키 설정 
    {
        Vector3 offsetPos = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)&& !isDead)
        {
            transform.LookAt(transform.position + Vector3.forward);
            SetPlayerMove(E_DirectionType.up);
            MoveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isDead)
        {
            transform.LookAt(transform.position + Vector3.back);
            SetPlayerMove(E_DirectionType.Down);
            MoveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isDead)
        {
            transform.LookAt(transform.position + Vector3.left);
            SetPlayerMove(E_DirectionType.Left);
            MoveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isDead )
        {
            transform.LookAt(transform.position + Vector3.right);
            SetPlayerMove(E_DirectionType.Right);
            MoveSound.Play();
        }

    }

    Vector3 m_RaftOffsetPos = Vector3.zero;
    protected void UpdateRaft()
    {
        if (RaftObject == null)
        {
            return;
        }

        Vector3 playerPos = RaftObject.transform.position + m_RaftOffsetPos;
        this.transform.position = playerPos;
  
    }
    // Update is called once per frame
    void Update()
    {
        InputUpdate();
        UpdateRaft();
        fallingDown();
        playerMoveHolder();

    }

    [SerializeField]
    protected Raft RaftObject = null;
    protected Transform RaftCompareObj=null;
    protected Transform SmallRaftCompareObj = null;
    protected void OnTriggerEnter(Collider other)
    {

        if (other.tag.Contains("Raft"))
        {
            RaftObject = other.transform.parent.GetComponent<Raft>();

            if (RaftObject != null)
            {
                RaftCompareObj = RaftObject.transform;
                m_RaftOffsetPos = this.transform.position - RaftObject.transform.position;
            }
            return;
        }

        if (other.tag.Contains("Crash"))
        {
            onDie();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if(other.tag.Contains("Raft") && RaftCompareObj == other.transform.parent)
        {
            RaftCompareObj = null;
            RaftObject = null;
            m_RaftOffsetPos = Vector3.zero;

        }
    }

    void onDie()
    {
        isDead = true;
        manager.GameOver();
    }

    void fallingDown()
    {
        if (PlayerBody.position.y < -0.5f)
        {
            onDie();
        }
    }

    void playerMoveHolder()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isDead)
            isDead = true;
        else if (Input.GetKeyDown(KeyCode.Escape) && isDead)
            isDead = false;
    }
    
}
