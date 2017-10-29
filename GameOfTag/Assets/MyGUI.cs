using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour
{

    public GameObject cube;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "GENERATE"))
        {
            float x = Random.Range(-2.0f, 2.0f);
            float y = Random.Range(-2.0f, 2.0f);
            float z = Random.Range(-2.0f, 2.0f);

            Instantiate(this.cube, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}