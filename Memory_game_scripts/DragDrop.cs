using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public static int detect_drop;
    public Vector2 position;
    public static Vector2 history;
    GameObject infinite_spawner;

    private void Awake()
    {
        rectTransform=GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        position = transform.localPosition;
        //Debug.Log("Position of item: " + position);

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        
        Debug.Log("position of gameobject " + position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEngDrag");
        Debug.Log("position of gameobject " + position);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts=true;
        Destroy(gameObject);
        //transform.position = position;
        //detect_drop = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        infinite_spawner = Instantiate(gameObject, position, transform.rotation);
        infinite_spawner.transform.localScale = Vector3.one;
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        infinite_spawner.transform.SetParent(canvas.transform, false);
        //Debug.Log("OnPointerDown");
    }
    

}
