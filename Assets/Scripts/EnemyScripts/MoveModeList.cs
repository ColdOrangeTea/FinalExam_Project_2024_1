using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMoveMode
{
    MoveToward,
    KeepAway,
    StayStill,
    Drift,
}
public class MoveModeList
{
    static public void MoveToward(GameObject target, GameObject enemy, float range, float moveSpeed)
    {
        float distance = Vector3.Distance(target.transform.position, enemy.transform.position);
        if (distance > range)
        {
            // Vector3 dir = target.transform.position - enemy.transform.position;
            Debug.Log("Enemy move toward to player.");
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        }
    }
    static public void KeepAway(GameObject target, GameObject enemy, float range, float moveSpeed)
    {
        float distance = Vector3.Distance(target.transform.position, enemy.transform.position);
        if (distance < range)
        {
            // Vector3 dir = target.transform.position - enemy.transform.position;
            Debug.Log("Enemy keep away from player.");
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, -moveSpeed * Time.deltaTime);

        }
    }
    static public void StayStill(GameObject target, GameObject enemy, float range, float moveSpeed)
    {

    }
    static public void Drift(GameObject target, GameObject enemy, float range, float moveSpeed)
    {

    }
}
