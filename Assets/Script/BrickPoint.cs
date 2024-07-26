using UnityEngine;

public enum BrickColor
{
    Green,
    Purple,
    Yellow
}

public class BrickPoint : MonoBehaviour
{
    public GameObject refCube;

    private MeshRenderer meshRenderer;
    
    private bool isEnabled = false;

    public ParticleSystem enableEffect; // Particle system prefab

    public BrickColor brickColor; // Enum to differentiate colors



    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.enabled = false; // Initially disable the mesh renderer

    }

    public void EnableMeshRenderer()
    {
        isEnabled = true;
        meshRenderer.enabled = true; // Enable the mesh renderer
   

        // Play the particle effect
        if (enableEffect != null)
        {
            refCube.gameObject.SetActive(false);
            ParticleSystem effect = Instantiate(enableEffect, transform.position, Quaternion.identity);
            effect.transform.SetParent(transform); // Optionally set parent to keep in sync with the brick
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration); // Destroy effect object after it finishes playing
        }
    }
    public bool IsEnabled
    {
        get { return isEnabled; }
    }
}
