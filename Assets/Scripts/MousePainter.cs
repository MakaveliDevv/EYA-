using UnityEngine;

public class MousePainter : MonoBehaviour{
    public Camera cam;
    [Space]
    public bool mouseSingleClick;
    [Space]
    public Color paintColor;
    
    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    void Update(){

        bool click;
        click = mouseSingleClick ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0);

        if (click){
            Vector3 position = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f)){
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                transform.position = hit.point;
                Paintable p = hit.collider.GetComponent<Paintable>();
                if(p != null){
                    PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
                }
            }
        }

    }


    // public enum GunMode
    // {
    //     UIPointer,
    //     PaintGun
    // }

    // public Transform launcherTransform;
    // public Transform laserEmitterTransform;
    // //public GameObject laserDotPrefab;
    // public Texture2D splashTexture;
    // public float fireRate = 2;

    // private const int c_colorArrayLength = 6;
    // public Color[] c_colorArray = new Color[c_colorArrayLength] { Color.blue, Color.yellow, Color.red, Color.green, Color.white, Color.black };

    // public GunMode m_mode = GunMode.PaintGun;

    // private GameObject m_laserDot;
    // private int m_currColor = 0;

    // private float m_projectileDelay;        // delay between projectiles
    // private float m_nextProjectileDelay;    // remaining time until next projectile

    // private void Start()
    // {
    //     m_projectileDelay = 1 / fireRate;
    // }

    // void Update ()
    // {
    //     if (m_mode == GunMode.UIPointer)
    //     {
    //         RaycastHit hit;
    //         if (Physics.Raycast(laserEmitterTransform.position, transform.forward, out hit))
    //         {
    //             m_laserDot.SetActive(true);
    //             m_laserDot.transform.position = hit.point;
    //             m_laserDot.transform.LookAt(laserEmitterTransform.position);
    //         }
    //         else
    //         {
    //             m_laserDot.SetActive(false);
    //         }

    //     }
    //     else
    //     {
    //         if (m_nextProjectileDelay > 0)
    //             m_nextProjectileDelay -= Time.deltaTime;

    //         if (m_nextProjectileDelay <= 0)
    //         {
    //             GameObject projectile = Instantiate(GameManager.GetInstance().GetProjectileManager().paintBombPrefab, launcherTransform.position + launcherTransform.forward * 3, launcherTransform.rotation);
    //             projectile.GetComponent<PaintProjectileBehavior>().paintColor = GameManager.GetInstance().GetProjectileManager().paintBombColor;
    //             projectile.GetComponent<Rigidbody>().velocity = launcherTransform.forward * 20;
    //             m_nextProjectileDelay = m_projectileDelay;
    //         }
            

    //         if (Input.GetMouseButtonDown(1))
    //         {
    //             GameManager.GetInstance().GetProjectileManager().paintBombColor = c_colorArray[m_currColor];
    //             m_currColor++;
    //             if (m_currColor == c_colorArrayLength)
    //                 m_currColor = 0;
    //         }
    //     }
    // }

}
