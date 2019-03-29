using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private PlatformManager _PlatformManager;
    private float _canRecycle = -1f;
    private float _delay = 2.5f;

    private void OnEnable()
    {
        _PlatformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
      if(other.tag == "Player")
        {
            yield return new WaitForSeconds(1.5f);
            Debug.Log("Collided with Platform End");
            _PlatformManager.RecyclePlatform(this.transform.parent.gameObject);
        }
    }
}
