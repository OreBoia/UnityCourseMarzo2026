using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonExamples : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject objectToSet;
    
    public UnityEvent<GameObject, int, string> unityEvent;
    public UnityAction<string> unityAction;

    void Start()
    {
        button = GetComponent<Button>();
        // button.onClick.AddListener(SetActiveImage);

        button.onClick.AddListener(() => { SetActiveImage(objectToSet, 0, "è stato distrutto"); });
        
        button.onClick.AddListener(SetActiveImage);

        unityEvent.AddListener(SetActiveImage);
        unityEvent.Invoke(objectToSet, 19, "Piccione");

        // unityAction += SetActiveImage;
        unityAction += ButtonSaySomething;
        unityAction.Invoke("Ciao");
        unityAction = null;
    }

    public void ButtonSaySomething(string message)
    {
        Debug.Log($"this button [{gameObject.name}] says {message}");
    }

    private void SetActiveImage()
    {
        objectToSet.SetActive(!objectToSet.activeSelf);
    }

    public void SetActiveImage(GameObject objectToSet, int n, string message)
    {
        Debug.Log($"Ogetto {objectToSet.name} {message}");
        objectToSet.SetActive(!objectToSet.activeSelf);
    }
}