/// <summary>
/// date ：2016-03-04
/// fanzhengyong
/// 头顶血条，随着角色移动，如果角色Z轴有变化，血条会产生缩放
/// </summary>

using UnityEngine;
using System.Collections;

namespace UEngine
{
    public class HeadBloodLineScript : MonoBehaviour
    {
        public GameObject PlayerGo;
        // Use this for initialization
        private float oldDistance;
        private float newDistance;
        private float scale;
        private Vector3 scaleV3 = Vector3.one;
        void Start()
        {
            oldDistance = Vector3.Distance(PlayerGo.transform.position, Camera.main.transform.position);
        }

        // Update is called once per frame
        void Update()
        {

            Follow();
        }

        void Follow()
        {
            Transform playerTrs = PlayerGo.transform;
            Vector2 position = Camera.main.WorldToScreenPoint(playerTrs.position);
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.position = position;

            newDistance = Vector3.Distance(PlayerGo.transform.position, Camera.main.transform.position);
            scale = oldDistance / newDistance;
            scaleV3 = Vector3.one * scale;
            rectTransform.localScale = scaleV3;
        }
    }

}
