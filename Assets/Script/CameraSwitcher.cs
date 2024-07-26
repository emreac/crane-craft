using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public PlayerController PlayerController;
    
    //public LockedUnitController lockedUnitController;
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera buildingCamera;
 

    private void Start()
    {
        // Ensure mainCamera is active initially
        mainCamera.gameObject.SetActive(true);
     
        buildingCamera.gameObject.SetActive(false);

    }

    public void PerformCameraAction()
    {

        // Switch to actionCamera
        StartCoroutine(SwitchCamerasAndWait());
    }

    public void StartTutorialCamera()
    {
        if (PlayerPrefs.GetInt("FunctionExecuted", 0) == 0)
        {
            // The function has not been executed before, so run it
          

            // Set the flag to indicate that the function has been executed
            PlayerPrefs.SetInt("FunctionExecuted", 1);
            PlayerPrefs.Save(); // Save the flag
        }


    }

   

 
    private IEnumerator SwitchCamerasAndWait()
    {
        yield return new WaitForSeconds(0.3f);
        // Activate actionCamera and deactivate mainCamera
        //Disable Movement
      

        mainCamera.gameObject.SetActive(false);
        buildingCamera.gameObject.SetActive(true);
        PlayerController.isJoystick = false;
        /*
        // Wait for 1 second
        yield return new WaitForSeconds(3.0f);

        // Switch back to mainCamera
        buildingCamera.gameObject.SetActive(false);

        mainCamera.gameObject.SetActive(true);
        */
      
    }

}
