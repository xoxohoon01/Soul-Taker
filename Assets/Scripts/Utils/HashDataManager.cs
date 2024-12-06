using UnityEngine;

public class HashDataManager
{
    #region Animation Data
    public static readonly int movementParameterHash = Animator.StringToHash("@Movement");
    public static readonly int idleParameterHash = Animator.StringToHash("Idle");
    public static readonly int runParameterHash = Animator.StringToHash("Run");
    public static readonly int attackParameterHash = Animator.StringToHash("@Attack");
    public static readonly int basicAttackParameterHash = Animator.StringToHash("BasicAttack");
    public static readonly int dieParameterHash = Animator.StringToHash("Die");
    #endregion
}
