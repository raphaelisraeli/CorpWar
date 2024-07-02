namespace MyGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public static class FormulaEvaluator
    {
        // Method to evaluate the formula based on the given attributes
        public static int Evaluate(string formula, Dictionary<string, int> attributes)
        {
            // Replace attribute names in the formula with their values
            foreach (var attribute in attributes)
            {
                formula = formula.Replace(attribute.Key, attribute.Value.ToString());
            }

            // Evaluate the formula
            try
            {
                DataTable table = new DataTable();
                var value = table.Compute(formula, string.Empty);
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error evaluating formula: " + ex.Message);
                return 0;
            }
        }
    }
}