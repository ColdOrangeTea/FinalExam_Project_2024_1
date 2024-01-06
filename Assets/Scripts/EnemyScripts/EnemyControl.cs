using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int EnemyHP = 3;
    public GameObject MoveTarget;
    public GameObject EnemyBullet;
    public EnemyMoveMode moveMode;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float detectRange = 3f;

    public float yOriginPos;
    [Header("來回移動")]
    //bool isToPoint1 = false;
    //[SerializeField] float time = 1;
    //public Transform Pivot_Environment;
    //public Vector3 wayPoint1;
    //public Vector3 wayPoint2;

    void Start()
    {
        yOriginPos = transform.position.y;
        MoveTarget = GameObject.Find("Player");
    }
    //void Update()
    //{
    //    Move();
    //}
    private void FixedUpdate()
    {
        Move();
    }
    public void TakeDamage(int damageNum)
    {
        if (EnemyHP - damageNum > 0)
        {
            EnemyHP -= damageNum;
        }
        else
        {
            EnemyHP = 0;
        }
    }
    public virtual void Shot()
    {

    }

    public void Move()
    {
        if (moveMode == EnemyMoveMode.MoveToward)
        {
            MoveModeList.MoveToward(MoveTarget, this.gameObject, detectRange, moveSpeed);
        }
        else if (moveMode == EnemyMoveMode.KeepAway)
        {
            MoveModeList.KeepAway(MoveTarget, this.gameObject, detectRange, moveSpeed);
        }
        else if (moveMode == EnemyMoveMode.BackAndForth)
        {
            MoveModeList.BackAndForth( this.gameObject, moveSpeed,yOriginPos);
        }
        // 甚麼移動方式 就調用甚麼移動方法
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Pivot_Environment.transform.position + wayPoint1, 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Pivot_Environment.transform.position + wayPoint2, 0.3f);

    }
}
