using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrows : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TutorArrow"))
        {
            Destroy(other.gameObject);
        }
    }
}
