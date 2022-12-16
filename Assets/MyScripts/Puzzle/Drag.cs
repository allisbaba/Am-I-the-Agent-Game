using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    GameObject[] kutu_dizisi;
    admin manage;
    Vector2 baslangic_pozisyonu;

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
           (RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    private void Start()
    {
        baslangic_pozisyonu = transform.position;
        kutu_dizisi = GameObject.FindGameObjectsWithTag("box");
        manage = GameObject.Find("admin").GetComponent<admin>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject kutu in kutu_dizisi)
            {
                if (kutu.name == gameObject.name)
                {
                    float mesafe = Vector2.Distance(kutu.transform.position, transform.position);
                    if (mesafe <= 7)
                    {
                        transform.position = kutu.transform.position;
                        manage.number_increase();
                        this.enabled = false;
                    }
                    else
                    {
                        transform.position = baslangic_pozisyonu;
                    }
                }
            }
        }
    }
}
