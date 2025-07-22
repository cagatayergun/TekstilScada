// Core/RecipeCsvConverter.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TekstilScada.Models;

namespace TekstilScada.Core
{
    public static class RecipeCsvConverter
    {
        /// <summary>
        /// Bir ScadaRecipe nesnesini HMI'ın anlayacağı CSV formatına dönüştürür.
        /// </summary>
        public static string ToCsv(ScadaRecipe recipe)
        {
            if (recipe == null || recipe.Steps == null) return "";

            var csvBuilder = new StringBuilder();

            // ÖNEMLİ: Buradaki mantık, HMI'daki CSV dosyasının formatına
            // birebir uymalıdır. Bu bir varsayımdır.
            // Örnek: Her satır bir adımı, her sütun bir Word'ü temsil eder.

            // Başlık satırı (opsiyonel, HMI formatına bağlı)
            // csvBuilder.AppendLine("Step,Word0,Word1,...,Word24");

            foreach (var step in recipe.Steps)
            {
                // StepDataWords dizisindeki 25 short değeri virgülle ayırarak birleştir
                string line = string.Join(",", step.StepDataWords.Select(w => w.ToString()));
                csvBuilder.AppendLine(line);
            }

            return csvBuilder.ToString();
        }

        /// <summary>
        /// Bir CSV dosyasının içeriğini ScadaRecipe nesnesine dönüştürür.
        /// </summary>
        public static ScadaRecipe ToRecipe(string csvContent, string recipeName)
        {
            var recipe = new ScadaRecipe { RecipeName = recipeName };
            if (string.IsNullOrWhiteSpace(csvContent)) return recipe;

            var lines = csvContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int stepNumber = 1;
            foreach (var line in lines)
            {
                try
                {
                    var step = new ScadaRecipeStep { StepNumber = stepNumber++ };
                    var values = line.Split(',');

                    // Her satırda 25 değer olmalı
                    if (values.Length == 25)
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            step.StepDataWords[i] = Convert.ToInt16(values[i]);
                        }
                        recipe.Steps.Add(step);
                    }
                    else
                    {
                        // Hatalı formatta satırları logla veya yoksay
                    }
                }
                catch
                {
                    // Hatalı satırları logla veya yoksay
                }
            }

            return recipe;
        }
    }
}
