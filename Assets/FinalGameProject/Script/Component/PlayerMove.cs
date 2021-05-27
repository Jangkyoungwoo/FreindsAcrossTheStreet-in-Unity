using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody PlayerBody = null;
    // Start is called before the first frame update
    void Start()
    {
        
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

    protected void SetPlayerMove(E_DirectionType p_movetype)
    {
        Vector3 offsetPos = Vector3.zero;

        switch (p_movetype)
        {
            case E_DirectionType.up:
                offsetPos = Vector3.forward;
                break;
            case E_DirectionType.Down:
                offsetPos = Vector3.back;
                break;
            case E_DirectionType.Left:
                offsetPos = Vector3.left;
                break;
            case E_DirectionType.Right:
                offsetPos = Vector3.right;
                break;
            default:
                Debug.LogErrorFormat("SetActorMove Error:{0}", p_movetype);
                break;
        }

        this.transform.position += offsetPos;
    }

    // Update is called once per frame
   void Update()
    {
        Vector3 offsetPos = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetPlayerMove(E_DirectionType.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetPlayerMove(E_DirectionType.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetPlayerMove(E_DirectionType.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetPlayerMove(E_DirectionType.Right);
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.LogFormat("OnTrigger : {0},{1}"
                ,other.name
                ,other.tag);

            if (other.tag.Contains("Crash"))
            {
                Debug.LogFormat("부딪혔다!!");
            }
        }

   
    }
}
