using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameStates
    {
        Menu,
        Playing
    }

    public Color[] projectileColors = new Color[] { Color.black };
    [Tooltip("Projectile color will change each time player gets this amount of points.")]
    public int projectileColorChange = 400;
    private static GameManager m_instance;
    private PaintProjectileManager m_projectileManager;
    private GameStates m_state;
    private int m_projColorCount;


    public static GameManager GetInstance()
    {
        return m_instance;
    }

    private void Awake()
    {
        if (null != m_instance)
            Destroy(gameObject);
        else
        {
            m_instance = this;
        }
    }

    void Start()
    {
        if(TryGetComponent<PaintProjectileManager>(out var _projectileManager)) 
        {
            m_projectileManager = _projectileManager;
        }
        StartGame();
        m_projColorCount = projectileColors.Length;
    }

    public PaintProjectileManager GetProjectileManager()
    {
        return m_projectileManager;
    }

    // public void AddPoints(int amount)
    // {
    //     if (amount < 0)
    //         playerHUD.IndicatePointsLoss();
    //     else
    //         playerHUD.IndicatePointsGain();

    //     m_points += amount;

    //     GetProjectileManager().paintBombColor = projectileColors[(m_points / projectileColorChange) % m_projColorCount];
    // }

    public void StartGame()
    {
        // gun.SetGunMode(ClickScript.GunMode.PaintGun);
        m_state = GameStates.Playing;
    }
}
