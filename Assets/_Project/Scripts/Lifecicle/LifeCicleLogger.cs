using UnityEngine;

public class LifeCicleLogger : MonoBehaviour
{

    void Awake()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }



    void OnEnable()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }


    void Start()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }


    void Update()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }

    private void FixedUpdate()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }

    private void LateUpdate()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }

    private void OnDisable()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }

    private void OnDestroy()
    {
        Debug.Log($"Eseguo Awake di {gameObject.name}");
    }
}
