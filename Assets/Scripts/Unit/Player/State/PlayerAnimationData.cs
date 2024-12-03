using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string movementParameterName = "@Movement";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "Run";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string basicAttackParameterName = "BasicAttack";
    //[SerializeField] private string comboAttackParameterName = "ComboAttack";
    //[SerializeField] private string skillParameterName = "@Skill";

    public int MovementParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int BasicAttackParameterHash { get; private set; }
    //public int ComboAttackParameterHash { get; private set; }
    //public int SkillParameterHash { get; private set; }

    public void Initialize()
    {
        MovementParameterHash = Animator.StringToHash(movementParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        BasicAttackParameterHash = Animator.StringToHash(basicAttackParameterName);
        //ComboAttackParameterHash = Animator.StringToHash(comboAttackParameterName);

        //SkillParameterHash = Animator.StringToHash(skillParameterName);
    }
}
