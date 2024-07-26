using UnityEngine;

public class TargetObject : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private bool isEnabled = false;

    public bool IsEnabled
    {
        get { return isEnabled; }
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false; // Initially disable the mesh renderer
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (!isEnabled && other.CompareTag("Player"))
        {
            BagController bagController = other.GetComponent<BagController>();
            if (bagController != null && bagController.HasItems())
            {
                EnableTarget();
                bagController.CheckIfAllTargetsEnabled();
            }
        }
    }
    */
    private void EnableTarget()
    {
        isEnabled = true;
        meshRenderer.enabled = true; // Enable the mesh renderer
    }
}
