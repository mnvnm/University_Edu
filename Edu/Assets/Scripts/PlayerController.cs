using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_Rigidbody = null;
    [SerializeField] private Camera m_Cam = null;
    [SerializeField] private Light m_FlashLight = null;

    private float m_RotSpeed = 15.0f;
    private float m_xRotate = 0.0f;

    private float m_moveSpeed = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_FlashLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rot();
        Move();
        FlashLight();
    }

    void Rot()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * m_RotSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        float xRotateSize = -Input.GetAxis("Mouse Y") * m_RotSpeed;
        m_xRotate = Mathf.Clamp(m_xRotate + xRotateSize, -45, 80);
        transform.eulerAngles = new Vector3(0, yRotate, 0);
        m_Cam.transform.eulerAngles = new Vector3(m_xRotate, transform.eulerAngles.y, 0);
    }
    void Move()
    {
        m_Rigidbody.linearVelocity = new Vector3(0, m_Rigidbody.linearVelocity.y, 0);

        if (Input.GetKey(KeyCode.W))
            m_Rigidbody.linearVelocity += transform.forward.normalized * m_moveSpeed;
        if (Input.GetKey(KeyCode.S))
            m_Rigidbody.linearVelocity -= transform.forward.normalized * m_moveSpeed;
        if (Input.GetKey(KeyCode.A))
            m_Rigidbody.linearVelocity -= transform.right.normalized * m_moveSpeed;
        if (Input.GetKey(KeyCode.D))
            m_Rigidbody.linearVelocity += transform.right.normalized * m_moveSpeed;

        Jump();

        //����
        //if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && IsRun)
        //{
        //    m_Stamina -= Time.deltaTime * 2;
        //    m_moveSpeed = 6;
        //}
        //else
        //{
        //    m_moveSpeed = 4.0f;
        //
        //    if (m_Stamina < 10.0f || !IsRun)
        //    {
        //        m_Stamina += Time.deltaTime;
        //    }
        //}
        //if (m_Stamina <= 0.0f)
        //{
        //    IsRun = false;
        //}
        //
        //if(m_Stamina >= 9.999f && !IsRun)
        //{
        //    IsRun = true;
        //}
    }

    void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_FlashLight.enabled = !m_FlashLight.enabled;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(m_Rigidbody.linearVelocity.y) < 0.01f)
        {
            m_Rigidbody.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
        }
    }
}
