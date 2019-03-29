using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    #region Class Level Variables
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody projectileRigidbody;
    #endregion

    // Use this for initialization
    void Start () {
		
	}

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void Update()
    {
        // if slingsot is not in aimingMode, don't run the code
        if (!aimingMode) return; //very bad code, bad bad code Trexy

        // get the current mouse position in 2d screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos; // Vector subtraction
        // limit mouseDelta to the radius of the slingshot sphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        // move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            // the mouse has been released
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void OnMouseDown()
    {
        // the player had pressed the mouse button while over the slingshot
        aimingMode = true;
        // instantiating a projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // start it at the launchPoint
        projectile.transform.position = launchPos;
        // set it to isKinematic for now
        //projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    /// <summary>
    /// 
    /// </summary>
    void OnMouseEnter()
    {
        //Debug.Log("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    void OnMouseExit()
    {
        //Debug.Log("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }
}
