using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScript : MonoBehaviour
{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float gravity = 10f;
    public float jumpPower = 5;

    private Vector3 moveDirection;
    private CharacterController controller;

    void Start()
    {

        // コンポーネントの取得
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {

        if (controller.isGrounded)
        {

            // 回転
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            // キャラクターのローカル空間での方向
            moveDirection = transform.transform.forward * speed * Input.GetAxis("Vertical");

            // ジャンプ
            if (Input.GetButtonDown("Jump")) moveDirection.y = jumpPower;

        }
        else
        {

            // 重力
            moveDirection.y -= gravity * Time.deltaTime;

        }

        // SimpleMove関数で移動させる
        controller.Move(moveDirection * Time.deltaTime);

    }

}