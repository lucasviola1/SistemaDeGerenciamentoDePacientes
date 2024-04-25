using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaDeGerenciamentoDePacientes.Models;
using SistemaDeGerenciamentoDePacientes.Services;
using System;

namespace SistemaDeGerenciamentoDePacientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleDePacientesController : ControllerBase
    {
        private readonly ILogger<ControleDePacientesController> _logger;

        private readonly IExames _exames;

        private readonly string _connectionString;

        public ControleDePacientesController(ILogger<ControleDePacientesController> logger, IConfiguration configuration, IExames exames)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("LocalSqlServer");
            _exames = exames;
        }

        [HttpGet]
        [Route("getpacientes")]

        public async Task<IActionResult> GetPacientes()
        {
            List<Pacientes> listaRetorno = new List<Pacientes>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, nome, idade, sexo, valorResultadoEx1, valorResultadoEx2 FROM Pacientes", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaRetorno.Add(new Pacientes()
                            {
                                id = Convert.ToInt32(reader["id"]),
                                nome = reader["nome"].ToString(),
                                idade = Convert.ToInt32(reader["idade"]),
                                sexo = Convert.ToChar(reader["sexo"]),
                                valorResultadoEx1 = reader["valorResultadoEx1"].ToString(),
                                valorResultadoEx2 = reader["valorResultadoEx2"].ToString()

                            });
                        }
                    }
                }
            }

            return Ok(new { obj = listaRetorno });
        }

        [HttpPost]
        [Route("addeditpaciente")]

        public async Task<IActionResult> AddEditPaciente([FromBody] Pacientes model)
        {

            model.valorResultadoEx1 = _exames.Exame1(model.idade, char.ToUpper(model.sexo));
            model.valorResultadoEx2 = _exames.Exame2(model.idade, char.ToUpper(model.sexo));
            if(model.id == 0 || model.id == null)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO Pacientes (nome, idade, sexo, valorResultadoEx1, valorResultadoEx2) VALUES (@nome, @idade, @sexo, @valorResultadoEx1, @valorResultadoEx2)", connection))
                    {
                        command.Parameters.AddWithValue("@nome", model.nome);
                        command.Parameters.AddWithValue("@idade", model.idade);
                        command.Parameters.AddWithValue("@sexo", char.ToUpper(model.sexo));
                        command.Parameters.AddWithValue("@valorResultadoEx1", model.valorResultadoEx1);
                        command.Parameters.AddWithValue("@valorResultadoEx2", model.valorResultadoEx2);

                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE Pacientes SET nome = @nome, idade = @idade, sexo = @sexo, valorResultadoEx1 = @valorResultadoEx1, valorResultadoEx2 = @valorResultadoEx2 where id = @id;", connection))
                    {
                        command.Parameters.AddWithValue("@id", model.id);
                        command.Parameters.AddWithValue("@nome", model.nome);
                        command.Parameters.AddWithValue("@idade", model.idade);
                        command.Parameters.AddWithValue("@sexo", char.ToUpper(model.sexo));
                        command.Parameters.AddWithValue("@valorResultadoEx1", model.valorResultadoEx1);
                        command.Parameters.AddWithValue("@valorResultadoEx2", model.valorResultadoEx2);

                        command.ExecuteNonQuery();
                    }
                }

            }

            

            return Ok("Ok!");
        }

        [HttpPost]
        [Route("deletepaciente")]

        public async Task<IActionResult> DeletePaciente([FromQuery] int id)
        {
            List<Pacientes> listaRetorno = new List<Pacientes>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM Pacientes WHERE id = {id}", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return Ok(new { obj = listaRetorno });
        }
    }
}