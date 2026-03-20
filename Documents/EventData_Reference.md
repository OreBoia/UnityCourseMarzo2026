# Unity EventSystem — Riferimento EventData

> Namespace: `UnityEngine.EventSystems`
> Gerarchia: `BaseEventData` → `PointerEventData` / `AxisEventData`

---

## 1. BaseEventData

Classe base da cui derivano tutti i tipi di evento. Contiene le informazioni condivise da ogni evento del sistema.

### Proprietà

| Nome | Tipo | Descrizione | Esempio |
|------|------|-------------|---------|
| `currentInputModule` | `BaseInputModule` | Il modulo di input che ha generato questo evento. | `Debug.Log(eventData.currentInputModule.name);` |
| `selectedObject` | `GameObject` | L'oggetto attualmente selezionato nell'EventSystem. | `GameObject sel = eventData.selectedObject;` |
| `used` | `bool` (read-only) | Indica se l'evento è già stato consumato tramite `Use()`. | `if (eventData.used) return;` |

### Metodi

| Nome | Firma | Descrizione | Esempio |
|------|-------|-------------|---------|
| `Use()` | `void Use()` | Segna l'evento come consumato. Gli handler successivi possono verificarlo con `used`. | `eventData.Use();` |
| `Reset()` | `virtual void Reset()` | Reimposta i dati dell'evento ai valori di default (utilizzato internamente dal pool). | `eventData.Reset();` |

---

## 2. PointerEventData

Estende `BaseEventData`. Trasporta tutte le informazioni relative a eventi del puntatore: mouse, touch, stylus.

### Enumerazioni interne

| Enum | Valori | Descrizione |
|------|--------|-------------|
| `PointerEventData.InputButton` | `Left`, `Right`, `Middle` | Il pulsante del mouse che ha scatenato l'evento. |
| `PointerEventData.FramePressState` | `Pressed`, `Released`, `PressedAndReleased`, `NotChanged` | Stato del pulsante nel frame corrente. |

### Proprietà

| Nome | Tipo | Descrizione | Esempio |
|------|------|-------------|---------|
| `pointerId` | `int` | ID univoco del puntatore (touch finger ID o ID mouse). | `Debug.Log("Pointer ID: " + eventData.pointerId);` |
| `position` | `Vector2` | Posizione attuale del puntatore in screen space. | `Vector2 pos = eventData.position;` |
| `delta` | `Vector2` | Delta di movimento del puntatore rispetto al frame precedente. | `transform.position += (Vector3)eventData.delta;` |
| `pressPosition` | `Vector2` | Posizione del puntatore al momento della pressione. | `Vector2 startPos = eventData.pressPosition;` |
| `clickTime` | `float` | `Time.unscaledTime` dell'ultimo click. | `float t = eventData.clickTime;` |
| `clickCount` | `int` | Numero di click consecutivi (es. 2 = doppio click). | `if (eventData.clickCount == 2) Debug.Log("Doppio click!");` |
| `scrollDelta` | `Vector2` | Delta della rotella di scorrimento. | `float scroll = eventData.scrollDelta.y;` |
| `button` | `InputButton` | Pulsante che ha scatenato l'evento (`Left`, `Right`, `Middle`). | `if (eventData.button == PointerEventData.InputButton.Right) { }` |
| `dragging` | `bool` | `true` se è in corso un'operazione di drag. | `if (eventData.dragging) Debug.Log("Dragging!");` |
| `useDragThreshold` | `bool` | Se `true`, il drag parte solo dopo aver superato la soglia definita nell'EventSystem. | `eventData.useDragThreshold = false;` |
| `eligibleForClick` | `bool` | `true` se il puntatore può ancora generare un click (non ha ecceduto la soglia di drag). | `bool canClick = eventData.eligibleForClick;` |
| `pointerEnter` | `GameObject` | L'oggetto sotto il puntatore in questo momento. | `Debug.Log(eventData.pointerEnter?.name);` |
| `pointerPress` | `GameObject` | L'oggetto su cui è stato premuto il pulsante nel frame corrente. | `GameObject pressed = eventData.pointerPress;` |
| `rawPointerPress` | `GameObject` | L'oggetto colpito dal raycast al momento della pressione, prima di qualsiasi filtraggio. | `GameObject raw = eventData.rawPointerPress;` |
| `lastPress` | `GameObject` | L'oggetto premuto nell'evento precedente. | `GameObject prev = eventData.lastPress;` |
| `pointerDrag` | `GameObject` | L'oggetto che sta ricevendo gli eventi di drag. | `Debug.Log(eventData.pointerDrag?.name);` |
| `pointerCurrentRaycast` | `RaycastResult` | Risultato del raycast nella posizione corrente del puntatore. | `GameObject hit = eventData.pointerCurrentRaycast.gameObject;` |
| `pointerPressRaycast` | `RaycastResult` | Risultato del raycast al momento della pressione. | `Vector3 wp = eventData.pointerPressRaycast.worldPosition;` |
| `hovered` | `List<GameObject>` | Lista di tutti gli oggetti attualmente sotto il puntatore. | `foreach (var go in eventData.hovered) Debug.Log(go.name);` |
| `pressure` | `float` | Pressione esercitata (stilografica o touch con pressione). Range `[0, 1]`. | `float p = eventData.pressure;` |
| `tangentialPressure` | `float` | Pressione tangenziale (solo stilografica). | `float tp = eventData.tangentialPressure;` |
| `altitudeAngle` | `float` | Angolo di altitudine della stilografica (radianti). | `float alt = eventData.altitudeAngle;` |
| `azimuthAngle` | `float` | Angolo di azimut della stilografica (radianti). | `float az = eventData.azimuthAngle;` |
| `twist` | `float` | Rotazione della stilografica sull'asse del pennino (radianti). | `float tw = eventData.twist;` |
| `radius` | `Vector2` | Raggio del contatto touch. | `Vector2 r = eventData.radius;` |
| `radiusVariance` | `Vector2` | Varianza del raggio touch. | `Vector2 rv = eventData.radiusVariance;` |

### Metodi

| Nome | Firma | Descrizione | Esempio |
|------|-------|-------------|---------|
| `IsPointerMoving()` | `bool IsPointerMoving()` | Ritorna `true` se il delta del puntatore è diverso da zero. | `if (eventData.IsPointerMoving()) Debug.Log("In movimento");` |
| `IsScrolling()` | `bool IsScrolling()` | Ritorna `true` se `scrollDelta` è diverso da zero. | `if (eventData.IsScrolling()) Debug.Log("Scrolling");` |
| `GetCurrentGameObject()` | `GameObject GetCurrentGameObject()` | Ritorna il `GameObject` attualmente sotto il puntatore (`pointerCurrentRaycast.gameObject`). | `GameObject go = eventData.GetCurrentGameObject();` |
| `Use()` *(ereditato)* | `void Use()` | Segna l'evento come consumato. | `eventData.Use();` |
| `Reset()` *(ereditato)* | `virtual void Reset()` | Reimposta tutti i campi ai valori di default. | `eventData.Reset();` |

### Esempio completo — PointerEventData

```csharp
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerInfoLogger : MonoBehaviour,
    IPointerDownHandler,
    IPointerClickHandler,
    IDragHandler,
    IScrollHandler
{
    // Stampa informazioni al click
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"[Click] Posizione: {eventData.position}");
        Debug.Log($"[Click] Pulsante: {eventData.button}");
        Debug.Log($"[Click] N. click: {eventData.clickCount}");
        Debug.Log($"[Click] Oggetto colpito: {eventData.pointerCurrentRaycast.gameObject?.name}");

        // Consuma l'evento per impedire ad altri handler di processarlo
        eventData.Use();
    }

    // Stampa informazioni durante il drag
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"[Drag] Delta: {eventData.delta}");
        Debug.Log($"[Drag] Posizione press: {eventData.pressPosition}");
        Debug.Log($"[Drag] Oggetto drag: {eventData.pointerDrag?.name}");
        Debug.Log($"[Drag] InMovimento: {eventData.IsPointerMoving()}");
    }

    // Stampa informazioni allo scroll
    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log($"[Scroll] Delta scroll: {eventData.scrollDelta}");
        Debug.Log($"[Scroll] Sta scrollando: {eventData.IsScrolling()}");
    }

    // Stampa pressione (utile con touch/stylus)
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"[Down] Pressione: {eventData.pressure}");
        Debug.Log($"[Down] ID puntatore: {eventData.pointerId}");
        Debug.Log($"[Down] Oggetti hovered: {eventData.hovered.Count}");
    }
}
```

---

## 3. AxisEventData

Estende `BaseEventData`. Usato per la navigazione tramite assi (tastiera, gamepad, joystick) all'interno dell'UI.

### Enumerazioni interne

| Enum | Valori | Descrizione |
|------|--------|-------------|
| `MoveDirection` | `Left`, `Right`, `Up`, `Down`, `None` | La direzione del movimento sull'asse. |

### Proprietà

| Nome | Tipo | Descrizione | Esempio |
|------|------|-------------|---------|
| `moveVector` | `Vector2` | Il vettore grezzo del movimento ricevuto dall'input (es. joystick). | `Vector2 mv = eventData.moveVector;` |
| `moveDir` | `MoveDirection` | La direzione discretizzata calcolata da `moveVector`. | `if (eventData.moveDir == MoveDirection.Left) { }` |

### Metodi

| Nome | Firma | Descrizione | Esempio |
|------|-------|-------------|---------|
| `Use()` *(ereditato)* | `void Use()` | Segna l'evento come consumato. | `eventData.Use();` |
| `Reset()` *(ereditato)* | `virtual void Reset()` | Reimposta i dati ai valori di default. | `eventData.Reset();` |

### Esempio completo — AxisEventData

```csharp
using UnityEngine;
using UnityEngine.EventSystems;

public class AxisNavigationHandler : MonoBehaviour, IMoveHandler
{
    public void OnMove(AxisEventData eventData)
    {
        Debug.Log($"[Move] Vettore: {eventData.moveVector}");
        Debug.Log($"[Move] Direzione: {eventData.moveDir}");

        switch (eventData.moveDir)
        {
            case MoveDirection.Left:
                Debug.Log("Navigazione: SINISTRA");
                break;
            case MoveDirection.Right:
                Debug.Log("Navigazione: DESTRA");
                break;
            case MoveDirection.Up:
                Debug.Log("Navigazione: SU");
                break;
            case MoveDirection.Down:
                Debug.Log("Navigazione: GIÙ");
                break;
            case MoveDirection.None:
                Debug.Log("Nessun movimento");
                break;
        }

        // Impedisce la navigazione automatica dell'UI
        eventData.Use();
    }
}
```

---

## Riepilogo della gerarchia

```
BaseEventData
├── used             (bool)
├── selectedObject   (GameObject)
├── currentInputModule (BaseInputModule)
├── Use()
├── Reset()
│
├── PointerEventData
│   ├── pointerId, position, delta, pressPosition
│   ├── clickTime, clickCount, scrollDelta
│   ├── button, dragging, useDragThreshold, eligibleForClick
│   ├── pointerEnter, pointerPress, pointerDrag, rawPointerPress, lastPress
│   ├── pointerCurrentRaycast, pointerPressRaycast, hovered
│   ├── pressure, tangentialPressure, altitudeAngle, azimuthAngle, twist
│   ├── radius, radiusVariance
│   ├── IsPointerMoving()
│   ├── IsScrolling()
│   └── GetCurrentGameObject()
│
└── AxisEventData
    ├── moveVector   (Vector2)
    └── moveDir      (MoveDirection)
```

---

*Documentazione basata su Unity 6 — `UnityEngine.EventSystems`*
