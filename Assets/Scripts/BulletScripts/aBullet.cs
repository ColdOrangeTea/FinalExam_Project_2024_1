using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aBullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float lifeTime = 4f;
    [SerializeField] private float force = 50f;
    [SerializeField] private int damage = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * force;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetDamage() // 敵人那邊的腳本可透過這個方法取得這個子彈造成的傷害數
    {
        int damage = this.damage;
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
