using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.ShaderGraph.Internal;
#endif
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
    private float initialClosedYRotation;
    [SerializeField] private float finalClosedZPosition = 0f;

    [SerializeField] private float finalRotateYPosition = 0f;

    [SerializeField] private float smoothTimeRotate = 0.5f;
    [SerializeField] private float smoothTimePull = 5f;
    private Vector3 velocity = Vector3.zero;
    private float yVelocity = 0f;

    [SerializeField] DrawerType drawerType;
    public bool canBeOpened = true;

    private bool isOpen = false;
    // ----- VARIABLES ----- //

    private void Start()
    {
        initialClosedZPosition = transform.localPosition.z;
        initialClosedYRotation = transform.localRotation.y;
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
        //Debug.Log("open");
        if (drawerType == DrawerType.Pull)
        {
            StartCoroutine(SmoothChangePosition(initialClosedZPosition, finalClosedZPosition));
        }
        else if (drawerType == DrawerType.Rotate)
        {
            StartCoroutine(SmoothRotatePosition(initialClosedYRotation, finalRotateYPosition));
        }
    }

    private void CloseDrawer()
    {
        //Debug.Log("close");
        if (drawerType == DrawerType.Pull)
        {
            StartCoroutine(SmoothChangePosition(finalClosedZPosition, initialClosedZPosition));
        }
        else if (drawerType == DrawerType.Rotate)
        {
            StartCoroutine(SmoothRotatePosition(finalRotateYPosition, initialClosedYRotation));
        }
    }

    private IEnumerator SmoothChangePosition(float initialPosZ, float finalPosZ)
    {
        //Debug.Log("coroutine pull");
        Vector3 initialVector = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPosZ);
        Vector3 finalVector = new Vector3(transform.localPosition.x, transform.localPosition.y, finalPosZ);

        Debug.Log(transform.localPosition.z);

        while (Vector3.Distance(initialVector, finalVector) > 0.01f)
        {
            //Debug.Log("while coroutine pull");
            initialVector = Vector3.SmoothDamp(initialVector, finalVector, ref velocity, smoothTimePull * Time.deltaTime);
            Debug.Log(transform.localPosition.z);
            transform.localPosition = initialVector;
            yield return null;
        }
        yield return null;
    }

    private IEnumerator SmoothRotatePosition(float initialRotY, float finalRotY)
    {
        //Debug.Log("coroutine rotate");

        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < smoothTimeRotate)
        {
            //Debug.Log("while coroutine rotate");
            float t = elapsedTime / smoothTimeRotate;
            float angleY = Mathf.LerpAngle(initialRotY, finalRotY, t);
            transform.localRotation = Quaternion.Euler(0, angleY, 0);

            elapsedTime = Time.time - startTime;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0, finalRotY, 0);
    }
}


