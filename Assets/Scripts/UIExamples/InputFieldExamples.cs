using TMPro;
using UnityEngine;

public class InputFieldExamples : MonoBehaviour {
    public TMP_InputField campoNome;

    void Start()
    {
        campoNome = GetComponent<TMP_InputField>();
        campoNome.onValueChanged.AddListener(StampaNome);
        campoNome.onEndEdit.AddListener(StampaOnEnd);
        campoNome.onSelect.AddListener(StampaSelezione);
        campoNome.onDeselect.AddListener(StampaDeselezione);
    }

    public void StampaNome(string value) 
    {
        Debug.Log("Nome inserito: " + value);
    }

    public void StampaOnEnd(string value)
    {
        Debug.Log("Nome inserito (onEnd): " + value);
    }

    public void StampaSelezione(string value)
    {
        Debug.Log($"Selezione: {value}");
    }

    public void StampaDeselezione(string value)
    {
        Debug.Log($"Deselezione: {value}");
    }
}