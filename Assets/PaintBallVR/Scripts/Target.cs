using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField]
    Collider targetAreaCollider;

    public RawImage splashImage;

    public List<string> paintNames;

    string currentPaintName;

    // Start is called before the first frame update
    void Start()
    {
        currentPaintName = paintNames[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("PaintBullet"))
        {   
            var paintBulletColor = collision.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
            splashImage.color = paintBulletColor;
            splashImage.gameObject.SetActive(true);

            if (collision.gameObject.name == currentPaintName)
            {
                GameManager.Instance.AddScore();
                ChangeTargetPosition(targetAreaCollider);
            }
            else
            {
                GameManager.Instance.DeductScore();
            }
            Destroy(collision.gameObject);




        }
    }
    private void ChangeTargetPosition(Collider targetArea)
    {
        float x = Random.Range(targetArea.bounds.min.x, targetArea.bounds.max.x);
        float y = Random.Range(targetArea.bounds.min.y, targetArea.bounds.max.y);
        float z = Random.Range(targetArea.bounds.min.z, targetArea.bounds.max.z);

        splashImage.gameObject.SetActive(false);

        ChangeColor();
        transform.position = new Vector3(x, y, z);
    }

    void ChangeColor()
    {
        currentPaintName = paintNames[GetRandomValue()];
        if (currentPaintName.Equals("PaintContainer_Red"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (currentPaintName.Equals("PaintContainer_Green"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (currentPaintName.Equals("PaintContainer_Blue"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (currentPaintName.Equals("PaintContainer_Yellow"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    int GetRandomValue()
    {
        int val = Random.Range(0, paintNames.Count);

        return val;
    }

}
