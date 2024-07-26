using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public GameObject purpleLayer;

    [SerializeField] private Transform bag;
    public List<ProductData> productDataList;
    private Vector3 productSize;

    private List<BrickPoint> greenBricks = new List<BrickPoint>();
    private List<BrickPoint> purpleBricks = new List<BrickPoint>();
    private List<BrickPoint> yellowBricks = new List<BrickPoint>();
    private int currentLayer = 0; // 0 for green layer, 1 for purple layer, 2 for yellow layer

    private void Start()
    {
        // Find all BrickPoints and organize them by color or layer
        BrickPoint[] brickPoints = FindObjectsOfType<BrickPoint>();
        foreach (BrickPoint brickPoint in brickPoints)
        {
            if (brickPoint.brickColor == BrickColor.Green)
            {
                greenBricks.Add(brickPoint);
            }
            else if (brickPoint.brickColor == BrickColor.Purple)
            {
                purpleBricks.Add(brickPoint);
            }
            else if (brickPoint.brickColor == BrickColor.Yellow)
            {
                yellowBricks.Add(brickPoint);
            }
        }

        // Activate the first layer (green bricks)
        ActivateLayer(greenBricks);
    }

    private void ActivateLayer(List<BrickPoint> bricks)
    {
        foreach (BrickPoint brick in bricks)
        {
            brick.gameObject.SetActive(true); // Enable the collider
        }
    }

    private void DeactivateLayer(List<BrickPoint> bricks)
    {
        foreach (BrickPoint brick in bricks)
        {
            brick.gameObject.SetActive(false); // Disable the collider
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BrickPoint"))
        {
            BrickPoint brickPoint = other.GetComponent<BrickPoint>();
            if (brickPoint != null && !brickPoint.IsEnabled)
            {
                // Ensure the brick point belongs to the current layer
                if (IsBrickInCurrentLayer(brickPoint) && productDataList.Count > 0)
                {
                    // Remove one item from the bag
                    int lastIndex = productDataList.Count - 1;
                    Destroy(bag.transform.GetChild(lastIndex).gameObject);
                    productDataList.RemoveAt(lastIndex);

                    // Enable the BrickPoint mesh renderer
                    brickPoint.EnableMeshRenderer();

                    // Check if the current layer is fully activated
                    CheckLayerCompletion();
                }
            }
        }
    }

    private bool IsBrickInCurrentLayer(BrickPoint brickPoint)
    {
        return (currentLayer == 0 && greenBricks.Contains(brickPoint)) ||
               (currentLayer == 1 && purpleBricks.Contains(brickPoint)) ||
               (currentLayer == 2 && yellowBricks.Contains(brickPoint));
    }

    private void CheckLayerCompletion()
    {
        List<BrickPoint> currentLayerBricks = currentLayer == 0 ? greenBricks :
                                              currentLayer == 1 ? purpleBricks :
                                              yellowBricks;

        bool layerComplete = true;
        foreach (BrickPoint brickPoint in currentLayerBricks)
        {
            if (!brickPoint.IsEnabled)
            {
                layerComplete = false;
                break;
            }
        }

        if (layerComplete)
        {
            // Move to the next layer
            currentLayer++;

            // Activate the next layer if available
            if (currentLayer == 1 && purpleBricks.Count > 0)
            {
                ActivateLayer(purpleBricks);
            }
            else if (currentLayer == 2 && yellowBricks.Count > 0)
            {
                ActivateLayer(yellowBricks);
            }

            // Optionally: Notify that all layers are complete if needed
            if (currentLayer > 2)
            {
                AllLayersCompleted();
            }
        }
    }

    private void AllLayersCompleted()
    {
        // Optional: Add logic for when all layers are completed
        Debug.Log("All layers have been completed!");
        // You can trigger any additional logic or events here
    }

    public void AddProductToBag(ProductData productData)
    {
        GameObject boxProduct = Instantiate(productData.productPrefab, Vector3.zero, Quaternion.identity);
        boxProduct.transform.SetParent(bag, true);

        // Calculate Size
        CalculateObjectSize(boxProduct);

        // Calculate Y position
        float yPosition = CalculateNewYPositionOfBox();

        // Reset rotation
        boxProduct.transform.localRotation = Quaternion.identity;

        // Reset Position
        boxProduct.transform.localPosition = new Vector3(0, yPosition, 0);

        // Stack List
        productDataList.Add(productData);
    }

    private float CalculateNewYPositionOfBox()
    {
        // Height of product * count of product
        float newYPos = productSize.y * productDataList.Count;
        return newYPos;
    }

    private void CalculateObjectSize(GameObject gameObject)
    {
        if (productSize == Vector3.zero)
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            productSize = renderer.bounds.size / 2;
        }
    }
}