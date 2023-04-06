using System;
using UnityEngine;

/*
 * Player actions
 */

public class Player : MonoBehaviour
{
    public Action fightingAction;
    public event EventHandler<KickEventArgs> OnKick; 
    public class KickEventArgs : EventArgs 
    { 
        public float kickStrength;
        public float kickRange;
    }
    
    [Header("Combat Variables")] 
    [SerializeField] private float kickStrength = 1f;
    [SerializeField] private float kickRange = 5f;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Set to either Kick or Shoot while debugging (then change in Gun script)
        // fightingAction = Kick;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && fightingAction == Kick)
        {
            fightingAction?.Invoke();
        }
    }

    private void Kick()
    {
        OnKick?.Invoke(this, new KickEventArgs{kickStrength = kickStrength, kickRange = kickRange});
    }
}

