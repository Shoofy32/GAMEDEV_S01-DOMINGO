using TMPro;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] Ammo ammo;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] TextMeshProUGUI  ammoText;
    private int ammoCount = 11;

    private void Start()
    {
        ammoText.text = $"Ammo: {ammoCount}";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (ammoCount <= 0)
        {
            ammoText.text = "Out of ammo";
            return;
        }
        var projectile = Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        projectile.GetComponent<Projectile>().Ammo = ammo;
        ammoCount--;
        ammoText.text = $"Ammo: {ammoCount}";
        
    }

}
