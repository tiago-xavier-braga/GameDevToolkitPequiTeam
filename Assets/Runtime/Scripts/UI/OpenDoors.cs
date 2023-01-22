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


        private void Start()
        {
            bottonDoorDefaultPos = bottonDoor.transform.localPosition;
            topDoorDefaultPos = topDoor.transform.localPosition;
        }

        public void Open()
        {
            foreach (var particle in particles)
            {
                particle.Play();
            }
            bottonDoor.transform.DOLocalMove(bottonDoorNextPos, bottonDoorTimeToOpen).SetEase(Ease.OutBack);
            topDoor.transform.DOLocalMove(topDoorNextPos, topDoorTimeToOpen).SetEase(Ease.OutBack).OnComplete(() => gameManager.StartGame());
        }

        public void ResetPos()
        {
            topDoor.transform.localPosition = topDoorDefaultPos;
            bottonDoor.transform.localPosition = bottonDoorDefaultPos;
        }
    }
}
