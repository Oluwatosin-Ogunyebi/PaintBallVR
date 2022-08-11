using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintContainer : MonoBehaviour
{
    public Color paintColor;

    public List<GameObject> paintContainers;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PaintContainer"))
        {
            paintColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
            GameManager.Instance.paintColorName = other.gameObject.name;
            Destroy(other.gameObject);
            this.GetComponent<MeshRenderer>().material.color = paintColor;
            GameManager.Instance.paintColor = paintColor;
            Invoke("SpawnNewPaintContainer", 4f);
        }
    }


    public void SpawnNewPaintContainer()
    {
        GameObject newPaint = Instantiate(paintContainers[GetRandomValue()]);
        newPaint.name = newPaint.name.Replace("(Clone)", "").Trim();
    }
    int GetRandomValue()
    {
        int val = Random.Range(0, paintContainers.Count);

        return val;
    }
}
