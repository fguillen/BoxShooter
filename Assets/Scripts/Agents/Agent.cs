using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaponSystem;
using Sensors;

public class Agent : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public AgentInput agentInput;
    [HideInInspector] public AnimationManager animationManager;
    [HideInInspector] public GroundSensor groundSensor;
    [HideInInspector] public ClimbSensor climbSensor;
    [HideInInspector] public WallInFrontSensor wallInFrontSensor;
    [HideInInspector] public SensorInAllDirectionsSensor wallInAllDirectionsSensor;
    [HideInInspector] public SensorInAllDirectionsSensor playerInAllDirectionsSensor;
    [HideInInspector] public PlayerInFrontSensor playerInFrontSensor;
    [HideInInspector] public PlayerInAreaSensor playerInAreaSensor;
    [HideInInspector] public EndOfGroundSensor endOfGroundSensor;
    [HideInInspector] public WeaponManager weaponManager;
    [HideInInspector] public StateManager stateManager;
    [HideInInspector] public DamageManager damageManager;
    [HideInInspector] public RespawnManager respawnManager;
    [HideInInspector] public PointsManager pointsManager;

    SpriteFlipper spriteFlipper;

    List<RotatorTowardsDirection> rotatorsTowardsDirection;

    [SerializeField] public MovementData movementData;
    [SerializeField] public AgentDataSO agentData;
    [SerializeField] public StateType originalState;

    void Awake()
    {
        rb2d = this.GetComponentThrowIfNotFound<Rigidbody2D>();
        agentInput = GetComponentInParent<AgentInput>();
        animationManager = this.GetComponentInChildrenThrowIfNotFound<AnimationManager>();
        spriteFlipper = this.GetComponentInChildrenThrowIfNotFound<SpriteFlipper>();
        // groundSensor = this.GetComponentInChildrenThrowIfNotFound<GroundSensor>();
        // climbSensor = this.GetComponentInChildrenThrowIfNotFound<ClimbSensor>();
        wallInFrontSensor = this.GetComponentInChildrenThrowIfNotFound<WallInFrontSensor>();
        wallInAllDirectionsSensor = transform.Find("Sensors/WallInAllDirections").gameObject.GetComponentThrowIfNotFound<SensorInAllDirectionsSensor>();
        playerInAllDirectionsSensor = transform.Find("Sensors/PlayerInAllDirections").gameObject.GetComponentThrowIfNotFound<SensorInAllDirectionsSensor>();
        playerInFrontSensor = this.GetComponentInChildrenThrowIfNotFound<PlayerInFrontSensor>();
        playerInAreaSensor = this.GetComponentInChildrenThrowIfNotFound<PlayerInAreaSensor>();
        // endOfGroundSensor = this.GetComponentInChildrenThrowIfNotFound<EndOfGroundSensor>();

        rotatorsTowardsDirection = GetComponentsInChildren<RotatorTowardsDirection>().ToList();

        weaponManager = this.GetComponentInChildrenThrowIfNotFound<WeaponManager>();
        stateManager = this.GetComponentInChildrenThrowIfNotFound<StateManager>();
        damageManager = this.GetComponentInChildrenThrowIfNotFound<DamageManager>();
        pointsManager = this.GetComponentInChildrenThrowIfNotFound<PointsManager>();
        // respawnManager = this.GetComponentInChildrenThrowIfNotFound<RespawnManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        agentInput.OnMovement += HandleMovement;
        agentInput.OnMovement += spriteFlipper.FaceDirection;

        foreach (var rotator in rotatorsTowardsDirection)
            agentInput.OnMovement += rotator.Rotate;

        agentInput.OnWeaponChange += weaponManager.HandleWeaponChange;
        Initialize();
    }

    void HandleMovement(Vector2 movement)
    {
        movementData.agentMovement = movement;
    }

    public void Die()
    {
        Debug.Log("Die()");
        stateManager.TransitionToState(StateType.Die);
    }

    public void DestroyOrRespawn()
    {
        if(respawnManager == null)
            DestroyObject();
        else
        {
            Initialize();
            respawnManager.Respawn();
        }
    }

    public void DestroyObject()
    {
        agentInput.OnMovement -= HandleMovement;
        agentInput.OnMovement -= spriteFlipper.FaceDirection;

        foreach (var rotator in rotatorsTowardsDirection)
            agentInput.OnMovement -= rotator.Rotate;

        agentInput.OnWeaponChange -= weaponManager.HandleWeaponChange;

        if(transform.parent.CompareTag("Enemy"))
            GameManager.instance.mapManager.EnemyRemoved(transform.parent.gameObject);

        Destroy(transform.parent.gameObject);
    }

    public void Initialize()
    {
        respawnManager?.Initialize(this);
        pointsManager?.Initialize();
        damageManager.Initialize(this, agentData.maxHealth);
        stateManager.Initialize(this);
        weaponManager.Initialize(this);

        stateManager.TransitionToState(originalState);
    }
}
