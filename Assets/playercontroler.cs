using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playercontroler : MonoBehaviour
{
    float hp = 10;
    Vector2 movementVector;
    public float playerSpeed = 2;
    public float bulletSpeed = 20;
    public GameObject bulletPrefab;
    Transform bulletSpawn;
    public GameObject hpBar;
    Scrollbar hpScrollBar;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
        hpScrollBar = hpBar.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * movementVector.x);
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime);
    }
    void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();

    }
    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed,ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            hp--;
            if (hp <= 0) Die();
            hpScrollBar.size = hp / 10;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized * 5, ForceMode.Impulse);
        }
    }
    void Die()
    {
        GetComponent<BoxCollider>().enabled = false;
        transform.Translate(Vector3.up);
        transform.Rotate(Vector3.right * -90);

    }
}
