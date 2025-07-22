// Repositories/RecipeRepository.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TekstilScada.Models;

namespace TekstilScada.Repositories
{
    public class RecipeRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=scada_db;user=user1;password=Cagatay.19;";

        public void SaveRecipe(ScadaRecipe recipe)
        {
            // Bu metot daha önce oluşturuldu, Id kontrolü eklenerek güncellendi.
            if (recipe.Id > 0)
            {
                UpdateRecipe(recipe);
            }
            else
            {
                AddRecipe(recipe);
            }
        }

        private void AddRecipe(ScadaRecipe recipe)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string recipeQuery = "INSERT INTO recipes (RecipeName, CreationDate) VALUES (@RecipeName, @CreationDate); SELECT LAST_INSERT_ID();";
                        var recipeCmd = new MySqlCommand(recipeQuery, connection, transaction);
                        recipeCmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                        recipeCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        recipe.Id = Convert.ToInt32(recipeCmd.ExecuteScalar());

                        foreach (var step in recipe.Steps)
                        {
                            string stepQuery = "INSERT INTO recipe_steps (RecipeId, StepNumber, Word0, Word1, Word2, Word3, Word4, Word5, Word6, Word7, Word8, Word9, Word10, Word11, Word12, Word13, Word14, Word15, Word16, Word17, Word18, Word19, Word20, Word24) " +
                                               "VALUES (@RecipeId, @StepNumber, @Word0, @Word1, @Word2, @Word3, @Word4, @Word5, @Word6, @Word7, @Word8, @Word9, @Word10, @Word11, @Word12, @Word13, @Word14, @Word15, @Word16, @Word17, @Word18, @Word19, @Word20, @Word24);";

                            var stepCmd = new MySqlCommand(stepQuery, connection, transaction);
                            stepCmd.Parameters.AddWithValue("@RecipeId", recipe.Id);
                            stepCmd.Parameters.AddWithValue("@StepNumber", step.StepNumber);
                            for (int i = 0; i <= 24; i++)
                            {
                                if (i >= 21 && i <= 23) continue; // String alanları atla
                                stepCmd.Parameters.AddWithValue($"@Word{i}", step.StepDataWords[i]);
                            }
                            stepCmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void UpdateRecipe(ScadaRecipe recipe)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Ana reçete adını güncelle
                        string recipeQuery = "UPDATE recipes SET RecipeName = @RecipeName WHERE Id = @Id;";
                        var recipeCmd = new MySqlCommand(recipeQuery, connection, transaction);
                        recipeCmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                        recipeCmd.Parameters.AddWithValue("@Id", recipe.Id);
                        recipeCmd.ExecuteNonQuery();

                        // 2. Bu reçeteye ait eski adımları sil
                        string deleteStepsQuery = "DELETE FROM recipe_steps WHERE RecipeId = @RecipeId;";
                        var deleteCmd = new MySqlCommand(deleteStepsQuery, connection, transaction);
                        deleteCmd.Parameters.AddWithValue("@RecipeId", recipe.Id);
                        deleteCmd.ExecuteNonQuery();

                        // 3. Yeni/güncellenmiş adımları ekle
                        foreach (var step in recipe.Steps)
                        {
                            // Adım ekleme sorgusu (AddRecipe ile aynı)
                            string stepQuery = "INSERT INTO recipe_steps (RecipeId, StepNumber, Word0, Word1, Word2, Word3, Word4, Word5, Word6, Word7, Word8, Word9, Word10, Word11, Word12, Word13, Word14, Word15, Word16, Word17, Word18, Word19, Word20, Word24) " +
                                              "VALUES (@RecipeId, @StepNumber, @Word0, @Word1, @Word2, @Word3, @Word4, @Word5, @Word6, @Word7, @Word8, @Word9, @Word10, @Word11, @Word12, @Word13, @Word14, @Word15, @Word16, @Word17, @Word18, @Word19, @Word20, @Word24);";
                            var stepCmd = new MySqlCommand(stepQuery, connection, transaction);
                            stepCmd.Parameters.AddWithValue("@RecipeId", recipe.Id);
                            stepCmd.Parameters.AddWithValue("@StepNumber", step.StepNumber);
                            for (int i = 0; i <= 24; i++)
                            {
                                if (i >= 21 && i <= 23) continue;
                                stepCmd.Parameters.AddWithValue($"@Word{i}", step.StepDataWords[i]);
                            }
                            stepCmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception) { transaction.Rollback(); throw; }
                }
            }
        }

        // YENİ: Hata veren eksik metot eklendi.
        public List<ScadaRecipe> GetAllRecipes()
        {
            var recipes = new List<ScadaRecipe>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, RecipeName, CreationDate FROM recipes ORDER BY RecipeName;";
                var cmd = new MySqlCommand(query, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        recipes.Add(new ScadaRecipe
                        {
                            Id = reader.GetInt32("Id"),
                            RecipeName = reader.GetString("RecipeName"),
                            CreationDate = reader.GetDateTime("CreationDate")
                        });
                    }
                }
            }
            return recipes;
        }
        public void DeleteRecipe(int recipeId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // ON DELETE CASCADE sayesinde, sadece ana reçeteyi silmek yeterlidir.
                string query = "DELETE FROM recipes WHERE Id = @Id;";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", recipeId);
                cmd.ExecuteNonQuery();
            }
        }
        // YENİ: Hata veren eksik metot eklendi.
        public ScadaRecipe GetRecipeById(int recipeId)
        {
            ScadaRecipe recipe = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string recipeQuery = "SELECT Id, RecipeName, CreationDate FROM recipes WHERE Id = @Id;";
                var recipeCmd = new MySqlCommand(recipeQuery, connection);
                recipeCmd.Parameters.AddWithValue("@Id", recipeId);

                using (var reader = recipeCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recipe = new ScadaRecipe
                        {
                            Id = reader.GetInt32("Id"),
                            RecipeName = reader.GetString("RecipeName"),
                            CreationDate = reader.GetDateTime("CreationDate")
                        };
                    }
                }

                if (recipe != null)
                {
                    // Adımları yükle
                    string stepsQuery = "SELECT * FROM recipe_steps WHERE RecipeId = @RecipeId ORDER BY StepNumber;";
                    var stepsCmd = new MySqlCommand(stepsQuery, connection);
                    stepsCmd.Parameters.AddWithValue("@RecipeId", recipeId);

                    using (var reader = stepsCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var step = new ScadaRecipeStep
                            {
                                Id = reader.GetInt32("Id"),
                                StepNumber = reader.GetInt32("StepNumber")
                            };
                            for (int i = 0; i <= 24; i++)
                            {
                                if (i >= 21 && i <= 23) continue;
                                step.StepDataWords[i] = reader.GetInt16($"Word{i}");
                            }
                            recipe.Steps.Add(step);
                        }
                    }
                }
            }
            return recipe;
        }
    }
}
