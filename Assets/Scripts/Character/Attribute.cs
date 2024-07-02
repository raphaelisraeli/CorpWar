namespace MyGame.Core
{

    using System;
    using System.Collections.Generic;
    using System.Data;

    [System.Serializable]
    public class Attribute
    {
        public string name;
        public int value;
        public string description;

        public Attribute(string name, int value, string description)
        {
            this.name = name;
            this.value = value;
            this.description = description;
        }
    }

    [System.Serializable]
    public class Stat
    {
        public string name;
        public int value;
        public string description;
        public string formula;

        public Stat(string name, int value, string description, string formula)
        {
            this.name = name;
            this.value = value;
            this.description = description;
            this.formula = formula;
        }

        public void CalculateValue(List<Attribute> attributes)
        {
            Dictionary<string, int> attributeDict = new Dictionary<string, int>();
            foreach (var attribute in attributes)
            {
                attributeDict[attribute.name] = attribute.value;
            }

            value = FormulaEvaluator.Evaluate(formula, attributeDict);
        }
    }
}