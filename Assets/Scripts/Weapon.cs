using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireCooldown = 0.5f;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
    }

    public void TryFire()
    {
        if(fireTimer<=0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            fireTimer = fireCooldown;
        }
    }
    public void ActiveState(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
