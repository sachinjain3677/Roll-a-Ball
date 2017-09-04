using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	void Update () {
        transform.Rotate(new Vector3(15, 30, 15) * Time.deltaTime);//since delta time is an infinitisimal quantity therefore it reduces the extent of rotation many folds
	}
}
