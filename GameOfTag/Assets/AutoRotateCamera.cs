using UnityEngine;
using System.Collections;

public class AutoRotateCamera : MonoBehaviour
{

    //　キャラクターのTransform
    public Transform charaTra;
    //　カメラの移動スピード
    public float cameraMoveSpeed = 100f;
    //　カメラの回転スピード
    public float cameraRotateSpeed = 90f;
    //　カメラのキャラクターからの相対値を指定
    public Vector3 basePos = new Vector3(0f, 0f, 2f);

    void LateUpdate()
    {

        RaycastHit hit;

        if( Input.GetKey(KeyCode.C))
        {
            //　カメラの位置をキャラクターの後ろ側に移動させる
            transform.position = Vector3.Lerp(transform.position, charaTra.position + (charaTra.forward * basePos.z) + (Vector3.up * basePos.y), cameraMoveSpeed * Time.deltaTime);
        }
        else
        {
            //　カメラの位置をキャラクターの後ろ側に移動させる
            transform.position = Vector3.Lerp(transform.position, charaTra.position + (-charaTra.forward * basePos.z) + (Vector3.up * basePos.y), cameraMoveSpeed * Time.deltaTime);
        }
        
        
        //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
        if (Physics.Linecast(charaTra.position + Vector3.up, transform.position, out hit, LayerMask.GetMask("Field", "Block")))
        {
            transform.position = hit.point;
        }

        //if (!Input.GetKey(KeyCode.A))
        //{
            //　スピードを考慮しない場合はLookAtで出来る
            		transform.LookAt (charaTra.position);
            //　スピードを考慮する場合
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(charaTra.position - transform.position), cameraRotateSpeed * Time.deltaTime);
        //}
    }
}