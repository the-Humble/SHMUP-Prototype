using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private Weapon[] weapons;
    private Weapon currentWeapon;
    private int currentWeaponIndex = 0;

    private Vector2 screenBounds;
    


    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = weapons[currentWeaponIndex];
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        foreach(Weapon weapon in weapons)
        {
            weapon.ActiveState(false);
        }
        currentWeapon.ActiveState(true);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime), 
                                        transform.position.y + (Input.GetAxisRaw("Vertical")*playerSpeed*Time.deltaTime),
                                        0);

        if(Input.GetKey(KeyCode.Space))
        {
            currentWeapon.TryFire();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 bounds = GetComponent<BoxCollider2D>().bounds.size/2;
        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + bounds.x, screenBounds.x - bounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + bounds.y, screenBounds.y - bounds.y);

        transform.position = viewPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.otherCollider.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
