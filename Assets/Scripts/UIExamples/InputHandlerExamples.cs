using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputHandlerExamples : Selectable, 
                                    IPointerClickHandler, 
                                    IDragHandler, 
                                    IScrollHandler, 
                                    IBeginDragHandler,
                                    IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"[Drag] Delta: {eventData.delta}");
        Debug.Log($"[Drag] Press Position: {eventData.pressPosition}");
        Debug.Log($"[Drag] Oggetto Drag: {eventData.pointerDrag?.name}");
        Debug.Log($"[Drag] In Movimento: {eventData.IsPointerMoving()}");
        eventData.pointerCurrentRaycast.gameObject.transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"[Click] Posizione: {eventData.position}");
        Debug.Log($"[Click] Pulsante: {eventData.button}");
        Debug.Log($"[Click] N. Click: {eventData.clickCount}");
        Debug.Log($"[Click] Oggetto Colpito: {eventData.pointerCurrentRaycast.gameObject?.name}");

        eventData.Use();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log($"[Down] Pressione: {eventData.pressure}");
        Debug.Log($"[Down] ID Puntatore: {eventData.pointerId}");
        Debug.Log($"[Down] ObjectHovered: {eventData.hovered.Count}");
        eventData.hovered.ForEach((value) => Debug.Log($"{value.name}"));
        
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log($"[Scroll] Delta: {eventData.scrollDelta}");
        Debug.Log($"[Scroll] IsScrolling: {eventData.IsScrolling()}");
        
    }

    public override void OnSelect(BaseEventData baseEventData)
    {
        base.OnSelect(baseEventData);
        Debug.Log($"Current Input Module: {baseEventData.currentInputModule}");
        Debug.Log($"Selected Object: {baseEventData.selectedObject}");
        Debug.Log($"Used: {baseEventData.used}");
        baseEventData.Use();
        baseEventData.Reset(); 
    }

    public override void OnMove(AxisEventData eventData)
    {
        Debug.Log($"[Move] Vettore: {eventData.moveVector}");
        Debug.Log($"[Move] Direzione: {eventData.moveDir}");

        var msg = eventData.moveDir switch
        {
            MoveDirection.Left => "Navigazione: Sinistra",
            MoveDirection.Up => "Navigazione: Su",
            MoveDirection.Right => "Navigazione: Destra",
            MoveDirection.Down => "Navigazione: Giù",
            _ => "None"
        };
        
        Debug.Log(msg);
    }
}
