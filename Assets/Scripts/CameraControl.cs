using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject CameraTarget;
    public float Dumping = 1;
    public float RotateSpeed = 5;
    public float Distance = 5;
    public float Height = 3;
    // [SerializeField] private Vector3 offset;
    [SerializeField] Vector3 currentPos;

    void Start()
    {
        // offset = CameraTarget.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = CameraTarget.transform.position;
    }
    private void FixedUpdate()
    {
        CameraFollow();
    }
    private void CameraFollow()
    {

        Vector3 desiredPosition = CameraTarget.transform.position;
        if (transform.position == desiredPosition) return;
        // Debug.Log("動 " + desiredPosition + "  " + transform.position);
        desiredPosition -= Distance * CameraTarget.transform.forward;
        desiredPosition += new Vector3(0, Height, 0);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * Dumping);
        // transform.LookAt(CameraTarget.transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, CameraTarget.transform.rotation, RotateSpeed);

        // Mathf.Epsilon = 0.401298E-45 bool檢查無用qq
        // float dis = Mathf.Abs(Vector3.Distance(transform.position, CameraTarget.transform.position));
        // bool a = dis <= dis + Mathf.Epsilon;
        // Debug.Log("轉 " + a + " " + dis + " " + dis + Mathf.Epsilon);
        // if (dis <= dis + Mathf.Epsilon) // 強制用Lerp方法移動的物件在趨近位置時到位
        // {
        //     Debug.Log("轉 " + dis + " " + dis + Mathf.Epsilon);
        //     transform.position = desiredPosition;
        // }
    }
}
