using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProductBrickController : MonoBehaviour
{
    private bool isReadyToPick;
    private Vector3 originalScale;

    [SerializeField] private ProductData bagGO;
    private BagController bagController;


    // Start is called before the first frame update
    void Start()
    {
        isReadyToPick = true;
        originalScale = transform.localScale;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToPick)
        {
            bagController = other.GetComponent<BagController>();
            bagController.AddProductToBag(bagGO);
            
            isReadyToPick = false;
            StartCoroutine(ProductPicked());
        }
    }

    IEnumerator ProductPicked()
    {
        float duration = 0.1f;
        float timer = 0f;

        Vector3 targerScale = Vector3.zero;

        while (timer < duration)
        {
            float t = timer / duration;
            Vector3 newScale = Vector3.Lerp(originalScale, targerScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;
        }
        //Zero Scale this point
        yield return new WaitForSeconds(3f);

        timer = 0f;
        float growBackDuration = 0.5f;

        while (timer < growBackDuration)
        {
            float t = timer / growBackDuration;
            Vector3 newScale = Vector3.Lerp(targerScale, originalScale, t);
            transform.localScale = newScale;
            timer+= Time.deltaTime;
            yield return null;
        }
        isReadyToPick = true;
        yield return null;

    }
}
