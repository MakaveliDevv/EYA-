using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public enum GunMode
    {
        UIPointer,
        PaintGun
    }

    public Transform launcherTransform;
    public Transform laserEmitterTransform;
    //public GameObject laserDotPrefab;
    public Texture2D splashTexture;
    public float fireRate = 2;

    private const int c_colorArrayLength = 6;
    public Color[] c_colorArray = new Color[c_colorArrayLength] { Color.blue, Color.yellow, Color.red, Color.green, Color.white, Color.black };

    public GunMode m_mode = GunMode.PaintGun;
    private int m_currColor = 0;

    private float m_projectileDelay;        // delay between projectiles
    private float m_nextProjectileDelay;    // remaining time until next projectile

    private void Start()
    {
        m_projectileDelay = 1 / fireRate;
    }

    void Update ()
    {
        if (m_nextProjectileDelay > 0)
            m_nextProjectileDelay -= Time.deltaTime;

        // If clic
        if (Input.GetMouseButton(0))
        {
            if (m_nextProjectileDelay <= 0)
            {
                GameObject projectile = Instantiate(GameManager.GetInstance().GetProjectileManager().paintBombPrefab, launcherTransform.position + launcherTransform.forward * 3, launcherTransform.rotation);
                projectile.GetComponent<PaintProjectileBehavior>().paintColor = GameManager.GetInstance().GetProjectileManager().paintBombColor;
                projectile.GetComponent<Rigidbody>().velocity = launcherTransform.forward * 20;
                m_nextProjectileDelay = m_projectileDelay;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.GetInstance().GetProjectileManager().paintBombColor = c_colorArray[m_currColor];
            m_currColor++;
            if (m_currColor == c_colorArrayLength)
                m_currColor = 0;
        }
    }
}
