using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ProductType { brick, paint}
[CreateAssetMenu(fileName ="ProductData", menuName ="Scriptable Objects/Product Data",order =0)]
public class ProductData : ScriptableObject
{
    public GameObject productPrefab;
    public ProductType productType;
    public int productPrice;
}
