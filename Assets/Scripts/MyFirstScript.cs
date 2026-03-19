using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    [SerializeField] private int number = 0;

    void Awake() => Debug.Log("Primo Risveglio (Awake())");

    void OnEnable() => Debug.Log("OnEnable() Mi sono abilitato");

    void Start() => Debug.Log("Primo Start()");

    void Update() { Debug.Log("Update() ad ogni frame"); }

    void FixedUpdate() { Debug.Log("FixedUpdate() intervallo fisso"); }

    void LateUpdate() { Debug.Log("LateUpdate() alla fine del frame");}

    void OnDisable() { Debug.Log("OnDisable() mi sono disabilitato");}

    void OnDestroy() { Debug.Log("OnDestroy() sto per essere distrutto");}
}
