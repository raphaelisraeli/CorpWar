using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Core
{
    public static class AttributeLoader
    {
        public static List<Attribute> LoadAttributes(string jsonFilePath)
        {
            TextAsset jsonText = Resources.Load<TextAsset>(jsonFilePath);
            if (jsonText == null)
            {
                Debug.LogError("Failed to load JSON file at path: " + jsonFilePath);
                return new List<Attribute>();
            }
            List<AttributeData> attributeDataList = JsonUtility.FromJson<AttributeDataList>(jsonText.text).attributes;
            List<Attribute> attributes = new List<Attribute>();
            foreach (var attributeData in attributeDataList)
            {
                attributes.Add(new Attribute(attributeData.name, 1, attributeData.description));
            }
            return attributes;
        }
    }

    [System.Serializable]
    public class AttributeData
    {
        public string name;
        public string description;
    }

    [System.Serializable]
    public class AttributeDataList
    {
        public List<AttributeData> attributes;
    }
}
