using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    AttackController attackController;

    public float stopAttackingDistance = .2f;

    public float attackRate = 2f;
    private float attackTimer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        attackController = animator.GetComponent<AttackController>();
        attackController.SetAttackMaterial();
        attackController.muzzleEffect.gameObject.SetActive(true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackController.targetToAttack != null && animator.transform.GetComponent<UnitMovement>().isCommandedtoMove == false)
        {
            LookAtTarget();

            // Keep moving towards enemy
            // agent.SetDestination(attackController.targetToAttack.position);
            
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = 1f / attackRate; // reset timer
            }

            else
            {
                attackTimer -= Time.deltaTime;
            }

            //Should unit still attack?
            float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
            if (distanceFromTarget < stopAttackingDistance || attackController.targetToAttack == null)
            {
                animator.SetBool("isAttacking", false); // move to follow state
            }
        }
        else
        {
            animator.SetBool("isAttacking", false); // move to follow state
        }


    }

    private void Attack()
    {
        var damageToInflict = attackController.unitDamage;

        SoundManager.Instance.PlayInfantryAttackSound();
        
            // Actually attack unit
            attackController.targetToAttack.GetComponent<Unit>().TakeDamage(damageToInflict);
    }


    private void LookAtTarget()
    {
   

        // Calculate the direction to look at
        Vector3 direction = attackController.targetToAttack.position - agent.transform.position;

        // Create a rotation based on the direction
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Apply the rotation to the agent, but only on the y-axis
        var yRotation = lookRotation.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController.muzzleEffect.gameObject.SetActive(false);
    }



}
