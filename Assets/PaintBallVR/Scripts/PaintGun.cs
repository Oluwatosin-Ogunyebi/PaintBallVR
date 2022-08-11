using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGun : MonoBehaviour
{   
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float shootForce;

    GameObject tempBullet;
    // Start is called before the first frame update
    public void Shoot()
    {
        tempBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        tempBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);
        Destroy(tempBullet, 5f);
    }
}
