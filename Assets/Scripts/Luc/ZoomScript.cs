using UnityEngine;

public class ZoomScript : MonoBehaviour
{
    private float originalFieldOfView;
    private bool isZoomed = false;

    // R�f�rence � la cam�ra
    private Camera mainCamera;

    [SerializeField]
    private float zoomFactor = 2.0f; // Facteur de zoom, 2.0 signifie un zoom x2

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        originalFieldOfView = mainCamera.fieldOfView;
    }

    private void Update()
    {
        // V�rifier si la touche "Z" est enfonc�e pour effectuer le zoom
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ToggleZoom();
        }
    }

    private void ToggleZoom()
    {
        if (isZoomed)
        {
            // Revenir au champ de vision original
            mainCamera.fieldOfView = originalFieldOfView;
        }
        else
        {
            // Appliquer le zoom
            mainCamera.fieldOfView /= zoomFactor;
        }

        // Inverser l'�tat du zoom
        isZoomed = !isZoomed;
    }
}
