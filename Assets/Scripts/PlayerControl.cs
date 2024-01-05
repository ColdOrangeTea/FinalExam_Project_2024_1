using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb; // 其實沒用到，但為了能和其他Collider碰撞還是加上了Rigidbody
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 turnGround;
    [SerializeField] private float startTime = 0; // 紀錄按下按鍵發射時的時間
    [SerializeField] private float shootingColdDownTimer = 0; // 射擊的冷卻計時器
    [SerializeField] private float shootingInterval = 1;
    public GameObject PlayerBullet;
    public Transform FirePoint;

    // [SerializeField] private float xRange = 5f; // X軸角色移動限制
    // [SerializeField] private float yRange = 5f; // Y軸角色移動限制
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        shootingColdDownTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            Shot();
        }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            Move();
        }
    }

    private void Shot()
    {

        if (shootingColdDownTimer > shootingInterval || startTime == 0)
        {
            Debug.Log("shooting.");
            shootingColdDownTimer = 0;
            Instantiate(PlayerBullet, FirePoint.position, Quaternion.identity);
        }

        if (startTime != 0) return; // 初次射擊
        startTime += Time.deltaTime; // 記錄當下時間   

    }

    private void Move()
    {
        //控制水平方向
        float horizontalThrow = Input.GetAxis("Horizontal");
        float xOffset = horizontalThrow * Time.deltaTime * speed;
        float newXPos = transform.localPosition.x + xOffset;

        //控制垂直方向
        float verticalThrow = Input.GetAxis("Vertical");
        float yOffset = verticalThrow * Time.deltaTime * speed;
        float newYPos = transform.localPosition.z + yOffset;

        // Debug.Log("xOffset:" + xOffset + "  yOffset:" + yOffset);

        // 更新位置 Unity 3D中是X、Z軸向水平，Y軸是垂直
        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, newYPos);

        // 控制角色以自身為圓心的移動的範圍(用Mathf.Clamp限制數值大小)
        // float clampXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        // float clampYPos = Mathf.Clamp(newYPos, -yRange, yRange);
        // transform.localPosition = new Vector3(clampXPos, transform.localPosition.y, clampYPos);


    }
}
