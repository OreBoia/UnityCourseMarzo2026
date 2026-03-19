using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownExamples: MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<string> options = new List<string>(){"Facile", "Medio", "Difficile"};
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        // dropdown.onValueChanged.AddListener();
        dropdown.ClearOptions();
        dropdown.AddOptions(options);

        dropdown.options.ForEach((option) => {Debug.Log($"{option.text}");});
    }
}