using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   
    [SerializeField] private GameObject winUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformUIActive()
    {
        StartCoroutine(WinUIDelay());
    }
    private IEnumerator WinUIDelay()
    {
        yield return new WaitForSeconds(3f);
        winUI.gameObject.SetActive(true);
    }
}
