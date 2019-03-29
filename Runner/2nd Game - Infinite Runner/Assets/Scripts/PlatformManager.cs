using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] _platformPrefabs;
    [SerializeField]
    private int _zOffset;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < _platformPrefabs.Length; i++)
        {
            Instantiate(_platformPrefabs[i], new Vector3(0, 0, i * 24), Quaternion.Euler(0,0,0));
            _zOffset += 24;
        }
	}

    public void RecyclePlatform(GameObject platform)
    {
        //repositioning us to the next Z offset
        platform.transform.position = new Vector3(0, 0, _zOffset);
        _zOffset += 24;
    }
}
