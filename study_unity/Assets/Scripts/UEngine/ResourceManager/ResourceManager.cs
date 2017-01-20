using UnityEngine;
using System.Collections;

namespace UEngine
{
    public enum ResourceType
    {
        None,   // 无
        Data,   // 策划数据
        Effect, // 特效
        Model,  // 模型
        Music,  // 背景音乐
        Scene,  // 场景
        Sound,  // 音效
        UI,     // 界面
        Misc,   // 其他
    }

    public class ResourceManager
    {
        private static ResourceManager instance = null;

        public static ResourceManager Instance()
        {
            if (instance == null)
            {
                instance = new ResourceManager();
            }
            return instance;
        }

        public void Init()
        {
            
        }

        public TextAsset GetTextAsset(ResourceType type, string name, string suffix = ".txt")
        {
            TextAsset textAsset = null;
            return textAsset;

        }
    }
}

