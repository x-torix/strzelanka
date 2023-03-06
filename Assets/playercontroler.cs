using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroler : MonoBehaviour
{
    Vector2 movementVector;
    public float bulletSpeed = 20f;
    public GameObject bulletPrefab;
    Transform bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
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

        Debug.Log(movementVector.ToString());
    }
    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed,ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }
}
