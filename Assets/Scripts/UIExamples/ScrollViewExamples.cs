using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewExamples : MonoBehaviour
{
    public ScrollRect scrollRect;
    
    public GameObject itemPrefab;
    
    public float scrollVelocity = 0.1f;

    private void Start()
    {
        if (scrollRect == null)
        {
            scrollRect = GetComponent<ScrollRect>();
        }

        scrollRect.onValueChanged.AddListener((value) => Debug.Log($"Actual scroll postion: {value}"));

        ConfiguraScrollRect();
        
        AggiungiElementiEsempio();
    }

    void Update()
    {
        MoveScrollPosition();
    }

    private void ConfiguraScrollRect()
    {
        if (scrollRect == null) return;

        scrollRect.horizontal = false;  
        scrollRect.vertical = true;

        scrollRect.scrollSensitivity = 5f;

        scrollRect.inertia = true;
        scrollRect.decelerationRate = 0.95f;

        scrollRect.elasticity = 0.1f;
    }

    public void AggiungiElemento(string testo)
    {
        if (scrollRect == null || itemPrefab == null) return;

        GameObject nuovoElemento = Instantiate(itemPrefab, scrollRect.content);
        
        TextMeshProUGUI textComponent = nuovoElemento.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = testo;
        }
    }

    private void AggiungiElementiEsempio()
    {
        for (int i = 1; i <= 10; i++)
        {
            AggiungiElemento($"Elemento {i}");
        }
    }

    public void SvuotaElementi()
    {
        if (scrollRect?.content == null) return;

        foreach (Transform child in scrollRect.content)
        {
            Destroy(child.gameObject);
        }
    }


    private void MoveScrollPosition()
    {
        if (scrollRect == null) return;

        if (Input.GetKey(KeyCode.W))
        {
            scrollRect.verticalNormalizedPosition += Time.deltaTime * scrollVelocity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            scrollRect.verticalNormalizedPosition -= Time.deltaTime * scrollVelocity;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }
        if (Input.GetKeyDown(KeyCode.End))
        {
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}