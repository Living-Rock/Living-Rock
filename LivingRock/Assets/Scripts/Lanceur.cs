using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;

public class Lanceur : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileVelocity;

    private float tmp_timer = 2f;
    private float tmp_time;
    // Start is called before the first frame update
    void Start()
    {
        tmp_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tmp_time + tmp_timer)
        {
            tmp_time = Time.time;
            launchProjectiles(Vector3.up);
            
        }
    }

    public void launchProjectiles(Vector3 dir)
    {
        GameObject proj = Instantiate(projectilePrefab, transform.position + dir, Quaternion.identity);
        proj.GetComponent<Projectile>().Velocity = projectileVelocity;
        proj.GetComponent<Projectile>().Direction = dir;
    }
}
