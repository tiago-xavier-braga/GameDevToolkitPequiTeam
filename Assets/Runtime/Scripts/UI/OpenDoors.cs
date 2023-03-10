using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace InfinityRun.UI
{
    public class OpenDoors : MonoBehaviour
    {
        [SerializeField] Image topDoor;
        [SerializeField] Image bottonDoor;
        [SerializeField] Vector2 bottonDoorNextPos;
        [SerializeField] Vector2 topDoorNextPos;
        [SerializeField] float topDoorTimeToOpen;
        [SerializeField] float bottonDoorTimeToOpen;
        [SerializeField] GameManager gameManager;
        [SerializeField] Vector2 bottonDoorDefaultPos;
        [SerializeField] Vector2 topDoorDefaultPos;
        [SerializeField] List<ParticleSystem> particles;
        [SerializeField] RotateGear rotateGear;



        private void Start()
        {
            bottonDoorDefaultPos = bottonDoor.transform.localPosition;
            topDoorDefaultPos = topDoor.transform.localPosition;
        }

        public void Open()
        {
            StopParticles();
            bottonDoor.transform.DOLocalMove(bottonDoorNextPos, bottonDoorTimeToOpen).SetEase(Ease.OutBack);
            topDoor.transform.DOLocalMove(topDoorNextPos, topDoorTimeToOpen).SetEase(Ease.OutBack);
            gameManager.StartGame();
        }

        public void ResetPos()
        {
            topDoor.transform.localPosition = topDoorDefaultPos;
            bottonDoor.transform.localPosition = bottonDoorDefaultPos;
        }

        public void CloseDoors()
        {
            PlayParticles();
            gameManager.hudUI.DOFade(0, 1f);
            rotateGear.ReverseRotate();
            bottonDoor.transform.DOLocalMove(bottonDoorDefaultPos, bottonDoorTimeToOpen - 1);
            topDoor.transform.DOLocalMove(topDoorDefaultPos, topDoorTimeToOpen - 1).OnComplete(() => gameManager.GameOver());
        }

        public void PlayParticles()
        {
            foreach (var particle in particles)
            {
                particle.Play();
            }
        }

        public void StopParticles()
        {
            foreach (var particle in particles)
            {
                particle.Stop();
            }
        }
    }

}


