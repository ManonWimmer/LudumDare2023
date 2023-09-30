using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrawerType
{
    Pull, 
    Rotate
}

public class Drawer : MonoBehaviour
{
    // ----- VARIABLES ----- //
    private float initialClosedZPosition;
    [SerializeField] private float finalClosedZPosition;

    [SerializeField] private float smoothTime = 10f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] DrawerType drawerType;

    private bool isOpen = false;
    // ----- VARIABLES ----- //

    private void Start()
    {
        initialClosedZPosition = transform.localPosition.z;
    }

    public void ToggleDrawer()
    {
        isOpen = !isOpen;

        if(isOpen)
            OpenDrawer();
        else
            CloseDrawer();
    }

    private void OpenDrawer()
    {
        Debug.Log("open");
        if (drawerType == DrawerType.Pull)
        {
            StartCoroutine(SmoothChangePosition(initialClosedZPosition, finalClosedZPosition));
        }
    }

    private void CloseDrawer()
    {
        Debug.Log("close");
        if (drawerType == DrawerType.Pull)
        {
            StartCoroutine(SmoothChangePosition(finalClosedZPosition, initialClosedZPosition));
        }   
    }

    private IEnumerator SmoothChangePosition(float initialPosZ, float finalPosZ)
    {
        Debug.Log("coroutine");
        Vector3 initialVector = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPosZ);
        Vector3 finalVector = new Vector3(transform.localPosition.x, transform.localPosition.y, finalPosZ);

        Debug.Log(transform.localPosition.z);

        while (Vector3.Distance(initialVector, finalVector) > 0.01f)
        {
            Debug.Log("while coroutine");
            initialVector = Vector3.SmoothDamp(initialVector, finalVector, ref velocity, smoothTime * Time.deltaTime);
            Debug.Log(transform.localPosition.z);
            transform.localPosition = initialVector;
            yield return null;
        }
        yield return null;
    }
}


