using UnityEngine;

namespace Assets.Scripts.HelpingClass
{
    public class Moving
    {
        public float distance;
        public float fractionOfJourney;
        public float distCovered;
        public bool isMove = false;

        public void StartMoving(Vector3 positionTo, Transform positionFrom)
        {
            if (Vector3.Distance(positionTo, positionFrom.position) > 0.1f)
            {
                distCovered += Time.deltaTime * 0.03f;
                fractionOfJourney = distCovered / distance;
                positionFrom.position = Vector3.Lerp(positionFrom.position,
                                   new Vector3(positionTo.x, 0.1f, positionTo.z),
                                       fractionOfJourney);
            }
        }
        public void StopMoving(Vector3 positionTo, Vector3 positionFrom, Animator animator, AudioSource audioSource)
        {
            if (Vector3.Distance(positionTo, positionFrom) < 0.2f)
            {
                isMove = false;
                animator.SetBool("isRun", false);
                audioSource.Stop();
            }
        }
        public void AcceptMove(Vector3 positionTo , Transform positionFrom)
        {
            Vector3 tmpPosition = new Vector3(positionTo.x, 0, positionTo.z);

            if (positionTo != positionFrom.position)
                positionFrom.LookAt(tmpPosition);

            distance = Vector3.Distance(positionFrom.position, positionTo);
            distCovered = Time.deltaTime;
            isMove = true;
        }
    }
}
