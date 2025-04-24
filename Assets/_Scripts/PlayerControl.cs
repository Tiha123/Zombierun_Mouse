using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] List<AbilityData> datas;
    [SerializeField] List<Ability> abilities;
    public Animator animator;
    public Rigidbody rb;
    public InputControl input;
    public Camera cam;

    void Awake()
    {
        cam=Camera.main;
        if(TryGetComponent<Animator>(out animator)==false)
        {
            return;
        }
        if(TryGetComponent<Rigidbody>(out rb)==false)
        {
            return;
        }
        if(TryGetComponent<InputControl>(out input)==false)
        {
            return;
        }
        foreach(AbilityData d in datas)
        {   
            Ability temp = d.CreateAbility(this);
            abilities.Add(temp);
        }
        foreach(Ability ab in abilities)
        {
            ab.Activate();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        foreach(Ability ab in abilities)
        {
            ab.Update();
        }
    }

    void FixedUpdate()
    {
        foreach(Ability ab in abilities)
        {
            ab.FixedUpdate();
        }
    }

}
