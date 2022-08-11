using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBullet : MonoBehaviour
{   
    [SerializeField]
    GameObject bullet;

    private void Awake()
    {
        bullet.GetComponent<MeshRenderer>().material.color = GameManager.Instance.paintColor;
        bullet.GetComponent<TrailRenderer>().startColor = GameManager.Instance.paintColor;
        bullet.GetComponent<TrailRenderer>().endColor = GameManager.Instance.paintColor;
        this.gameObject.name = GameManager.Instance.paintColorName;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ColorTargets"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("ArenaObstacles"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = bullet.GetComponent<MeshRenderer>().material.color;
        }

        Destroy(this.gameObject);
    }
}
