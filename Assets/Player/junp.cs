using UnityEngine;
using UnityEngine.InputSystem; // 新Input System用

public class junp : MonoBehaviour
{
    public float jumpForce = 5f;     // ジャンプの強さ
    private Rigidbody2D rb;
    public InputAction jumpAction;   // インスペクターから設定、またはコードで作成

    void Awake()
    {
        // Spaceキーをジャンプアクションにバインド
        jumpAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/space");
    }

    void OnEnable()
    {
        jumpAction.Enable();
    }

    void OnDisable()
    {
        jumpAction.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ジャンプ入力（トリガーされたら）
        if (jumpAction.triggered)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
