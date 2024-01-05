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
    void Start()
    {
        MoveTarget = GameObject.Find("Player");
    }
    void Update()
    {
        Move();
    }
    // private void FixedUpdate()
    // {
    //     Move();
    // }
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
        // 甚麼移動方式 就調用甚麼移動方法
    }
}
