using UnityEngine;

public class VisabilityTest : MonoBehaviour
{
    [SerializeField] VariablesTest vt;

    private void Start()
    {
        if(vt != null)
        {
            Debug.Log($"{vt.ShopIndex}");
        }
    }
}
