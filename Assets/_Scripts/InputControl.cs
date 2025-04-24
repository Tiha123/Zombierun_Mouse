using UnityEngine;
using GameInputs;

public class InputControl : MonoBehaviour
{
    [SerializeField] PlayerInputs actionInputs;
    public PlayerInputs.PlayerActions playerActions;

    void Awake()
    {
        actionInputs=new PlayerInputs();
        playerActions=actionInputs.Player;
    }

    void OnEnable()
    {
        playerActions.Enable();
    }

    void OnDisable()
    {
        playerActions.Disable();
    }

    void OnDestroy()
    {
        actionInputs.Dispose();
    }

}
