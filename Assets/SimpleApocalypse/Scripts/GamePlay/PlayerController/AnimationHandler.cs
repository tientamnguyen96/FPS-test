using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimHandleLogic
{
    void PlayCoroutine(IEnumerator routine);
}

public class AnimationHandler
{
    IAnimHandleLogic _animHandleLogic;

    public AnimationHandler(IAnimHandleLogic logic)
    {
        _animHandleLogic = logic;
    }

    public void ChangeGun(Transform currentArm, Transform nextArm)
    {
        var currentAnim = currentArm.GetComponent<Animator>();
        var nextAnim = nextArm.GetComponent<Animator>();

        _animHandleLogic.PlayCoroutine(PlayAnim(currentAnim, "Change", () =>
        {
            currentArm.gameObject.SetActive(false);
            nextArm.gameObject.SetActive(true);
            _animHandleLogic.PlayCoroutine(PlayAnim(nextAnim, "Take_Out"));
        }));
    }

    public void Fire(Transform currentArm)
    {
        var currentAnim = currentArm.GetComponent<Animator>();
        _animHandleLogic.PlayCoroutine(PlayAnim(currentAnim, "Fire"));
    }

    public IEnumerator PlayAnim(Animator animator, string animName, System.Action cb = null, float delay = 0, bool reset = true)
    {
        if (delay > 0.00001f)
            yield return new WaitForSeconds(delay);

        if (reset)
        {
            animator.gameObject.SetActive(false);
            animator.gameObject.SetActive(true);
        }

        animator.Play(animName, -1, 0f);
        yield return null;

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            yield return null;

        cb?.Invoke();
    }
}
