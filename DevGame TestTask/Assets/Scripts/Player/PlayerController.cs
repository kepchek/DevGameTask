using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform weaponSpawnPoint;
    public Weapon[] availableWeapons; // Для хранения всех типов оружия
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; // скорость вращения в градусах в секунду
    private Vector3 moveDirection;
    public Rigidbody rb;
    public GameObject GameOverMenu;
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        GameOverMenu.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        HandleShooting();
        ProcessInputs();
        Move();
        Rotate();
        BackToMenu();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void Move()
    {
        Vector3 moveVelocity = moveDirection * moveSpeed;
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }

    void Rotate()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Vector3 targetDirection = targetPoint - transform.position;
            targetDirection.y = 0; // Игнорировать высоту

            if (targetDirection != Vector3.zero) // Проверка на нулевое направление
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                Quaternion newRotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                rb.MoveRotation(newRotation);
            }
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon != null)
        {
            currentWeapon.Shoot();
            Debug.Log("Игрок произвёл выстрел");
        }
    }

    void BackToMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        currentWeapon = Instantiate(newWeapon, weaponSpawnPoint.position, weaponSpawnPoint.rotation, weaponSpawnPoint);
    }
    public void Die()
    {
        Time.timeScale = 0f;
        GameOverMenu.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }
}